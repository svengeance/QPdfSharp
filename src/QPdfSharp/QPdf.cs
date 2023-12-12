// Copyright © Stephen (Sven) Vernyi and Contributors. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

using System.Runtime.InteropServices;
using System.Text;
using QPdfSharp.Interop;

namespace QPdfSharp;

public unsafe class QPdf: IDisposable
{
    public static readonly string Version = new(QPdfInterop.qpdf_get_qpdf_version());

    private readonly QPdfData* _qPdfData = QPdfInterop.qpdf_init();

    ~QPdf() => ReleaseUnmanagedResources();

    public QPdf(string filePath, string password = "")
    {
        fixed (byte* filePathBytes = Encoding.UTF8.GetBytes(filePath))
        fixed (byte* passwordBytes = Encoding.UTF8.GetBytes(password))
            CheckError(QPdfInterop.qpdf_read(_qPdfData, (sbyte*)filePathBytes, (sbyte*)passwordBytes));
    }

    public QPdf(ReadOnlyMemory<byte> bytes, string name = "", string password = "")
    {
        using var fileBytesHandle = bytes.Pin();

        fixed (byte* fileNameBytes = Encoding.UTF8.GetBytes(name))
        fixed (byte* passwordBytes = Encoding.UTF8.GetBytes(password))
            CheckError(QPdfInterop.qpdf_read_memory(_qPdfData, (sbyte*)fileNameBytes, (sbyte*)fileBytesHandle.Pointer, (ulong)bytes.Length, (sbyte*)passwordBytes));
    }

    public void WriteFile(string outputFilePath)
    {
        fixed (byte* outputFilePathBytes = Encoding.UTF8.GetBytes(outputFilePath))
            CheckError(QPdfInterop.qpdf_init_write(_qPdfData, (sbyte*)outputFilePathBytes));

        QPdfInterop.qpdf_write(_qPdfData);
    }

    public ReadOnlySpan<byte> WriteBytes()
    {
        CheckError(QPdfInterop.qpdf_init_write_memory(_qPdfData));
        CheckError(QPdfInterop.qpdf_write(_qPdfData));

        var buffer = QPdfInterop.qpdf_get_buffer(_qPdfData);
        var bufferLength = QPdfInterop.qpdf_get_buffer_length(_qPdfData);
        CheckError();

        return new ReadOnlySpan<byte>(buffer, (int)bufferLength);
    }

    public Stream WriteStream()
    {
        CheckError(QPdfInterop.qpdf_init_write_memory(_qPdfData));
        CheckError(QPdfInterop.qpdf_write(_qPdfData));

        var buffer = QPdfInterop.qpdf_get_buffer(_qPdfData);
        var bufferLength = QPdfInterop.qpdf_get_buffer_length(_qPdfData);
        CheckError();

        return new UnmanagedMemoryStream(buffer, (long)bufferLength);
    }

    public void Dispose()
    {
        ReleaseUnmanagedResources();
        GC.SuppressFinalize(this);
    }

    private void CheckError(int? errorCode = null)
    {
        errorCode ??= QPdfInterop.qpdf_has_error(_qPdfData);

        if (errorCode == 0)
            return;

        var error = QPdfInterop.qpdf_get_error(_qPdfData);
        var errorMessage = new string(QPdfInterop.qpdf_get_error_full_text(_qPdfData, error));

        throw new QPdfException(errorMessage);
    }

    private void ReleaseUnmanagedResources()
    {
        fixed (QPdfData** pdf = &_qPdfData)
            QPdfInterop.qpdf_cleanup(pdf);
    }
}

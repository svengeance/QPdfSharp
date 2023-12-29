// Copyright © Stephen (Sven) Vernyi and Contributors. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

using QPdfSharp.Extensions;
using QPdfSharp.Interop;

namespace QPdfSharp;

public unsafe class QPdf: IDisposable
{
    public static readonly string Version = new(QPdfInterop.qpdf_get_qpdf_version());

    private readonly QPdfData* _qPdfData = QPdfInterop.qpdf_init();

    ~QPdf() => ReleaseUnmanagedResources();

    public QPdf(string filePath, string password = "")
    {
        fixed (sbyte* filePathBytes = filePath.ToSByte())
        fixed (sbyte* passwordBytes = password.ToSByte())
            CheckError(QPdfInterop.qpdf_read(_qPdfData, filePathBytes, passwordBytes));
    }

    public QPdf(ReadOnlyMemory<byte> bytes, string name = "in-memory pdf", string password = "")
    {
        if (string.IsNullOrEmpty(name))
            throw new ArgumentException("Must give a non-null non-empty name for an in-memory PDF.", nameof(name));

        using var fileBytesHandle = bytes.Pin();

        fixed (sbyte* fileNameBytes = name.ToSByte())
        fixed (sbyte* passwordBytes = password.ToSByte())
            CheckError(QPdfInterop.qpdf_read_memory(_qPdfData, fileNameBytes, (sbyte*)fileBytesHandle.Pointer, (ulong)bytes.Length, passwordBytes));
    }

    public int GetPageCount()
    {
        var pageCount = QPdfInterop.qpdf_get_num_pages(_qPdfData);
        CheckError();

        return pageCount;
    }

    public void WriteFile(string outputFilePath)
    {
        fixed (sbyte* outputFilePathBytes = outputFilePath.ToSByte())
            CheckError(QPdfInterop.qpdf_init_write(_qPdfData, outputFilePathBytes));

        CheckError(QPdfInterop.qpdf_write(_qPdfData));
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

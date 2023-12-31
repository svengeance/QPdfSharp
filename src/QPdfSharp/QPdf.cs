﻿// Copyright © Stephen (Sven) Vernyi and Contributors. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

using QPdfSharp.Extensions;
using QPdfSharp.Interop;

namespace QPdfSharp;

public unsafe partial class QPdf: IDisposable
{
    public static readonly string Version = new(QPdfInterop.qpdf_get_qpdf_version());

    internal readonly QPdfData* _qPdfData = QPdfInterop.qpdf_init();

    private QPdfStream? _outputStream;
    private bool _hasWrittenData;

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

    public void Dispose()
    {
        if (_outputStream is { IsDisposed: false })
            throw new InvalidOperationException($"Attempted to dispose of QPdf while the output stream is still in use. Please dispose of all resources before disposing of the QPdf instance.");

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

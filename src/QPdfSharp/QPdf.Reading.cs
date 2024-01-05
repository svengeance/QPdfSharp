// Copyright © Stephen (Sven) Vernyi and Contributors. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

using QPdfSharp.Extensions;
using QPdfSharp.Interop;
using QPdfSharp.Options;

namespace QPdfSharp;

public unsafe partial class QPdf: IDisposable
{
    public static readonly string Version = new(QPdfInterop.qpdf_get_qpdf_version());

    public string PdfVersion => new(QPdfInterop.qpdf_get_pdf_version(_qPdfData));
    public int PdfExtensionLevel => QPdfInterop.qpdf_get_pdf_extension_level(_qPdfData);
    public bool IsEncrypted => QPdfInterop.qpdf_is_encrypted(_qPdfData) == 1;
    public bool IsLinearized => QPdfInterop.qpdf_is_linearized(_qPdfData) == 1;
    public bool AllowAccessibility => QPdfInterop.qpdf_allow_accessibility(_qPdfData) == 1;
    public bool AllowExtractAll => QPdfInterop.qpdf_allow_extract_all(_qPdfData) == 1;
    public bool AllowPrintLowRes => QPdfInterop.qpdf_allow_print_low_res(_qPdfData) == 1;
    public bool AllowPrintHighRes => QPdfInterop.qpdf_allow_print_high_res(_qPdfData) == 1;
    public bool AllowModifyAssembly => QPdfInterop.qpdf_allow_modify_assembly(_qPdfData) == 1;
    public bool AllowModifyForm => QPdfInterop.qpdf_allow_modify_form(_qPdfData) == 1;
    public bool AllowModifyAnnotation => QPdfInterop.qpdf_allow_modify_annotation(_qPdfData) == 1;
    public bool AllowModifyOther => QPdfInterop.qpdf_allow_modify_other(_qPdfData) == 1;
    public bool AllowModifyAll => QPdfInterop.qpdf_allow_modify_all(_qPdfData) == 1;
    public string Password => new(QPdfInterop.qpdf_get_user_password(_qPdfData));

    private readonly QPdfData* _qPdfData = QPdfInterop.qpdf_init();
    private QPdfStream? _outputStream;
    private bool _hasWrittenData;

    ~QPdf() => ReleaseUnmanagedResources();

    public QPdf(string filePath, string password = "", QPdfReadOptions? readOptions = null)
    {
        InitializeQPdf(readOptions);

        fixed (sbyte* filePathBytes = filePath.ToSByte())
        fixed (sbyte* passwordBytes = password.ToSByte())
        {
            var qpdReadResult = readOptions?.IsJsonFormat == true
                ? QPdfInterop.qpdf_create_from_json_file(_qPdfData, filePathBytes)
                : QPdfInterop.qpdf_read(_qPdfData, filePathBytes, passwordBytes);

            CheckError(qpdReadResult);
        }
    }

    public QPdf(ReadOnlyMemory<byte> bytes, string name = "in-memory pdf", string password = "", QPdfReadOptions? readOptions = null)
    {
        if (string.IsNullOrEmpty(name))
            throw new ArgumentException("Must give a non-null non-empty name for an in-memory PDF.", nameof(name));

        InitializeQPdf(readOptions);

        using var fileBytesHandle = bytes.Pin();

        fixed (sbyte* fileNameBytes = name.ToSByte())
        fixed (sbyte* passwordBytes = password.ToSByte())
        {
            var qpdReadResult = readOptions?.IsJsonFormat == true
                ? QPdfInterop.qpdf_create_from_json_data(_qPdfData, (sbyte*)fileBytesHandle.Pointer, (ulong)bytes.Length)
                : QPdfInterop.qpdf_read_memory(_qPdfData, fileNameBytes, (sbyte*)fileBytesHandle.Pointer, (ulong)bytes.Length, passwordBytes);

            CheckError(qpdReadResult);
        }
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

    private void InitializeQPdf(QPdfReadOptions? options)
    {
        QPdfInterop.qpdf_silence_errors(_qPdfData);

        if (options is null)
            return;

        if (options.AttemptRecovery is { } attemptRecoveryValue)
            QPdfInterop.qpdf_set_attempt_recovery(_qPdfData, attemptRecoveryValue.ToQPdfBool());

        if (options.IgnoreXrefStreams is { } ignoreXrefStreamsValue)
            QPdfInterop.qpdf_set_ignore_xref_streams(_qPdfData, ignoreXrefStreamsValue.ToQPdfBool());
    }
}

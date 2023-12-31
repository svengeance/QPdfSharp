// Copyright © Stephen (Sven) Vernyi and Contributors. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

using QPdfSharp.Extensions;
using QPdfSharp.Interop;
using QPdfSharp.Options;

namespace QPdfSharp;

public unsafe partial class QPdf
{
    public void WriteFile(string outputFilePath, QPdfWriteOptions? writeOptions = null)
    {
        MarkDataWritten();
        ApplyWriteOptions(writeOptions);

        fixed (sbyte* outputFilePathBytes = outputFilePath.ToSByte())
            CheckError(QPdfInterop.qpdf_init_write(_qPdfData, outputFilePathBytes));

        CheckError(QPdfInterop.qpdf_write(_qPdfData));
    }

    public ReadOnlySpan<byte> WriteBytes(QPdfWriteOptions? writeOptions = null)
    {
        MarkDataWritten();
        ApplyWriteOptions(writeOptions);

        CheckError(QPdfInterop.qpdf_init_write_memory(_qPdfData));
        CheckError(QPdfInterop.qpdf_write(_qPdfData));

        var buffer = QPdfInterop.qpdf_get_buffer(_qPdfData);
        var bufferLength = QPdfInterop.qpdf_get_buffer_length(_qPdfData);
        CheckError();

        return new ReadOnlySpan<byte>(buffer, (int)bufferLength);
    }

    public Stream WriteStream(QPdfWriteOptions? writeOptions = null)
    {
        MarkDataWritten();
        ApplyWriteOptions(writeOptions);

        CheckError(QPdfInterop.qpdf_init_write_memory(_qPdfData));
        CheckError(QPdfInterop.qpdf_write(_qPdfData));

        var buffer = QPdfInterop.qpdf_get_buffer(_qPdfData);
        var bufferLength = QPdfInterop.qpdf_get_buffer_length(_qPdfData);
        CheckError();

        return _outputStream = new QPdfStream(buffer, (long)bufferLength);
    }

    private void ApplyWriteOptions(QPdfWriteOptions? writeOptions)
    {
        if (writeOptions is null)
            return;

        if (writeOptions.CompressStreams is { } compressValue)
            QPdfInterop.qpdf_set_compress_streams(_qPdfData, compressValue.ToQPdfBool());

        if (writeOptions.Linearize is { } linearizeValue)
            QPdfInterop.qpdf_set_linearization(_qPdfData, linearizeValue.ToQPdfBool());

        if (writeOptions.NewlineBeforeEndOfStream is { } newlineValue)
            QPdfInterop.qpdf_set_newline_before_endstream(_qPdfData, newlineValue.ToQPdfBool());

        if (writeOptions.NormalizeContent is { } normalizeValue)
            QPdfInterop.qpdf_set_content_normalization(_qPdfData, normalizeValue.ToQPdfBool());

        if (writeOptions.PreserveEncryption is { } preserveEncryptionValue)
            QPdfInterop.qpdf_set_preserve_encryption(_qPdfData, preserveEncryptionValue.ToQPdfBool());

        if (writeOptions.PreserveUnreferencedObjects is { } preserveUnreferencedObjectsValue)
            QPdfInterop.qpdf_set_preserve_unreferenced_objects(_qPdfData, preserveUnreferencedObjectsValue.ToQPdfBool());

        if (writeOptions.QPdfObjectStreamMode is { } objectStreamModeValue)
            QPdfInterop.qpdf_set_qdf_mode(_qPdfData, (int)objectStreamModeValue);

        if (writeOptions.QPdfStreamDataMode is { } streamDataModeValue)
            QPdfInterop.qpdf_set_stream_data_mode(_qPdfData, (QPdfStreamData)streamDataModeValue);

        if (writeOptions.QPdfStreamDecodeLevel is { } streamDecodeLevelValue)
            QPdfInterop.qpdf_set_decode_level(_qPdfData, (QPdfStreamDecodeLevel)streamDecodeLevelValue);

        if (writeOptions.SuppressOriginalObjectIds is { } suppressOriginalObjectIdsValue)
            QPdfInterop.qpdf_set_suppress_original_object_IDs(_qPdfData, suppressOriginalObjectIdsValue.ToQPdfBool());

        if (writeOptions.UseDeterministicIdGeneration is { } useDeterministicIdGenerationValue)
            QPdfInterop.qpdf_set_deterministic_ID(_qPdfData, useDeterministicIdGenerationValue.ToQPdfBool());

        if (writeOptions.WriteAsQdf is { } writeAsQdfValue)
            QPdfInterop.qpdf_set_qdf_mode(_qPdfData, writeAsQdfValue.ToQPdfBool());

        if (writeOptions.ForcePdfVersion is { } forcePdfVersionValue)
        {
            fixed (sbyte* forcePdfVersionBytes = forcePdfVersionValue.ToSByte())
                QPdfInterop.qpdf_force_pdf_version_and_extension(_qPdfData, forcePdfVersionBytes, writeOptions.ForcePdfExtensionLevel ?? 0);
        }

        if (writeOptions.MinimumPdfVersion is { } minimumPdfVersionValue)
        {
            fixed (sbyte* minimumPdfVersionBytes = minimumPdfVersionValue.ToSByte())
                QPdfInterop.qpdf_set_minimum_pdf_version_and_extension(_qPdfData, minimumPdfVersionBytes, writeOptions.MinimumPdfExtensionLevel ?? 0);
        }
    }

    private void MarkDataWritten()
    {
        if (_hasWrittenData)
            throw new InvalidOperationException("This QPdf instance has already written data.");

        _hasWrittenData = true;
    }}

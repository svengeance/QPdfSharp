// Copyright © Stephen (Sven) Vernyi and Contributors. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using QPdfSharp.Extensions;
using QPdfSharp.Interop;
using QPdfSharp.Options;

namespace QPdfSharp;

public unsafe partial class QPdf
{
    public void WriteFile(string outputFilePath, QPdfWriteOptions? writeOptions = null)
    {
        fixed (sbyte* outputFilePathBytes = outputFilePath.ToSByte())
            CheckError(QPdfInterop.qpdf_init_write(_qPdfData, outputFilePathBytes));

        MarkDataWritten();
        ApplyWriteOptions(writeOptions);

        CheckError(QPdfInterop.qpdf_write(_qPdfData));
    }

    public ReadOnlySpan<byte> WriteBytes(QPdfWriteOptions? writeOptions = null)
    {
        CheckError(QPdfInterop.qpdf_init_write_memory(_qPdfData));

        MarkDataWritten();
        ApplyWriteOptions(writeOptions);

        CheckError(QPdfInterop.qpdf_write(_qPdfData));

        var buffer = QPdfInterop.qpdf_get_buffer(_qPdfData);
        var bufferLength = QPdfInterop.qpdf_get_buffer_length(_qPdfData);
        CheckError();

        return new ReadOnlySpan<byte>(buffer, (int)bufferLength);
    }

    public Stream WriteStream(QPdfWriteOptions? writeOptions = null)
    {
        CheckError(QPdfInterop.qpdf_init_write_memory(_qPdfData));

        MarkDataWritten();
        ApplyWriteOptions(writeOptions);

        CheckError(QPdfInterop.qpdf_write(_qPdfData));

        var buffer = QPdfInterop.qpdf_get_buffer(_qPdfData);
        var bufferLength = QPdfInterop.qpdf_get_buffer_length(_qPdfData);
        CheckError();

        return _outputStream = new QPdfStream(buffer, (long)bufferLength);
    }

    public string WriteJson(QPdfWriteOptions? writeOptions = null, string[]? wantedObjects = null)
    {
        var sb = new StringBuilder();

        QPdfWriteFunction writeJson = (data, len, _) => {
            sb.Append(new string(data, 0, (int)len));
            return 0;
        };

        WriteJson(writeJson, writeOptions, wantedObjects);

        return sb.ToString();
    }

    public void WriteJsonFile(string outputFilePath, QPdfWriteOptions? writeOptions = null, string[]? wantedObjects = null)
    {
        using var fs = new FileStream(outputFilePath, FileMode.Create, FileAccess.Write, FileShare.None);

        QPdfWriteFunction writeJson = (data, len, _) => {
            using var ums = new UnmanagedMemoryStream((byte*)data, (int)len);
            ums.CopyTo(fs);
            ums.Flush();
            return 0;
        };

        WriteJson(writeJson, writeOptions, wantedObjects);
    }

    private void WriteJson(QPdfWriteFunction writeFunction, QPdfWriteOptions? writeOptions = null, string[]? wantedObjects = null)
    {
        CheckError(QPdfInterop.qpdf_init_write_memory(_qPdfData));

        MarkDataWritten();
        ApplyWriteOptions(writeOptions);

        var wantedObjectsBytes = (wantedObjects ?? [""]).Select(s => Unsafe.As<sbyte[]>(Encoding.UTF8.GetBytes(s))).ToArray();
        var wantedObjectsPins = wantedObjectsBytes.Select(s => GCHandle.Alloc(s, GCHandleType.Pinned)).ToArray();
        var wantedObjectsPtrs = Unsafe.As<sbyte*[]>(wantedObjectsPins.Select(s => s.AddrOfPinnedObject()).ToArray());

        fixed (sbyte** wantedObjectsRootPtr = &wantedObjectsPtrs[0])
        fixed (sbyte* filePrefix = "in-memory".ToSByte())
        {
            try
            {
                CheckError(
                    QPdfInterop.qpdf_write_json(
                        qpdf: _qPdfData,
                        version: 2,
                        fn: writeFunction,
                        udata: null,
                        decode_level: QPdfStreamDecodeLevel.qpdf_dl_all,
                        json_stream_data: QPdfJsonStreamData.qpdf_sj_inline,
                        file_prefix: filePrefix,
                        wanted_objects: wantedObjectsRootPtr
                    )
                );
            }
            finally
            {
                foreach (var pin in wantedObjectsPins)
                    pin.Free();
            }
        }
    }

    public void UpdateFromJsonFile(string filePath)
    {
        fixed (sbyte* filePathBytes = filePath.ToSByte())
            CheckError(QPdfInterop.qpdf_update_from_json_file(_qPdfData, filePathBytes));
    }

    public void UpdateFromJson(string json)
    {
        var jsonSpan = json.ToSByte();
        fixed (sbyte* jsonBytes = jsonSpan)
            CheckError(QPdfInterop.qpdf_update_from_json_data(_qPdfData, jsonBytes, (ulong)jsonSpan.Length));
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

        CheckError();
    }

    private void MarkDataWritten()
    {
        if (_hasWrittenData)
            throw new InvalidOperationException("This QPdf instance has already written data.");

        _hasWrittenData = true;
    }}

// Copyright © Stephen (Sven) Vernyi and Contributors. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

using System.Text;
using System.Text.Json.Serialization;
using System.Text.Json;
using QPdfSharp.Extensions;
using QPdfSharp.Interop;
using QPdfSharp.Options;

namespace QPdfSharp;

public unsafe class QPdfJob : IDisposable
{
    public static readonly string Version = new(QPdfInterop.qpdf_get_qpdf_version());
    
    private readonly QPdfJobHandle* _qPdfJob = QPdfInterop.qpdfjob_init();

    private QPdfLoggerHandle* _qPdfLogger = null;

    private readonly StringBuilder _errorBuilder = new();

    public QPdfJob(string filePath, string outFilePath)
        => InitializeQPdfJob(QPdfJobOptions.CreateWithMaxCompression(filePath, outFilePath));

    ~QPdfJob() => ReleaseUnmanagedResources();

    public void Run()
        => CheckError(QPdfInterop.qpdfjob_run(_qPdfJob));

    private void CheckError(int? errorCode = null)
    {
        if (errorCode == 0)
            return;

        var errorMessage = _errorBuilder.ToString();
        if (string.IsNullOrWhiteSpace(errorMessage))
            return;

        _errorBuilder.Clear();

        throw new QPdfException(errorMessage);
    }

    public void Dispose()
    {
        ReleaseUnmanagedResources();
        GC.SuppressFinalize(this);
    }

    private void ReleaseUnmanagedResources()
    {
        fixed (QPdfLoggerHandle** logHandle = &_qPdfLogger)
            QPdfInterop.qpdflogger_cleanup(logHandle);

        fixed (QPdfJobHandle** jobHandle = &_qPdfJob)
            QPdfInterop.qpdfjob_cleanup(jobHandle);
    }

    private void InitializeQPdfJob(QPdfJobOptions? options)
    {
        QPdfLogFunction writeError = (data, len, _) => {
            _errorBuilder.Append(new string(data, 0, (int)len));
            return 0;
        };
        
        _qPdfLogger = QPdfInterop.qpdflogger_create();
        QPdfInterop.qpdflogger_set_error(_qPdfLogger, QPdfLogDestination.qpdf_log_dest_custom, writeError, null);
        QPdfInterop.qpdfjob_set_logger(_qPdfJob, _qPdfLogger);

        var serializerOptions = new JsonSerializerOptions {
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            Converters = { new JsonStringEnumConverter(JsonNamingPolicy.CamelCase) }
        };
        var json = JsonSerializer.Serialize(options, serializerOptions);
        fixed (sbyte* jsonBytes = json.ToSByte())
            CheckError(QPdfInterop.qpdfjob_initialize_from_json(_qPdfJob, jsonBytes));
    }
}

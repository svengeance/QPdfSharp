// Copyright © Stephen (Sven) Vernyi and Contributors. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

using QPdfSharp.Converters;
using System.Text.Json.Serialization;
using QPdfSharp.Enums;

namespace QPdfSharp.Options;

public sealed class QPdfJobOptions
{
    // qpdf.exe in.pdf out.pdf --compress-streams=y --recompress-flate --compression-level=9 --object-streams=generate --decode-level=generalized --optimize-images
    public string? InputFile { get; set; }
    public string? OutputFile { get; set; }

    [JsonConverter(typeof(QPdfCompressStreamConverter))]
    public QPdfCompressStream? CompressStreams { get; set; }

    [JsonConverter(typeof(NullableIntToStringConverter))]
    public int? CompressionLevel { get; set; }
    public string? RecompressFlate { get; set; }
    public string? OptimizeImages { get; set; }
    //public bool? NormalizeContent { get; set; }
    public QPdfObjectStream? ObjectStreams { get; set; }
    public QPdfStreamDecodeLevel? DecodeLevel { get; set; }

    public static QPdfJobOptions CreateWithMaxCompression(string inputFile, string outputFile)
        => new() {
            InputFile = inputFile,
            OutputFile = outputFile,
            CompressStreams = QPdfCompressStream.Yes,
            CompressionLevel = 9,
            RecompressFlate = "",
            OptimizeImages = "",
            ObjectStreams = QPdfObjectStream.Generate,
            DecodeLevel = QPdfStreamDecodeLevel.Generalized
        };
}

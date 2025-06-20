// Copyright © Stephen (Sven) Vernyi and Contributors. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

using System.Text.Json;
using System.Text.Json.Serialization;
using QPdfSharp.Enums;

namespace QPdfSharp.Converters;

public class QPdfCompressStreamConverter : JsonConverter<QPdfCompressStream>
{
    public override QPdfCompressStream Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        => throw new NotImplementedException();

    public override void Write(Utf8JsonWriter writer, QPdfCompressStream value, JsonSerializerOptions options)
    {
        var result = value switch
        {
            QPdfCompressStream.No => "n",
            QPdfCompressStream.Yes => "y",
            _ => throw new JsonException($"Unknown value enum: {value}")
        };
        writer.WriteStringValue(result);
    }
}

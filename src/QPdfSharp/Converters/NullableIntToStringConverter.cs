// Copyright © Stephen (Sven) Vernyi and Contributors. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

using System.Text.Json;
using System.Text.Json.Serialization;

namespace QPdfSharp.Converters;

public class NullableIntToStringConverter : JsonConverter<int?>
{
    public override int? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        => throw new NotImplementedException();

    public override void Write(Utf8JsonWriter writer, int? value, JsonSerializerOptions options)
    {
        if (value.HasValue)
            writer.WriteStringValue(value.Value.ToString());
    }
}

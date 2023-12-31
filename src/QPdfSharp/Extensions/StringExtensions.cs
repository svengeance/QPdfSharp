// Copyright © Stephen (Sven) Vernyi and Contributors. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

using System.Runtime.CompilerServices;
using System.Text;

namespace QPdfSharp.Extensions;

internal static class StringExtensions
{
    public static ReadOnlySpan<sbyte> ToSByte(this string? str)
    {
        if (str is null)
            return [];

        var bytes = Encoding.UTF8.GetBytes(str);

        return Unsafe.As<sbyte[]>(bytes);
    }
}

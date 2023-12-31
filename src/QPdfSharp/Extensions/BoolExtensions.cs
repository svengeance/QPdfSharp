// Copyright © Stephen (Sven) Vernyi and Contributors. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

namespace QPdfSharp.Extensions;

public static class BoolExtensions
{
    public static int ToQPdfBool(this bool value)
        => value ? 1 : 0;
}

// Copyright © Stephen (Sven) Vernyi and Contributors. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

namespace QPdfSharp.Options;

public sealed class QPdfReadOptions
{
    public bool? AttemptRecovery { get; set; }
    public bool? IgnoreXrefStreams { get; set; }

    public bool IsJsonFormat { get; set; }
}

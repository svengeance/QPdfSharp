// Copyright © Stephen (Sven) Vernyi and Contributors. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

using QPdfSharp.Enums;

namespace QPdfSharp.Options;

public sealed class QPdfWriteOptions
{
    public bool? CompressStreams { get; set; }
    public int? ForcePdfExtensionLevel { get; set; }
    public string? ForcePdfVersion { get; set; }
    public bool? Linearize { get; set; }
    public int? MinimumPdfExtensionLevel { get; set; }
    public bool? NewlineBeforeEndOfStream { get; set; }
    public string? MinimumPdfVersion { get; set; }
    public bool? NormalizeContent { get; set; }
    public bool? PreserveEncryption { get; set; }
    public bool? PreserveUnreferencedObjects { get; set; }
    public QPdfObjectStream? QPdfObjectStreamMode { get; set; }
    public QPdfStreamData? QPdfStreamDataMode { get; set; }
    public QPdfStreamDecodeLevel? QPdfStreamDecodeLevel { get; set; }
    public bool? SuppressOriginalObjectIds { get; set; }
    public bool? UseDeterministicIdGeneration { get; set; }
    public bool? WriteAsQdf { get; set; }
}

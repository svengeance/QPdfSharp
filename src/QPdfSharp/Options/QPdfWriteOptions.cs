// Copyright © Stephen (Sven) Vernyi and Contributors. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

using QPdfSharp.Enums;

namespace QPdfSharp.Options;

public sealed record QPdfWriteOptions(
    bool? CompressStreams,
    int? ForcePdfExtensionLevel,
    string? ForcePdfVersion,
    bool? Linearize,
    int? MinimumPdfExtensionLevel,
    bool? NewlineBeforeEndOfStream,
    string? MinimumPdfVersion,
    bool? NormalizeContent,
    bool? PreserveEncryption,
    bool? PreserveUnreferencedObjects,
    QPdfObjectStream? QPdfObjectStreamMode,
    QPdfStreamData? QPdfStreamDataMode,
    QPdfStreamDecodeLevel? QPdfStreamDecodeLevel,
    bool? SuppressOriginalObjectIds,
    bool? UseDeterministicIdGeneration,
    bool? WriteAsQdf
);

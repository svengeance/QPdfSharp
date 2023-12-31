// Copyright © Stephen (Sven) Vernyi and Contributors. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

namespace QPdfSharp;

public sealed class QPdfStream: UnmanagedMemoryStream
{
    internal bool IsDisposed { get; private set; }

    public unsafe QPdfStream(byte* startPtr, long length) : base(startPtr, length)
    { }

    protected override void Dispose(bool disposing)
    {
        IsDisposed = true;

        base.Dispose(disposing);
    }
}

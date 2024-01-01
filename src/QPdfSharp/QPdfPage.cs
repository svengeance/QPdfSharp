// Copyright © Stephen (Sven) Vernyi and Contributors. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

using QPdfSharp.Interop;

namespace QPdfSharp;

public readonly struct QPdfPage
{
    internal readonly unsafe QPdfData* _qPdfData;

    internal readonly uint _qPdfPageData;

    internal unsafe QPdfPage(QPdfData* qPdfData, uint qPdfPageData)
    {
        _qPdfData = qPdfData;
        _qPdfPageData = qPdfPageData;
    }
}

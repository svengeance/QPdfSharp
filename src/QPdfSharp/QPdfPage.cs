// Copyright © Stephen (Sven) Vernyi and Contributors. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

using QPdfSharp.Interop;

namespace QPdfSharp;

public readonly struct QPdfPage
{
    internal readonly unsafe QPdfData* _qPdfData;

    internal readonly uint _qPdfPage;

    internal unsafe QPdfPage(QPdfData* qPdfData, uint qPdfPage)
    {
        _qPdfData = qPdfData;
        _qPdfPage = qPdfPage;
    }
}

// Copyright © Stephen (Sven) Vernyi and Contributors. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

using QPdfSharp.Extensions;
using QPdfSharp.Interop;

namespace QPdfSharp;

public unsafe partial class QPdf
{
    public int GetPageCount()
    {
        var pageCount = QPdfInterop.qpdf_get_num_pages(_qPdfData);
        CheckError();

        return pageCount;
    }

    public QPdfPage GetPage(int pageNumber)
    {
        var pagePtr = QPdfInterop.qpdf_get_page_n(_qPdfData, (UIntPtr)pageNumber);
        CheckError();

        return new QPdfPage(_qPdfData, pagePtr);
    }

    public QPdfPage GetPageById(int id, int generation)
    {
        var pageIndex = QPdfInterop.qpdf_find_page_by_id(_qPdfData, id, generation);
        CheckError();

        return GetPage(pageIndex);
    }

    public void AppendPage(QPdfPage newPage)
    {
        QPdfInterop.qpdf_add_page(_qPdfData, newPage._qPdfData, newPage._qPdfPage, first: 0);
        CheckError();
    }

    public void PrependPage(QPdfPage newPage)
    {
        QPdfInterop.qpdf_add_page(_qPdfData, newPage._qPdfData, newPage._qPdfPage, first: 1);
        CheckError();
    }

    public void InsertPage(QPdfPage newPage, int insertAt, bool insertBefore = true)
    {
        var numPages = GetPageCount();
        if (insertAt < 0 || insertAt > numPages)
            throw new ArgumentOutOfRangeException(nameof(insertAt), $"Insert index must be between 0 and {numPages} inclusive.");

        var refPage = GetPage(insertAt);
        InsertPage(newPage, refPage, insertBefore);
    }

    public void InsertPage(QPdfPage newPage, QPdfPage targetPage, bool insertBefore = true)
    {
        QPdfInterop.qpdf_add_page_at(_qPdfData, newPage._qPdfData, newPage._qPdfPage, before: insertBefore.ToQPdfBool(), targetPage._qPdfPage);
        CheckError();
    }

    public void RemovePage(int pageNumber)
    {
        var page = GetPage(pageNumber);
        RemovePage(page);
    }

    public void RemovePage(QPdfPage page)
    {
        QPdfInterop.qpdf_remove_page(_qPdfData, page._qPdfPage);
        CheckError();
    }
}

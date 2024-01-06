// Copyright © Stephen (Sven) Vernyi and Contributors. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

using QPdfSharp.Options;

namespace QPdfSharp.Tests;

public class QPdfExamplesTests
{
    [Fact]
    public void Can_read_optimize_write_pdf()
    {
        // Read PDF
        using var qpdf = new QPdf(TestAssets.Grug);

        // Write with optimizations
        qpdf.WriteFile("optimized.pdf", new QPdfWriteOptions
        {
            CompressStreams = true,
            Linearize = true
        });
    }

    [Fact]
    public void Can_add_watermark_page_to_pdf()
    {
        // This watermark could be safely cached in memory with a long-held reference to QPdf.
        using var watermark = new QPdf(TestAssets.QPdfWatermark);
        using var qpdf = new QPdf(TestAssets.Grug);

        // Prepend watermark page
        qpdf.PrependPage(watermark.GetPage(0));

        // Write PDF
        qpdf.WriteFile("watermarked.pdf");
    }
}

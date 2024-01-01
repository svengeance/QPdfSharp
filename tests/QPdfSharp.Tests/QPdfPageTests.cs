// Copyright © Stephen (Sven) Vernyi and Contributors. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

namespace QPdfSharp.Tests;

public class QPdfPageTests
{
    [Fact]
    public void Can_get_page_count()
    {
        // Arrange
        using var qpdf = new QPdf(TestAssets.Grug);

        // Act
        var numPages = qpdf.GetPageCount();

        // Assert
        numPages.Should().Be(19);
    }

    [Fact]
    public void Can_get_page_by_number()
    {
        // Arrange
        using var qpdf = new QPdf(TestAssets.Grug);

        // Act
        var getPage = () => qpdf.GetPage(0);

        // Assert
        getPage.Should().NotThrow();
    }

    [Fact]
    public void Can_append_page()
    {
        // Arrange
        using var qpdf = new QPdf(TestAssets.Grug);
        var numPages = qpdf.GetPageCount();
        var newPage = qpdf.GetPage(0);

        // Act
        qpdf.AppendPage(newPage);

        // Assert
        qpdf.GetPageCount().Should().Be(numPages + 1);
    }

    [Fact]
    public void Can_prepend_page()
    {
        // Arrange
        using var qpdf = new QPdf(TestAssets.Grug);
        var numPages = qpdf.GetPageCount();
        var newPage = qpdf.GetPage(0);

        // Act
        qpdf.PrependPage(newPage);

        // Assert
        qpdf.GetPageCount().Should().Be(numPages + 1);
    }

    [Fact]
    public void Can_insert_page()
    {
        // Arrange
        using var qpdf = new QPdf(TestAssets.Grug);
        var numPages = qpdf.GetPageCount();
        var newPage = qpdf.GetPage(0);

        // Act
        qpdf.InsertPage(newPage, 1, insertBefore: false);

        // Assert
        qpdf.GetPageCount().Should().Be(numPages + 1);
    }

    [Fact]
    public void Can_remove_page_by_page()
    {
        // Arrange
        using var qpdf = new QPdf(TestAssets.Grug);
        var numPages = qpdf.GetPageCount();
        var pageToRemove = qpdf.GetPage(0);

        // Act
        qpdf.RemovePage(pageToRemove);

        // Assert
        qpdf.GetPageCount().Should().Be(numPages - 1);
    }

    [Fact]
    public void Can_remove_page_by_index()
    {
        // Arrange
        using var qpdf = new QPdf(TestAssets.Grug);
        var numPages = qpdf.GetPageCount();

        // Act
        qpdf.RemovePage(0);

        // Assert
        qpdf.GetPageCount().Should().Be(numPages - 1);
        qpdf.WriteFile("out.pdf");
    }
}

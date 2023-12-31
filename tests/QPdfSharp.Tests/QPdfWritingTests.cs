// Copyright © Stephen (Sven) Vernyi and Contributors. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

namespace QPdfSharp.Tests;

public class QPdfWritingTests
{
    [Fact]
    public async Task Can_write_pdf_file()
    {
        // Arrange
        var outputFileName = "qgrug.pdf";

        using var qpdf = new QPdf(TestAssets.Grug);

        // Act
        qpdf.WriteFile(outputFileName);

        // Assert
        File.Exists(outputFileName).Should().BeTrue();
        (await File.ReadAllBytesAsync(outputFileName)).Should().NotBeEmpty();
        File.Delete(outputFileName);
    }

    [Fact]
    public void Can_write_pdf_bytes()
    {
        // Arrange
        using var qpdf = new QPdf(TestAssets.Grug);

        // Act
        var getPdfBytes = qpdf.WriteBytes().ToArray();

        // Assert
        getPdfBytes.Should().NotBeEmpty();
    }

    [Fact]
    public void Can_write_pdf_stream()
    {
        // Arrange
        using var qpdf = new QPdf(TestAssets.Grug);

        // Act
        using var pdfStream  = qpdf.WriteStream();

        // Assert
        pdfStream.Should().NotHaveLength(0);
        pdfStream.Should().BeReadOnly();
    }

    [Fact]
    public void Throws_on_consecutive_writes_to_stream()
    {
        // Arrange
        using var qpdf = new QPdf(TestAssets.Grug);

        _ = qpdf.WriteBytes();

        // Act
        var writeAgain = () => qpdf.WriteStream();

        // Assert
        writeAgain.Should().Throw<InvalidOperationException>();
    }

    [Fact]
    public void Throws_on_consecutive_writes_to_bytes()
    {
        // Arrange
        using var qpdf = new QPdf(TestAssets.Grug);

        _ = qpdf.WriteBytes();

        // Act
        var writeAgain = () => qpdf.WriteBytes().ToArray();

        // Assert
        writeAgain.Should().Throw<InvalidOperationException>();
    }

    [Fact]
    public void Throws_on_consecutive_writes_to_file()
    {
        // Arrange
        var outputFileName = "qgrug.pdf";

        using var qpdf = new QPdf(TestAssets.Grug);
        qpdf.WriteFile(outputFileName);

        // Act
        var writeAgain = () => qpdf.WriteFile(outputFileName);

        // Assert
        writeAgain.Should().Throw<InvalidOperationException>();
        File.Delete(outputFileName);
    }
}

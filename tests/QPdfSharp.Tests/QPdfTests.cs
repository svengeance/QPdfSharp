namespace QPdfSharp.Tests;

public class QPdfTests
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
    public void Can_read_qpdf_version()
    {
        // Arrange
        // Act
        var version = QPdf.Version;

        // Assert
        Version.TryParse(version, out _).Should().BeTrue();
    }

    [Fact]
    public void Can_read_pdf_from_file_path()
    {
        // Arrange
        var fileName = TestAssets.Grug;

        // Act
        var createPdfFromFile = () => new QPdf(fileName);

        // Assert
        createPdfFromFile.Should().NotThrow();
    }

    [Fact]
    public async Task Can_read_pdf_from_memory()
    {
        // Arrange
        var fileName = TestAssets.Grug;
        var fileBytes = await File.ReadAllBytesAsync(fileName);

        // Act
        var createPdfFromBytes = () => new QPdf(fileBytes);

        // Assert
        createPdfFromBytes.Should().NotThrow();
    }

    [Fact]
    public async Task Can_write_pdf_file()
    {
        // Arrange
        var outputFileName = "qgrug.pdf";

        // Act
        var qpdf = new QPdf(TestAssets.Grug);
        qpdf.WriteFile(outputFileName);
        qpdf.Dispose();

        // Assert
        File.Exists(outputFileName).Should().BeTrue();
        (await File.ReadAllBytesAsync(outputFileName)).Should().NotBeEmpty();
        File.Delete(outputFileName);
    }

    [Fact]
    public void Can_write_pdf_bytes()
    {
        // Arrange
        // Act
        using var qpdf = new QPdf(TestAssets.Grug);
        var getPdfBytes = qpdf.WriteBytes().ToArray();

        // Assert
        getPdfBytes.Should().NotBeEmpty();
    }

    [Fact]
    public void Can_write_pdf_stream()
    {
        // Arrange
        // Act
        using var qpdf = new QPdf(TestAssets.Grug);
        var pdfStream  = qpdf.WriteStream();

        // Assert
        pdfStream.Should().NotHaveLength(0);
        pdfStream.Should().BeReadOnly();
    }
}


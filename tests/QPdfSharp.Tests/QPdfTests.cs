namespace QPdfSharp.Tests;

public class QPdfTests
{
    [Fact]
    public void Can_get_page_count()
    {
        // Arrange
        using var qpdf = new QPdf("Assets/grug.pdf");

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
        var getVersion = () => QPdf.Version;

        // Assert
        var version = getVersion.Should().NotThrow().Subject;
        Version.TryParse(version, out _).Should().BeTrue();
    }

    [Fact]
    public void Can_read_pdf_from_file_path()
    {
        // Arrange
        var fileName = "Assets/grug.pdf";

        // Act
        var createPdfFromFile = () => new QPdf(fileName);

        // Assert
        createPdfFromFile.Should().NotThrow();
    }

    [Fact]
    public async Task Can_read_pdf_from_memory()
    {
        // Arrange
        var fileName = "Assets/grug.pdf";
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
        var qpdf = new QPdf("Assets/grug.pdf");
        qpdf.WriteFile(outputFileName);
        qpdf.Dispose();

        // Assert
        File.Exists(outputFileName).Should().BeTrue();
        (await File.ReadAllBytesAsync(outputFileName)).Should().NotBeEmpty();
        File.Delete(outputFileName);
    }

    [Fact]
    public async Task Can_write_pdf_bytes()
    {
        // Arrange
        var existingBytes = await File.ReadAllBytesAsync("Assets/grug.pdf");

        // Act
        using var qpdf = new QPdf("Assets/grug.pdf");
        var getPdfBytes = () => qpdf.WriteBytes().ToArray();

        // Assert
        getPdfBytes.Should().NotThrow().Subject.Should().NotBeEmpty();
    }

    [Fact]
    public async Task Can_write_pdf_stream()
    {
        // Arrange
        var existingBytes = await File.ReadAllBytesAsync("Assets/grug.pdf");

        // Act
        using var qpdf = new QPdf("Assets/grug.pdf");
        var getPdfStream = () => qpdf.WriteStream();

        // Assert
        var pdfStream = getPdfStream.Should().NotThrow().Subject;
        pdfStream.Should().NotHaveLength(0);
        pdfStream.Should().BeReadOnly();
    }
}


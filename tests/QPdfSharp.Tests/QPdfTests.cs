namespace QPdfSharp.Tests;

public class QPdfTests
{
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
        var createQPdfFromFile = () => new QPdf(fileName);

        // Assert
        createQPdfFromFile.Should().NotThrow();
    }

    [Fact]
    public async Task Can_read_pdf_from_memory()
    {
        // Arrange
        var fileName = "Assets/grug.pdf";
        var fileBytes = await File.ReadAllBytesAsync(fileName);

        // Act
        var createQPdfFromBytes = () => new QPdf(fileBytes);

        // Assert
        createQPdfFromBytes.Should().NotThrow();
    }

    [Fact]
    public void Can_write_pdf_file()
    {
        // Arrange
        var outputFileName = "qgrug.pdf";

        // Act
        using var grugQpdf = new QPdf("Assets/grug.pdf");
        grugQpdf.WriteFile(outputFileName);

        // Assert
        File.Exists(outputFileName).Should().BeTrue();
        File.Delete(outputFileName);
    }

    [Fact]
    public async Task Can_write_pdf_bytes()
    {
        // Arrange
        var existingBytes = await File.ReadAllBytesAsync("Assets/grug.pdf");

        // Act
        using var grugQpdf = new QPdf("Assets/grug.pdf");
        var getPdfBytes = () => grugQpdf.WriteBytes().ToArray();

        // Assert
        getPdfBytes.Should().NotThrow();
    }
}


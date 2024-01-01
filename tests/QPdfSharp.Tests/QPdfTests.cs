namespace QPdfSharp.Tests;

public class QPdfTests
{
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
}


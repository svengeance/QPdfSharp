using QPdfSharp.Options;

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

    [Theory]
    [InlineData(TestAssets.Grug)]
    [InlineData(TestAssets.GrugJson)]
    public void Can_read_pdf_from_file_path(string filePath)
    {
        // Arrange
        var readOptions = new QPdfReadOptions { IsJsonFormat = filePath.EndsWith(".json") };

        // Act
        var createPdfFromFile = () => new QPdf(filePath, readOptions: readOptions);

        // Assert
        createPdfFromFile.Should().NotThrow();
    }

    [Theory]
    [InlineData(TestAssets.Grug)]
    [InlineData(TestAssets.GrugJson)]
    public async Task Can_read_pdf_from_memory(string filePath)
    {
        // Arrange
        var readOptions = new QPdfReadOptions { IsJsonFormat = filePath.EndsWith(".json") };
        var fileBytes = await File.ReadAllBytesAsync(filePath);

        // Act
        var createPdfFromBytes = () => new QPdf(fileBytes, readOptions: readOptions);

        // Assert
        createPdfFromBytes.Should().NotThrow();
    }
}


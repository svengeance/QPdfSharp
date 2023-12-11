namespace QPdfSharp.Tests;

public class QPdfTests
{
    [Fact]
    public void Can_read_pdf_from_file_path()
    {
        // Arrange
        var fileName = "Assets/grug.pdf";

        // Act
        var createQPdfFromFile = () => new QPdf(fileName);

        // Assert
        _ = createQPdfFromFile.ShouldNotThrow();
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
        _ = createQPdfFromBytes.ShouldNotThrow();
    }
}

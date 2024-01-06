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
    public void Can_write_pdf_json()
    {
        // Arrange
        using var qpdf = new QPdf(TestAssets.Grug);

        // Act
        var pdfJson = qpdf.WriteJson();

        // Assert
        pdfJson.Should().NotBeEmpty();
    }

    [Fact]
    public void Can_write_pdf_json_with_specific_object_key()
    {
        // Arrange
        using var qpdf = new QPdf(TestAssets.Grug);
        var objectKey = "obj:94 0 R"; // Corresponds to Title

        // Act
        var pdfJson = qpdf.WriteJson(wantedObjects: [objectKey]);

        // Assert
        pdfJson.Should().NotBeEmpty();
    }


    [Fact]
    public void Can_write_pdf_json_file()
    {
        // Arrange
        using var qpdf = new QPdf(TestAssets.Grug);

        // Act
        qpdf.WriteJsonFile("out.json");

        // Assert
        var json = File.ReadAllText("out.json");
        json.Should().NotBeEmpty();
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
    }

    [Fact]
    public void Throws_on_consecutive_writes_to_json()
    {
        // Arrange
        using var qpdf = new QPdf(TestAssets.Grug);

        _ = qpdf.WriteJson();

        // Act
        var writeAgain = () => qpdf.WriteJson();

        // Assert
        writeAgain.Should().Throw<InvalidOperationException>();
    }

    [Fact]
    public void Throws_on_consecutive_writes_to_json_file()
    {
        // Arrange
        using var qpdf = new QPdf(TestAssets.Grug);

        qpdf.WriteJsonFile("out.json");

        // Act
        var writeAgain = () => qpdf.WriteJsonFile("out.json");

        // Assert
        writeAgain.Should().Throw<InvalidOperationException>();
    }

    [Fact]
    public void Can_update_from_json_string()
    {
        // Arrange
        using var qpdf = new QPdf(TestAssets.Grug);
        var titleKey = "obj:94 0 R"; // Corresponds to Title
        var updatedTitle = "Grug Brained Developer (Updated)";
        var titleJson = qpdf.WriteJson(wantedObjects: [titleKey]).Replace("Grug Brained Developer", updatedTitle);

        // Act
        using var qpdfToUpdate = new QPdf(TestAssets.Grug);
        qpdfToUpdate.UpdateFromJson(titleJson);

        // Assert
        qpdfToUpdate.GetPageCount().Should().Be(19);
        qpdfToUpdate.WriteJson(wantedObjects: [titleKey]).Should().Contain(updatedTitle);
    }

    [Fact]
    public void Can_update_from_json_file()
    {
        // Arrange
        using var qpdf = new QPdf(TestAssets.Grug);
        var titleKey = "obj:94 0 R"; // Corresponds to Title
        var updatedTitle = "Grug Brained Developer (Updated)";
        var jsonFileName = $"{nameof(Can_update_from_json_file)}.json";
        File.WriteAllText(jsonFileName, qpdf.WriteJson(wantedObjects: [titleKey]).Replace("Grug Brained Developer", updatedTitle));

        // Act
        using var qpdfToUpdate = new QPdf(TestAssets.Grug);
        qpdfToUpdate.UpdateFromJsonFile(jsonFileName);

        // Assert
        qpdfToUpdate.GetPageCount().Should().Be(19);
        qpdfToUpdate.WriteJson(wantedObjects: [titleKey]).Should().Contain(updatedTitle);
    }
}

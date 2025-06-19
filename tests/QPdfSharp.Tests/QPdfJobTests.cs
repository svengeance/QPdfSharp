// Copyright © Stephen (Sven) Vernyi and Contributors. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

namespace QPdfSharp.Tests;

public class QPdfJobTests
{
    [Fact]
    public void Can_read_qpdf_version()
    {
        // Arrange
        // Act
        var version = QPdfJob.Version;

        // Assert
        Version.TryParse(version, out _).Should().BeTrue();
    }

    [Theory]
    [InlineData(TestAssets.Grug)]
    public void Can_compress_pdf_from_file_path(string filePath)
    {
        // Arrange
        var outputFileName = "small.pdf";

        // Act
        var run = () => {
            using var qPdfJob = new QPdfJob(filePath, outputFileName);
            qPdfJob.Run();
        };

        // Assert
        run.Should().NotThrow();
        File.Exists(outputFileName).Should().BeTrue();
        new FileInfo(outputFileName).Length.Should().BeLessThan(new FileInfo(filePath).Length);
        File.Delete(outputFileName);
    }

    [Theory]
    [InlineData("abc.pdf")]
    [InlineData("Assets/abc.pdf")]
    public void Should_throw_exception_if_file_not_found(string filePath)
    {
        // Arrange
        var outputFileName = "small.pdf";

        // Act
        var run = () => {
            using var qPdfJob = new QPdfJob(filePath, outputFileName);
            qPdfJob.Run();
        };

        // Assert
        run.Should().Throw<QPdfException>($"qpdfjob json: open {filePath}: No such file or directory");
    }
}

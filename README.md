![QPdfSharp_DotNetBot.png](assets/QPdfSharp_DotNetBot.png)

# QPdfSharp
A C# wrapper written around QPdf to allow for easy PDF manipulation that is tested for both linux and windows. Please read the usage notes below, and see the below excerpt for a summary on QPdf: for further details, [consult the qpdf repository](https://github.com/qpdf/qpdf/).

> QPdf is a command-line tool and C++ library that performs content-preserving transformations on PDF files. It supports linearization, encryption, and numerous other features. It can also be used for splitting and merging files, creating PDF files (but you have to supply all the content yourself), and inspecting files for study or analysis. QPdf does not render PDFs or perform text extraction, and it does not contain higher-level interfaces for working with page contents. It is a low-level tool for working with the structure of PDF files and can be a valuable tool for anyone who wants to do programmatic or command-line-based manipulation of PDF files.
>
> The QPdf Manual is hosted online at https://qpdf.readthedocs.io. The project website is https://qpdf.sourceforge.io. The source code repository is hosted at GitHub: https://github.com/qpdf/qpdf.

## Status
This project is currently considered stable and ready for use: it supports basic manipulation of PDF files via one portion of the underlying QPdf library, including:
- Reading files from disk/memory with or without passwords
- Reading/writing PDF from/to JSON, and updating PDF from JSON
- Manipulating PDF pages (add/remove) and splicing/merging PDFs
- Various document optimizations (compression, linearization, removing unused objects)

Over the next while v2 will be in development, supporting the QPdf jobs API and [many more PDF operations](https://qpdf.readthedocs.io/en/stable/qpdf-job.html). Stay tuned!

## Roadmap

- **v1**: ~~Fully implement QPdf object handling~~.
- **v1.x**: Documentation, optimizations, and any non-breaking expansions to the API that help facilitate usage of QPdf.
- **v2**: Implement QPdf job handling.
- **v2.x**: Maintenance, compatibility, optimizations. This library should sufficiently wrap QPdf.

## Installation
QPdfSharp is available [as a NuGet package](https://www.nuget.org/packages/QPdfSharp/). Installing QPdfSharp will include the necessary libraries for your platform.

Via CLI:
`dotnet add package QPdfSharp`

## Usage
QPdfSharp aims to facilitate usage of the underlying QPdf library by providing a simple, easy-to-use API that is familiar to .NET developers. You can find plenty of usage examples [in the tests folder](https://github.com/svengeance/QPdfSharp/tree/main/tests/QPdfSharp.Tests).

### Important Usage Notes
The QPdf object is your central point of interaction for using this library, and has a few important notes:
- It is **not** thread-safe. You should not share a QPdf object across threads.
- It is Disposable, and should be disposed of when you are done with it.
- The underlying library [does not make guarantees about multiple write operations](https://github.com/qpdf/qpdf/issues/512); QPdfSharp follows suit by allowing only one write operation per QPdf object.

### Examples

#### Read - Optimize - Write
```cs
// Read PDF
using var qpdf = new QPdf(TestAssets.Grug);

// Write with optimizations
qpdf.WriteFile("optimized.pdf", new QPdfWriteOptions
{
    CompressStreams = true,
    Linearize = true
});
```

#### Read - Prepend Watermark Page - Write to Network
```cs
// This watermark could be safely cached in memory with a long-held reference to QPdf.
using var watermark = new QPdf(TestAssets.QPdfWatermark);
using var qpdf = new QPdf(TestAssets.Grug);

// Prepend watermark page
qpdf.PrependPage(watermark.GetPage(0));

// Write PDF to a stream and upload it
using var qpdfStream = qpdf.WriteStream();
var client = new HttpClient();
await client.PostAsync("https://example.com", new StreamContent(qpdfStream));
```

### Exception Handling
Every call to the underlying library includes a check to see if an error was returned. Errors forwarded from QPdf are thrown as `QPdfExceptions`, while managed code will throw typical BCL exceptions as needed.

### Async?
You may notice QPdfsharp does not utilize async operations (e.g. reading a file from disk in the QPdf constructor).
The QPdf library does as little as it needs to when manipulating PDFs, and may not need the entire contents of the passed-in PDF.
Passing in whole binary buffers to the library also necessitates a copy, which is not ideal for memory.

## Runtime Libraries
QPdfSharp depends on the [QPdf.RuntimeLibraries](https://www.nuget.org/packages/QPdf.RuntimeLibraries) to distribute the appropriate QPdf binaries for your platform.
Those interested in using these binaries without this library are free to do so.

The runtime libraries are checked daily for updates to QPdf; at this time QPdfSharp will manually update to the latest NuGet distribution of the libraries.

# Building and Testing

## Prerequisites
- .NET Core 8.0 SDK
- Visual Studio or Rider
- Docker (to generate interop files, if desired)
- Bash (to build NuGet package, if desired)

At present the project is simply built and ran with Rider, and no tertiary scripts are provided.
No complex deviations are expected, and the project should always be in a state where it can be pulled and built with no unusual setup.
If this is not the case, please open an issue and do not be afraid to roast me.

## From-Scratch Process
1: Clone the repository

2: Run `scripts/generate-interop.sh`. This will use CLangSharpPInvokeGenerator to generate the C# interop files.

3: Run `scripts/build-runtime-libraries-nuget.sh`. This will output a NuGet package with the latest QPdf binaries under `artifacts/QPdf.RuntimeLibraries.<version>.nupkg`.

4: Launch the repository in your IDE of choice, and verify tests pass.

# License
This project is licensed under the MIT license. See the [LICENSE](LICENSE) file for more details.

# Contributing
QPdfSharp is open to contributions to improve the library and its documentation.
I kindly ask for an issue to be opened before a pull request is made, so that we can discuss the proposed changes.

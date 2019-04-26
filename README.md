| CI            | Download    |
| ------------- |-------------|
[![Build status](https://ci.appveyor.com/api/projects/status/s99yd6ifgb4j8h11/branch/master?svg=true)](https://ci.appveyor.com/project/ShyRed/fastwfcnet/branch/master) [![Build Status](https://travis-ci.com/ShyRed/fastwfcnet.svg?branch=master)](https://travis-ci.com/ShyRed/fastwfcnet) | [![NuGet](https://img.shields.io/nuget/v/fastwfcnet.svg)](https://www.nuget.org/packages/FastWfcNet)

FastWfcNet is a library that generates 2D output data that is locally similar to the 2D input data. This implementation is a port of the [fast-wcf](https://github.com/math-fehr/fast-wfc) library to C# .NET. Several modifications have been made to use C# / .NET features where possible.

## Highlights
- .NET Standard 2.0 library with no dependencies
- Simple WinForms Demo Application (visit [mxgmn's repository](https://github.com/mxgmn/WaveFunctionCollapse/tree/master) for example images / tilemaps)

## Features
- 2D Overlapping model with improved floor pattern detection
- 2D Tiling model with support for tiles that have no symmetry
- Fully documented codebase

## The Demo Application
The demo application allows you to try out the algorithm and get a feeling for what the different options do. The application's source code deals with handling bitmap images and as such can be used as a reference point when using the library to work with bitmap images.

![Screenshot of Demo Application](https://github.com/ShyRed/fastwfcnet/blob/master/screenshot.jpg)

## How To Use The Library
The following example is taken from the demo application's source code and shows how a bitmap that is locally similar to the input bitmap can be generated.
```C#
/// <summary>
/// Runs WFC with overlapping model in a thread creating a <see cref="Bitmap"/> that is based
/// on the specified input.
/// </summary>
/// <param name="inputBitmap">The input image.</param>
/// <param name="options">The overlapping model options.</param>
/// <param name="seed">The seed for the random number generator.</param>
/// <returns>The resulting image or <c>null</c>.</returns>
private static Task<Bitmap> RunWfcAsync(Bitmap inputBitmap, OverlappingWfcOptions options, int seed)
{
    return Task.Run<Bitmap>(() =>
    {
        // Fetch the pixels from the input image (convert Colors to ARGB for speed) and store them
        // in an Array2D.
        var inputColors = new Array2D<int>((uint)inputBitmap.Height, (uint)inputBitmap.Width);
        for (uint x = 0; x < inputColors.Width; x++)
            for (uint y = 0; y < inputColors.Height; y++)
                inputColors[y, x] = inputBitmap.GetPixel((int)x, (int)y).ToArgb();

        // Create WFC overlapping model instance with the created array, the options and the seed
        // for the random number generator.
        var wfc = new OverlappingWfc<int>(inputColors, options, seed);

        // Run the WFC algorithm. The result is an Array2D with the result pixels/colors. Return value
        // is null, if the WFC failed to create a solution without contradictions. In this case one
        // should change the settings or try again with a different seed for the random number generator.
        var result = wfc.Run();

        // Failed...
        if (result == null)
            return null;

        // Success: extract pixels/colors and put them into an image.
        var resultBitmap = new Bitmap((int)result.Width, (int)result.Height);
        for (uint x = 0; x < result.Width; x++)
            for (uint y = 0; y < result.Height; y++)
                resultBitmap.SetPixel((int)x, (int)y, Color.FromArgb(result[y, x]));

        return resultBitmap;
    });
}
```

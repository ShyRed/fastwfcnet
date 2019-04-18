[![Build status](https://ci.appveyor.com/api/projects/status/s99yd6ifgb4j8h11/branch/master?svg=true)](https://ci.appveyor.com/project/ShyRed/fastwfcnet/branch/master)
[![Build Status](https://travis-ci.com/ShyRed/fastwfcnet.svg?branch=master)](https://travis-ci.com/ShyRed/fastwfcnet)

# FastWfcNet
WaveFunctionCollapse in C# .Net

This is a port of [fast-wcf](https://github.com/math-fehr/fast-wfc) from C++ to C#:

- Contains .NET Standard 2.0 library
- Contains simple WinForms Demo Application (see [original repository](https://github.com/mxgmn/WaveFunctionCollapse/tree/master) for example images)

Please note that the API is still work in progress.

## The Demo Application
![Screenshot of Demo Application](https://github.com/ShyRed/fastwfcnet/blob/master/screenshot.jpg)

## How To Use The Library
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
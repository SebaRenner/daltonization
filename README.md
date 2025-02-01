# Daltonization
Daltonization is a process designed to make images more accessible to individuals with color vision deficiencies, particularly those with red-green color blindness. It involves modifying the colors in an image to improve the differentiation between hues that are typically hard to distinguish for those affected by color blindness. This is achieved by adjusting the colors' brightness and saturation to create contrast while maintaining the overall appearance of the image for people with normal color vision.

Original:
![Original Ishihara Image](/.images/ishihara.jpg)

For Deuteranopia corrected image:
![Daltonized Image](/.images/daltonized_image.jpg)

## Implementation details
The project replaces `System.Drawing.Common` with [ImageSharp](https://github.com/SixLabors/ImageSharp) for cross-platform compatibility, as `System.Drawing.Common` is now Windows-only in .NET 6+ and raises compatibility warnings. ImageSharp offers a modern, efficient API for image processing without native dependencies, making it ideal for pixel-level operations like color correction.
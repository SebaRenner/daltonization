using System.Diagnostics;

using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats.Jpeg;
using SixLabors.ImageSharp.PixelFormats;

using Daltonization.Core;

var filepath = "../../../../.images/ishihara.jpg";
var image = Image.Load<Rgba32>(filepath);

var correctedImage = ImageProcessor.DaltonizeImage(image, ColorBlindnessType.Deuteranopia);

correctedImage.Save("daltonized_image.jpg", new JpegEncoder());

Console.WriteLine("Daltonization finished");

Process.Start(new ProcessStartInfo("daltonized_image.jpg") { UseShellExecute = true });
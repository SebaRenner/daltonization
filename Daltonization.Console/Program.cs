using System.Diagnostics;

using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats.Jpeg;
using SixLabors.ImageSharp.PixelFormats;

using Daltonization.Core;

var filepath = "../../../Ishihara.jpg";
var image = Image.Load<Rgba32>(filepath);

var correctedImage = ImageProcessor.DaltonizeImage(image, ColorBlindnessType.Protanopia);

correctedImage.Save("daltonized_image.jpg", new JpegEncoder());

Console.WriteLine("Daltonization finished");

Process.Start(new ProcessStartInfo("daltonized_image.jpg") { UseShellExecute = true });
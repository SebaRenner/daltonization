using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;

using Daltonization.Core;

var filepath = "../../../Ishihara.jpg";
var bitmap = new Bitmap(filepath);

var correctedImage = FrameProcessor.DaltonizeFrame(bitmap, ColorBlindnessType.Protanopia);

correctedImage.Save("daltonized_image.jpg", ImageFormat.Jpeg);

Console.WriteLine("Daltonization finished");

Process.Start(new ProcessStartInfo("daltonized_image.jpg") { UseShellExecute = true });
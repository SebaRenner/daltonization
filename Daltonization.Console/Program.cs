using System.Drawing;
using System.Drawing.Imaging;

using Daltonization.Core;

var filepath = "../../../Ishihara.jpg";
var bitmap = new Bitmap(filepath);

var daltonizedImage = new Bitmap(bitmap.Width, bitmap.Height);

for (int y = 0; y < bitmap.Height; y++)
{
    for (int x = 0; x < bitmap.Width; x++)
    {
        Color pixel = bitmap.GetPixel(x, y);

        // Step 1: Convert RGB to LMS
        var lms = LMS.FromColor(pixel);

        // Step 2: Simulate CVD
        var lmsSim = Simulator.SimulateColorBlindness(lms.Value, ColorBlindnessType.Deuteranopia);

        // Step 3: Compute Error
        var error = new double[lmsSim.Length];

        for (int i = 0; i < error.Length; i++)
        {
            error[i] = lms.Value[i] - lmsSim[i];
        }

        // Step 4: Apply Correction
        var correctedLms = new double[lmsSim.Length];

        for (int i = 0; i < error.Length; i++)
        {
            correctedLms[i] = lmsSim[i] - error[i];
        }

        // Step 5: Convert back to RGB
        var correctedRgb = LMS.FromDoubleArr(correctedLms).ToRGB();

        daltonizedImage.SetPixel(x, y, correctedRgb);
    }
}

daltonizedImage.Save("daltonized_image.jpg", ImageFormat.Jpeg);

Console.WriteLine("Daltonization finished");
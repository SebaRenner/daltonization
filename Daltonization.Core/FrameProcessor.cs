using System.Drawing;

namespace Daltonization.Core;

public static class FrameProcessor
{
    public static Bitmap DaltonizeFrame(Bitmap original, ColorBlindnessType colorBlindnessType)
    {
        var daltonizedImage = new Bitmap(original.Width, original.Height);

        for (int y = 0; y < original.Height; y++)
        {
            for (int x = 0; x < original.Width; x++)
            {
                Color pixel = original.GetPixel(x, y);

                // Step 1: Convert RGB to LMS
                var lms = LMS.FromColor(pixel);

                // Step 2: Simulate CVD
                var lmsSim = Simulator.SimulateColorBlindness(lms.Value, colorBlindnessType);

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

        return daltonizedImage;
    }
}

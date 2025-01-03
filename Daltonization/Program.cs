using System.Drawing;

using Daltonization.Core;

// Read image as bitmap and iterate over each pixel

var color = Color.FromArgb(255, 200, 100);

// Step 1: Convert RGB to LMS
var lms = LMS.FromColor(color);

// Step 2: Simulate CVD
var lmsSim = Simulator.SimulateColorBlindness(lms.Value, ColorBlindnessType.Protanopia);

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

Console.WriteLine(lms.ToString());
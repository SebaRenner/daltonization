namespace Daltonization.Core;

public static class Simulator
{
    public static double[] SimulateColorBlindness(double[] lms, ColorBlindnessType colorBlindnessType)
    {
        var cbMatrix = GetMatrixByType(colorBlindnessType);

        var lmsSim = Matrix.Multiply(cbMatrix, lms);

        return lmsSim;
    }

    private static double[,] GetMatrixByType(ColorBlindnessType type)
    {
        return type switch
        {
            ColorBlindnessType.Protanopia => new double[,] {
                { 0, 1.05118294, -0.05116099 },
                { 0, 1, 0 },
                { 0, 0, 1 }
            },
            ColorBlindnessType.Deuteranopia => new double[,] {
                { 1, 0, 0 },
                { 0.9513092, 0, 0.04866992 },
                { 0, 0, 1 }
            },
            ColorBlindnessType.Tritanopia => new double[,] {
                { 1, 0, 0 },
                { 0, 1, 0 },
                { -0.86744736, 1.86727089, 0 }
            },
            _ => throw new ArgumentException(nameof(type)),
        };
    }
}

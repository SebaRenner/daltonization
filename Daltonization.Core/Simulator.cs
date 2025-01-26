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
            ColorBlindnessType.Protanopia => TransformationMatrices.Protanopia,
            ColorBlindnessType.Deuteranopia => TransformationMatrices.Deuteranopia,
            ColorBlindnessType.Tritanopia => TransformationMatrices.Tritanopia,
            _ => throw new ArgumentException(nameof(type)),
        };
    }
}

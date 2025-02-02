namespace Daltonization.Core;

public static class TransformationMatrices
{
    public static readonly double[,] Bradford = new double[,]
    {
        { 0.8951, 0.2664, -0.1614 },
        { -0.7502, 1.7135, 0.0367 },
        { 0.0389, -0.0685, 1.0296 }
    };

    public static readonly double[,] BradfordInverse = new double[,]
    {
        { 0.9869929, -0.1470543, 0.1599627 },
        { 0.4323053, 0.5183603, 0.0492912 },
        { -0.0085287, 0.0400428, 0.9684867 }
    };

    public static readonly double[,] VonKries = new double[,]
{
        { 0.40024, 0.70760, -0.08081 },
        { -0.22630, 1.16532, 0.04570 },
        { 0.00000, 0.00000, 0.91822 }
};

    public static readonly double[,] VonKriesInverse = new double[,]
    {
        { 1.8599364, -1.1293816, 0.2198974 },
        { 0.3611914, 0.6388125, -0.0000064 },
        { 0.00000, 0.00000, 1.0890636 }
    };

    public static readonly double[,] Protanopia = new double[,]
    {
        { 0, 1.05118294, -0.05116099 },
        { 0, 1, 0 },
        { 0, 0, 1 }
    };

    public static readonly double[,] Deuteranopia = new double[,]
    {
        { 1, 0, 0 },
        { 0.9513092, 0, 0.04866992 },
        { 0, 0, 1 }
    };

    public static readonly double[,] Tritanopia = new double[,]
    {
        { 1, 0, 0 },
        { 0, 1, 0 },
        { -0.86744736, 1.86727089, 0 }
    };
}

namespace Daltonization.Core;

public static class Matrix
{
    public static double[] Multiply(double[,] matrixA, double[] vector)
    {
        // TODO: Add invarient check matrix rows match vector length

        var result = new double[matrixA.GetLength(0)];

        for (int i = 0; i < result.Length; i++)
        {
            double sum = 0;
            for (int j = 0; j < vector.Length; j++)
            {
                sum += matrixA[i, j] * vector[j];
            }
            result[i] = sum;
        }

        return result;
    }

    public static double[,] Multiply(double[,] matrixA, double[,] matrixB)
    {
        throw new NotImplementedException();
    }
}

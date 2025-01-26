namespace Daltonization.Core;

public static class Matrix
{
    public static double[] Multiply(double[,] matrix, double[] vector)
    {
        if (matrix.GetLength(1) != vector.Length)
        {
            throw new ArgumentException("Matrix columns must match vector length.");
        }

        var result = new double[matrix.GetLength(0)];

        for (int i = 0; i < result.Length; i++)
        {
            double sum = 0;
            for (int j = 0; j < vector.Length; j++)
            {
                sum += matrix[i, j] * vector[j];
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

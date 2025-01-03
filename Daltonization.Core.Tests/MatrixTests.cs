namespace Daltonization.Core.Tests;

public class MatrixTests
{
    [Fact]
    public void Test_MatrixMultiply_Vector()
    {
        // Arrange
        var matrix = new double[,] {
            { 6, 2 , 4 },
            { -1, 4 , 3 },
            { -2, 9 , 3 }
        };

        var vector = new double[] { 4, -2 , 1 };
        var expectedResult = new double[] { 24, -9, -23 };

        // Act
        var result = Matrix.Multiply(matrix, vector);
        
        // Assert
        Assert.Equal(expectedResult, result);
    }
}
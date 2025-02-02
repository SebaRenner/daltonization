namespace Daltonization.Core.Tests;

public class GammaCorrectionTests
{
    [Fact]
    public void Test_Expand_SmallerEqualThan()
    {
        // Arrange
        var value = 0.04045;
        var expected = 0.00313080495356037151702786377709;

        // Act
        var result = GammaCorrection.Expand(value);

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void Test_Expand_BiggerThan()
    {
        // Arrange
        var value = 0.6;
        var expected = 0.31854677812509186;

        // Act
        var result = GammaCorrection.Expand(value);

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void Test_Compress_SmallerEqualThan()
    {
        // Arrange
        var value = 0.0031308;
        var expected = 0.040449936;

        // Act
        var result = GammaCorrection.Compress(value);

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void Test_Compress_BiggerThan()
    {
        // Arrange
        var value = 0.6;
        var expected = 0.79773773303125983;

        // Act
        var result = GammaCorrection.Compress(value);

        // Assert
        Assert.Equal(expected, result);
    }

}

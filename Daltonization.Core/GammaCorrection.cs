namespace Daltonization.Core;

public static class GammaCorrection
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="value">normalized rgb value</param>
    /// <returns></returns>
    public static double Expand(double value)
    {
        if (value <= 0.04045)
        {
            return value / 12.92;
        }
        else
        {
            return Math.Pow((value + 0.055) / 1.055, 2.4);
        }
    }


    public static double Compress(double value)
    {
        if (value <= 0.0031308) 
        {
            return 12.92 * value;
        }
        else 
        {
            return 1.055 * Math.Pow(value, 1.0 / 2.4) - 0.055;
        }
    }
}

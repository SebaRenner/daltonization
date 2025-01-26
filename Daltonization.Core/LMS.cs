using SixLabors.ImageSharp.PixelFormats;

namespace Daltonization.Core;

public struct LMS
{
    private double L { get; }

    private double M { get; }

    private double S { get; }

    private LMS(double L, double M, double S)
    {
        this.L = L;
        this.M = M;
        this.S = S;
    }

    public double[] Value => new double[] { L, M, S };

    public static LMS FromColor(Rgba32 color)
    {
        // normalize rgb
        var r = (double)color.R / 255;
        var g = (double)color.G / 255;
        var b = (double)color.B / 255;

        var rgb = new double[] { r, g, b };

        var lms = Matrix.Multiply(TransformationMatrices.Bradford, rgb);

        return new LMS(lms[0], lms[1], lms[2]);
    }

    public static LMS FromDoubleArr(double[] arr)
    {
        if (arr.Length != 3) throw new ArgumentException();
        return new LMS(arr[0], arr[1], arr[2]);
    }

    public Rgba32 ToRGB()
    {
        var rgb = Matrix.Multiply(TransformationMatrices.InverseBradford, Value);
        var rgbClamped = rgb.Select(x => x*255).Select(x => (byte)Math.Clamp(x, 0, 255)).ToArray();

        return new Rgba32(rgbClamped[0], rgbClamped[1], rgbClamped[2]);
    }

    public override string ToString()
    {
        return $"LMS({L}, {M}, {S})";
    }
}

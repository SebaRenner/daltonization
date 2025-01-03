using System.Drawing;

namespace Daltonization.Core;

// TODO: Think about changing to struct
public class LMS
{
    public double L { get; }

    public double M { get; }

    public double S { get; }

    private LMS(double L, double M, double S)
    {
        this.L = L;
        this.M = M;
        this.S = S;
    }

    public double[] Value => new double[] { L, M, S };

    public static LMS FromColor(Color color)
    {
        // normalize rgb
        var r = (double)color.R / 255;
        var g = (double)color.G / 255;
        var b = (double)color.B / 255;

        var rgb = new double[] { r, g, b };

        // bradford transformation matrix
        var bradford = new double[,]
        {
            { 0.8951, 0.2664, -0.1614 },
            { -0.7502, 1.7135, 0.0367 },
            { 0.0389, -0.0685, 1.0296 }
        };

        var lms = Matrix.Multiply(bradford, rgb);

        return new LMS(lms[0], lms[1], lms[2]);
    }

    public static LMS FromDoubleArr(double[] arr)
    {
        if (arr.Length != 3) throw new ArgumentException();
        return new LMS(arr[0], arr[1], arr[2]);
    }

    public Color ToRGB()
    {
        var invBradford = new double[,]
        {
            { 0.9869929, -0.1470543, 0.1599627 },
            { 0.4323053, 0.5183603, 0.0492912 },
            { -0.0085287, 0.0400428, 0.9684867 }
        };

        var rgb = Matrix.Multiply(invBradford, Value);
        var rgbClamped = rgb.Select(x => x*255).Select(x => (int)Math.Clamp(x, 0, 255)).ToArray();

        return Color.FromArgb(rgbClamped[0], rgbClamped[1], rgbClamped[2]);
    }

    public override string ToString()
    {
        return $"LMS({L}, {M}, {S})";
    }
}

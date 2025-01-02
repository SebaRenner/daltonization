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

        var lms = new double[3];

        for (int i = 0; i < lms.Length; i++)
        {
            lms[i] = bradford[i, 0] * rgb[0] + bradford[i, 1] * rgb[1] + bradford[i, 2] * rgb[2];
        }

        return new LMS(lms[0], lms[1], lms[2]);
    }

    public override string ToString()
    {
        return $"LMS({L}, {M}, {S})";
    }
}

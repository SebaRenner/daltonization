using System.Drawing;

using Daltonization.Core;


var color = Color.FromArgb(255, 0, 0);

var lms = LMS.FromColor(color);

Console.WriteLine(lms.ToString());
using System;
using System.Drawing;

namespace ImageResizer
{
    public static partial class API
    {
        public static double GetAspectRatio(this Size size)
        {
            return size.Width / (double)size.Height;
        }

        public static double GetAspectRatio(int width, int height)
        {
            return width / (double)height;
        }

        public static Size ToSize(this Size size, int width = 0, int height = 0)
        {
            if (width != 0 && height != 0)
            {
                return new Size(width, height);
            }
            if (width == 0 && height != 0)
            {
                return new Size(Convert.ToInt32(height * size.GetAspectRatio()), height);
            }
            if (width != 0 && height == 0)
            {
                return new Size(width, Convert.ToInt32(width / size.GetAspectRatio()));
            }
            return size;
        }

        public static string ToSizeString(this Size size, bool spaced = true)
        {
            return (size.Width + (spaced ? " x " : "x") + size.Height).ToString();
        }
    }
}

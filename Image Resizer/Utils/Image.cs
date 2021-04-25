using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ImageProcessor;
using System.Drawing;

namespace ImageResizer
{
    public static partial class Utils
    {
        public enum ResizeUnit { Flat = 0, Percentage = 1 }

        public static Image Resize(this Image image, int width, int height, ResizeUnit unit = ResizeUnit.Flat)
        {
            ImageFactory imageFactory = new ImageFactory();
            imageFactory.Load(image);
            switch (unit)
            {
                case ResizeUnit.Flat:
                    return imageFactory.Resize(new Size(width, height)).Image;
                case ResizeUnit.Percentage:
                    return imageFactory.Resize(new Size(
                        width.ToFlat(image.Width),
                        height.ToFlat(image.Height)
                    )).Image;
                default:
                    return imageFactory.Resize(new Size(width, height)).Image;
            }
        }

        public static string ToDimensionsString(this Image image, bool spaced = true)
        {
            string divider = spaced ? " x " : "x";
            return (image.Width + divider + image.Height).ToString();
        }
    }
}

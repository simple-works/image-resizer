using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ImageProcessor;
using System.Drawing;
using ImageProcessor.Imaging;

namespace ImageResizer
{
    public static partial class Utils
    {
        public enum ResizeUnit { Flat = 0, Percentage = 1 }

        public static Image Resize(this Image image, Size size)
        {
            ImageFactory imageFactory = new ImageFactory();
            imageFactory.Load(image);
            ResizeLayer config = new ResizeLayer(size, ResizeMode.Stretch);
            return imageFactory.Resize(config).Image;
        }

        public static Image Resize(this Image image, int width = 0, int height = 0,
            ResizeUnit unit = ResizeUnit.Flat)
        {
            switch (unit)
            {
                case ResizeUnit.Percentage:
                    return image.Resize(new Size(
                        width.ToFlat(image.Width),
                        height.ToFlat(image.Height)));
                default:
                    return image.Resize(new Size(width, height));
            }
        }

        public static double GetAspectRatio(this Image image)
        {
            return image.Width / image.Height;
        }
        public static double GetAspectRatio(this Size size)
        {
            return size.Width / size.Height;
        }

        public static Size ToProportionalSize(this Size size, int width = 0, int height = 0)
        {
            if (width != 0 && height != 0)
            {
                return new Size(width, height);
            }
            if (width == 0 && height != 0)
            {
                return new Size(height * (int)size.GetAspectRatio(), height);
            }
            if (width != 0 && height == 0)
            {
                return new Size(width, width / (int)size.GetAspectRatio());
            }
            return size;
        }

        public static string GetDimensionsString(this Image image, bool spaced = true)
        {
            string divider = spaced ? " x " : "x";
            return (image.Width + divider + image.Height).ToString();
        }
    }
}

using System.Drawing;
using ImageProcessor;
using ImageProcessor.Imaging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Drawing.Imaging;
using System.Linq;

namespace ImageResizer
{
    public static partial class Utils
    {
        public enum ResizeUnit { Flat, Percentage }

        public static Image Resize(this Image image, Size size,
            ResizeMode resizeMode = ResizeMode.Stretch)
        {
            ImageFactory imageFactory = new ImageFactory();
            imageFactory.Load(image);
            ResizeLayer config = new ResizeLayer(size, resizeMode);
            Image resizedImage = imageFactory.Resize(config).Image;
            resizedImage.Tag = image.Tag;
            return resizedImage;
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

        public static string GetOutputFileName(this Image image)
        {
            string path = image.Tag as string;
            string fileName = "untitled";
            string extension = ".notag";
            if (File.Exists(path))
            {
                fileName = Path.GetFileNameWithoutExtension(path);
                extension = Path.GetExtension(path);
                if (String.IsNullOrEmpty(extension))
                {
                    string[] extensions = image.GetFileExtensions();
                    if (extensions != null && extensions.Length != 0)
                    {
                        extension = extensions[0];
                    }
                    extension = ".noext";
                }
            }
            return String.Format("{0}_{1}x{2}{3}",
                fileName, image.Width, image.Height, extension);
        }

        public static string[] GetFileExtensions(this Image image)
        {
            ImageCodecInfo imgEncoder = ImageCodecInfo.GetImageEncoders()
                .FirstOrDefault(encoder => encoder.FormatID == image.RawFormat.Guid);
            if (imgEncoder == null)
            {
                return null;
            }
            return imgEncoder.FilenameExtension.ToLower().Replace("*", "").Split(';');
        }

        public static string GetFromat(this Image image)
        {
            ImageCodecInfo imgEncoder = ImageCodecInfo.GetImageEncoders()
               .FirstOrDefault(encoder => encoder.FormatID == image.RawFormat.Guid);
            if (imgEncoder == null)
            {
                return "";
            }
            return imgEncoder.MimeType;
        }

        public static bool IsImage(this string filePath)
        {
            try
            {
                return Image.FromFile(filePath) != null;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static double GetAspectRatio(this Image image)
        {
            return image.Width / (double)image.Height;
        }
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

        public static string GetSizeString(this Image image, bool spaced = true)
        {
            return image.Size.ToSizeString(spaced);
        }

        public static Image FindByTag<T>(this List<Image> images, T tag)
        {
            return images.Find(image => image.Tag.Equals(tag));
        }

        public static void RemoveByTag<T>(this List<Image> images, T tag)
        {
            Image imageToRemove = images.FindByTag<T>(tag);
            if (imageToRemove != null)
            {
                images.Remove(imageToRemove);
            }
        }
    }
}

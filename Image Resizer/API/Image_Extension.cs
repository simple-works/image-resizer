using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using ImageProcessor;
using ImageProcessor.Imaging;

namespace ImageResizer
{
    public static partial class API
    {
        public enum ResizeUnit { Flat, Percentage }
        public static string GetFilePath(this Image image)
        {
            if (image.Tag == null)
            {
                image.Tag = "";
            }
            return image.Tag as string;
        }
        public static void SetFilePath(this Image image, string filePath)
        {
            image.Tag = filePath;
        }

        public static Image Resize(this Image image, Size size,
            ResizeMode resizeMode = ResizeMode.Stretch)
        {
            ImageFactory imageFactory = new ImageFactory();
            imageFactory.Load(image);
            ResizeLayer config = new ResizeLayer(size, resizeMode);
            Image resizedImage = imageFactory.Resize(config).Image;
            resizedImage.SetFilePath(image.GetFilePath());
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
            string filePath = image.GetFilePath();
            string fileName = "untitled";
            string extension = ".nopath";
            if (File.Exists(filePath))
            {
                fileName = Path.GetFileNameWithoutExtension(filePath);
                extension = Path.GetExtension(filePath);
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

        public static double GetAspectRatio(this Image image)
        {
            return image.Width / (double)image.Height;
        }

        public static string GetSizeString(this Image image, bool spaced = true)
        {
            return image.Size.ToSizeString(spaced);
        }

        public static Image FindByFilePath(this List<Image> images, string filePath)
        {
            return images.Find(image => image.GetFilePath() == filePath);
        }

        public static void RemoveByFilePath(this List<Image> images, string filePath)
        {
            Image imageToRemove = images.FindByFilePath(filePath);
            if (imageToRemove != null)
            {
                images.Remove(imageToRemove);
            }
        }
    }
}

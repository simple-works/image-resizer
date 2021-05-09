using System;
using System.Drawing;
using System.IO;

namespace ImageResizer
{
    public static partial class API
    {
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

        public static Image LoadImage(this string filePath)
        {
            if (File.Exists(filePath))
            {
                Image image = Image.FromFile(filePath);
                image.SetFilePath(filePath);
                return image;
            }
            return null;
        }

        public static string ToFileSizeString(this string filePath, bool spaced = true)
        {
            FileInfo file = new FileInfo(filePath);
            if (file.Exists)
            {
                return file.Length.ToFileSizeString(spaced);
            }
            else
            {
                return 0L.ToFileSizeString();
            }
        }
    }
}

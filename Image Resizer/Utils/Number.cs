using System;
using System.Drawing;
using System.IO;

namespace ImageResizer
{
    public static partial class Utils
    {
        public static string ToFileSizeFormat(this long byteCount)
        {
            string[] suffixes = { "B", "Kb", "Mb", "Gb", "Tb", "Pb", "Eb" }; //Longs run out around EB
            if (byteCount == 0)
                return "0" + suffixes[0];
            long bytes = Math.Abs(byteCount);
            int place = Convert.ToInt32(Math.Floor(Math.Log(bytes, 1024)));
            double num = Math.Round(bytes / Math.Pow(1024, place), 1);
            return (Math.Sign(byteCount) * num).ToString() + " " + suffixes[place];
        }
        
        public static string ToFileSizeFormat(this string path)
        {
            return ToFileSizeFormat(new FileInfo(path).Length);
        }

        public static int ToFlat(this int percentage, int total)
        {
            return total * (percentage / 100);
        }

        public static int ToPercentage(this int flat, int total)
        {
            return flat * (100 / total);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace ImageResizer
{
    public static partial class API
    {
        public static void AddImage(this ImageList imageList, Image image)
        {
            imageList.Images.Add(image.Tag as string, image);
        }

        public static void FillWith(this ImageList imageList, ImageList srcImageList)
        {
            if (imageList != null && srcImageList != null)
            {
                imageList.Images.Clear();
                foreach (string key in srcImageList.Images.Keys)
                {
                    imageList.Images.Add(key, srcImageList.Images[key]);
                }
            }
        }
    }
}

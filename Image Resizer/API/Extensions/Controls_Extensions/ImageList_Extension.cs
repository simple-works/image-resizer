using System.Drawing;
using System.Windows.Forms;

namespace ImageResizer
{
    public static partial class API
    {
        public static void AddImage(this ImageList imageList, Image image)
        {
            imageList.Images.Add(image.GetFilePath(), image);
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
                return;
            }
        }
    }
}

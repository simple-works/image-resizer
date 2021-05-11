using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace ImageResizer
{
    public partial class Form_View : Form
    {
        public Form_View(Image image)
        {
            InitializeComponent();
            Text = string.Format("{0} ({1})",
                Path.GetFileName(image.GetFilePath()), image.GetSizeString());

            Width = image.Size.Width;
            Height = image.Size.Height;
            pictureBox_main.Image = image;
        }
    }
}

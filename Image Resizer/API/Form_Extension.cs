using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ImageResizer.Properties;

namespace ImageResizer
{
    public static partial class API
    {
        public static void Setup(this Form form)
        {
            form.Width = UISettings.Default.Width;
            form.Height = UISettings.Default.Width;
            form.WindowState = UISettings.Default.WindowState;
            form.Location = UISettings.Default.Location;
        }

        public static void Persist(this Form form)
        {
            UISettings.Default.Width = form.Width;
            UISettings.Default.Width = form.Height;
            UISettings.Default.WindowState = form.WindowState;
            UISettings.Default.Location = form.Location;
            UISettings.Default.Save();
        }
    }
}

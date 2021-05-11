using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ImageResizer
{
    public static partial class API
    {
        public static bool Equals(this Control control, Control otherControl)
        {
            return control.GetType() == otherControl.GetType() &&
                control.Name == otherControl.Name;
        }
        public static bool Equals(this Control control, object otherObject)
        {
            return control.Equals(otherObject);
        }
    }
}

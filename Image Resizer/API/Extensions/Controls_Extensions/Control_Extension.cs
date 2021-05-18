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

        public static void Toggle(this Control control)
        {
            control.Enabled = !control.Enabled;
        }
        public static void Toggle(this Control control, bool enable)
        {
            control.Enabled = enable;
        }

        public static void ToggleAllControls(this Control control)
        {
            foreach (Control subControl in control.Controls)
            {
                subControl.Enabled = !subControl.Enabled;
                if (subControl.Controls.Count > 0)
                {
                    subControl.ToggleAllControls();
                }
            }
        }
        public static void ToggleAllControls(this Control control, bool enable)
        {
            foreach (Control subControl in control.Controls)
            {
                subControl.Enabled = enable;
                if (subControl.Controls.Count > 0)
                {
                    subControl.ToggleAllControls(enable);
                }
            }
        }
    }
}

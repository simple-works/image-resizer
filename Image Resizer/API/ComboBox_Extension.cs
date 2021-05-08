using System.Windows.Forms;
using ImageResizer.Properties;

namespace ImageResizer
{
    public static partial class API
    {
        public static void Setup(this ComboBox comboBox)
        {
            comboBox.DataSource = API.ViewTypes;
            comboBox.DisplayMember = "Title";
            comboBox.ValueMember = "ViewX";
            comboBox.SelectedValue = (API.ViewX)Settings.Default.View;
        }

        public static void Persist(this ComboBox comboBox)
        {
            Settings.Default.View = (int)comboBox.SelectedValue;
            Settings.Default.Save();
        }
    }
}

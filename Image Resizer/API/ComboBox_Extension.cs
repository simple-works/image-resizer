using System.Windows.Forms;

namespace ImageResizer
{
    public static partial class API
    {
        public static void SetData(this ComboBox comboBox)
        {
            comboBox.DataSource = API.ViewTypes;
            comboBox.DisplayMember = "Title";
            comboBox.ValueMember = "ViewX";
        }
    }
}

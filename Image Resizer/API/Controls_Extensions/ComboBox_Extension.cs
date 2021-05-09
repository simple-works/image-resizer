using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ImageResizer
{
    public static partial class API
    {
        public static void SetDataSource(this ComboBox comboBox, object dataSource,
            string displayMemeber, string valueMemeber)
        {
            comboBox.DataSource = dataSource;
            comboBox.DisplayMember = displayMemeber;
            comboBox.ValueMember = valueMemeber;
        }
    }
}

using System;
using System.Drawing;
using System.Windows.Forms;

namespace ImageResizer
{
    public partial class Form_Overwrite : Form
    {
        public Form_Overwrite(string message = "", string title = "")
        {
            InitializeComponent();
            label_message.Text = String.IsNullOrEmpty(message)
                ? label_message.Text : message;
            Text = String.IsNullOrEmpty(title) ? Text : title;
            pictureBox_icon.Image = SystemIcons.Question.ToBitmap();
            Height += Convert.ToInt32(label_message.Height / 2.0);
            StartPosition = FormStartPosition.CenterScreen;
        }

        public static DialogResult Show(string message = "", string title = "", 
            Form parentForm = null)
        {
            return new Form_Overwrite(message, title).ShowDialog();
        }
    }
}

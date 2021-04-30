using System;
using System.Windows.Forms;

namespace ImageResizer
{
    public partial class Form_About : Form
    {
        public Form_About()
        {
            InitializeComponent();
        }

        private void button_ok_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void linkLabel_email_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("mailto:ambratolm@gmail.com");
        }

        private void linkLabel_website_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://ambratolm.ml");
        }
    }
}

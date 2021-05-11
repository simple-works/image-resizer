using System;
using System.Diagnostics;
using System.Windows.Forms;
using ImageResizer.Properties;

namespace ImageResizer
{
    public partial class Form_About : Form
    {
        public Form_About()
        {
            InitializeComponent();
            textBox_thirdPartyLicenses.Text = Resources.ThirdPartyLicenses;
        }

        private void button_ok_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void linkLabel_email_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("mailto:ambratolm@gmail.com");
        }

        private void linkLabel_website_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("http://ambratolm.ml");
        }
    }
}

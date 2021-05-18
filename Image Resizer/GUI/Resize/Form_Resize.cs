using System;
using System.Drawing;
using System.Windows.Forms;

namespace ImageResizer
{
    public partial class Form_Resize : Form
    {
        public Form_Resize(Image[] images = null)
        {
            InitializeComponent();
            InitializeAttributes(images);
            SetupControls();
            LoadSettings();
            UpdateControls();
        }

        private void numUD_width_ValueChanged(object sender, EventArgs e)
        {
            UpdateControls(sender as NumericUpDown);
        }

        private void numUD_height_ValueChanged(object sender, EventArgs e)
        {
            UpdateControls(sender as NumericUpDown);
        }

        private void numUD_widthPc_ValueChanged(object sender, EventArgs e)
        {
            UpdateControls(sender as NumericUpDown);
        }

        private void numUD_heightPc_ValueChanged(object sender, EventArgs e)
        {
            UpdateControls(sender as NumericUpDown);
        }

        private void checkBox_keepAspectRatio_CheckedChanged(object sender, EventArgs e)
        {
            UpdateControls(sender as CheckBox);
        }

        private void button_selectOutputFolder_Click(object sender, EventArgs e)
        {
            SelectOutputFolder();
        }

        private void radioButton_flat_CheckedChanged(object sender, EventArgs e)
        {
            UpdateControls();
        }

        private void radioButton_percentage_CheckedChanged(object sender, EventArgs e)
        {
            UpdateControls();
        }

        private void textBox_outputFolderPath_TextChanged(object sender, EventArgs e)
        {
            UpdateControls();
        }

        private void Form_Resize_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveSettings();
        }

        private void button_cancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button_start_Click(object sender, EventArgs e)
        {
            ResizeAndSaveImagesAsync();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using ImageProcessor.Imaging;
using ImageResizer.Properties;

namespace ImageResizer
{
    public partial class Form_Resize : Form
    {
        public Image[] Images { get; set; }

        public Form_Resize(Image[] images = null)
        {
            InitializeComponent();
            CreateEvents();
            checkBox_keepAspectRatio_CheckedChanged(null, null);
            textBox_outputFolderPath_TextChanged(null, null);
            this.Images = (images == null) ? new Image[] { } : images;
            LoadSettings();
        }

        private void LoadSettings()
        {
            radioButton_flat.Checked = Settings.Default.ResizeUnitIsFlat;
            radioButton_percentage.Checked = !Settings.Default.ResizeUnitIsFlat;
            numUD_width.Value = Settings.Default.Width;
            numUD_height.Value = Settings.Default.Height;
            numUD_widthPc.Value = Settings.Default.WidthPc;
            numUD_heightPc.Value = Settings.Default.HeightPc;
            checkBox_keepAspectRatio.Checked = Settings.Default.KeepAspectRatio;
            string outputFolderPath = Settings.Default.OutputFolderPath.Trim();
            textBox_outputFolderPath.Text = String.IsNullOrEmpty(outputFolderPath)
                ? Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
                : outputFolderPath;
        }

        private void CreateEvents()
        {
            numUD_width.TextChanged += new EventHandler(numUD_width_ValueChanged);
            numUD_height.TextChanged += new EventHandler(numUD_height_ValueChanged);
            numUD_widthPc.TextChanged += new EventHandler(numUD_widthPc_ValueChanged);
            numUD_heightPc.TextChanged += new EventHandler(numUD_heightPc_ValueChanged);
        }

        private void button_start_Click(object sender, EventArgs e)
        {
            string targetPath = textBox_outputFolderPath.Text.Trim();
            if (!String.IsNullOrEmpty(targetPath))
            {
                int width = 0;
                int height = 0;
                Utils.ResizeUnit unit = 0;
                if (radioButton_flat.Checked)
                {
                    width = (int)numUD_width.Value;
                    height = (int)numUD_height.Value;
                    unit = Utils.ResizeUnit.Flat;
                }
                else
                {
                    width = (int)numUD_widthPc.Value;
                    height = (int)numUD_heightPc.Value;
                    unit = Utils.ResizeUnit.Percentage;
                }

                foreach (Image image in this.Images)
                {
                    Image outputImage = image.Resize(width, height, unit);

                    string baseFilename = (string)image.Tag;
                    string filename = String.Format("{0}_{1}x{2}.{3}",
                        Path.GetFileNameWithoutExtension(baseFilename),
                        outputImage.Width,
                        outputImage.Height,
                        Path.GetExtension(baseFilename));
                    string fullPath = Path.Combine(targetPath, filename);

                    if (File.Exists(fullPath))
                    {
                        var alert = MessageBox.Show(
                            String.Format("Overwrite \"{0}\" ?", filename),
                            "Alert",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question);
                        if (alert == DialogResult.Yes)
                        {
                            outputImage.Save(fullPath);
                        }
                        continue;
                    }

                    outputImage.Save(fullPath);
                }
            }
            this.Close();
        }

        private void numUD_width_ValueChanged(object sender, EventArgs e)
        {
            if (checkBox_keepAspectRatio.Checked && numUD_width.Value != 0)
            {
                numUD_height.Value = 0;
            }
        }

        private void numUD_height_ValueChanged(object sender, EventArgs e)
        {
            if (checkBox_keepAspectRatio.Checked && numUD_height.Value != 0)
            {
                numUD_width.Value = 0;
            }
        }

        private void numUD_widthPc_ValueChanged(object sender, EventArgs e)
        {
            if (checkBox_keepAspectRatio.Checked)
            {
                numUD_heightPc.Value = numUD_widthPc.Value;
            }
        }

        private void numUD_heightPc_ValueChanged(object sender, EventArgs e)
        {
            if (checkBox_keepAspectRatio.Checked)
            {
                numUD_widthPc.Value = numUD_heightPc.Value;
            }
        }

        private void checkBox_keepAspectRatio_CheckedChanged(object sender, EventArgs e)
        {
            numUD_width_ValueChanged(null, null);
            numUD_widthPc_ValueChanged(null, null);
            numUD_width_Click(null, null);
        }

        private void button_selectOutputFolder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                textBox_outputFolderPath.Text = folderBrowserDialog.SelectedPath;
            }
        }

        private void radioButtons_flat_percentage_CheckedChanged()
        {
            groupBox_flat.Enabled = radioButton_flat.Checked;
            groupBox_percentage.Enabled = radioButton_percentage.Checked;
        }

        private void radioButton_flat_CheckedChanged(object sender, EventArgs e)
        {
            radioButtons_flat_percentage_CheckedChanged();
        }

        private void radioButton_percentage_CheckedChanged(object sender, EventArgs e)
        {
            radioButtons_flat_percentage_CheckedChanged();
        }

        private void textBox_outputFolderPath_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox_outputFolderPath.Text.Trim()))
            {
                button_start.Enabled = false;
            }
            else
            {
                button_start.Enabled = true;
            }
        }

        private void numUD_width_Click(object sender, EventArgs e)
        {
            if (checkBox_keepAspectRatio.Checked)
            {
                numUD_width.ReadOnly = false;
                numUD_height.ReadOnly = true;
            }
        }

        private void numUD_height_Click(object sender, EventArgs e)
        {
            if (checkBox_keepAspectRatio.Checked)
            {
                numUD_width.ReadOnly = true;
                numUD_height.ReadOnly = false;
            }
        }

        private void Form_Resize_FormClosing(object sender, FormClosingEventArgs e)
        {
            Settings.Default.ResizeUnitIsFlat = radioButton_flat.Checked;
            Settings.Default.Width = (int)numUD_width.Value;
            Settings.Default.Height = (int)numUD_height.Value;
            Settings.Default.WidthPc = (int)numUD_widthPc.Value;
            Settings.Default.HeightPc = (int)numUD_heightPc.Value;
            Settings.Default.KeepAspectRatio = checkBox_keepAspectRatio.Checked;
            Settings.Default.OutputFolderPath = textBox_outputFolderPath.Text.Trim();
            Settings.Default.Save();
        }
    }
}

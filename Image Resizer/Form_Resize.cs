using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using ImageResizer.Properties;

namespace ImageResizer
{
    public partial class Form_Resize : Form
    {
        public Image[] InputImages { get; set; }

        public Form_Resize(Image[] images = null)
        {
            InitializeComponent();
            CreateEvents();
            checkBox_keepAspectRatio_CheckedChanged(null, null);
            textBox_outputFolderPath_TextChanged(null, null);
            InputImages = (images == null) ? new Image[] { } : images;
            LoadSettings();
        }

        private void ResizeAndSaveImages()
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

            foreach (Image image in InputImages)
            {
                Image outputImage = image.Resize(width, height, unit);
                string fileName = outputImage.GetOutputFileName();
                string folderPath = textBox_outputFolderPath.Text;
                string fullPath = Path.Combine(folderPath, fileName);

                if (File.Exists(fullPath))
                {
                    var dialogResult = MessageBox.Show(
                        String.Format("This file already exists:\n{0}\nOverwrite it ?", fullPath),
                        "File Already Exists", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                    if (dialogResult == DialogResult.Yes)
                    {
                        outputImage.Save(fullPath);
                    }
                    continue;
                }
                outputImage.Save(fullPath);
            }
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
            textBox_outputFolderPath.Text = Directory.Exists(outputFolderPath)
                ? outputFolderPath
                : Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        }

        private void SaveSettings()
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

        private void CreateEvents()
        {
            numUD_width.TextChanged += new EventHandler(numUD_width_ValueChanged);
            numUD_height.TextChanged += new EventHandler(numUD_height_ValueChanged);
            numUD_widthPc.TextChanged += new EventHandler(numUD_widthPc_ValueChanged);
            numUD_heightPc.TextChanged += new EventHandler(numUD_heightPc_ValueChanged);
        }

        private void UpdateRadioButtons()
        {
            groupBox_flat.Enabled = radioButton_flat.Checked;
            groupBox_percentage.Enabled = radioButton_percentage.Checked;
        }

        private void UpdateNumUDs()
        {
            if (checkBox_keepAspectRatio.Checked)
            {
                if (numUD_height.Value != 0)
                {
                    numUD_width.Value = 0;
                }
                if (numUD_width.Value != 0)
                {
                    numUD_height.Value = 0;
                }
                if (numUD_heightPc.Value != 0)
                {
                    numUD_widthPc.Value = numUD_heightPc.Value;
                }
                if (numUD_widthPc.Value != 0)
                {
                    numUD_heightPc.Value = numUD_widthPc.Value;
                }
            }
        }

        #region Event Handlers
        private void button_start_Click(object sender, EventArgs e)
        {
            ResizeAndSaveImages();
            Close();
        }

        private void numUD_width_ValueChanged(object sender, EventArgs e)
        {
            if (checkBox_keepAspectRatio.Checked)
            {
                if (numUD_width.Value != 0)
                {
                    numUD_height.Value = 0;
                }
            }
        }

        private void numUD_height_ValueChanged(object sender, EventArgs e)
        {
            if (checkBox_keepAspectRatio.Checked)
            {
                if (numUD_height.Value != 0)
                {
                    numUD_width.Value = 0;
                }
            }
        }

        private void numUD_widthPc_ValueChanged(object sender, EventArgs e)
        {
            if (checkBox_keepAspectRatio.Checked)
            {
                if (numUD_widthPc.Value != 0)
                {
                    numUD_heightPc.Value = numUD_widthPc.Value;
                }
            }
        }

        private void numUD_heightPc_ValueChanged(object sender, EventArgs e)
        {
            if (checkBox_keepAspectRatio.Checked)
            {
                if (numUD_heightPc.Value != 0)
                {
                    numUD_widthPc.Value = numUD_heightPc.Value;
                }
            }
        }

        private void checkBox_keepAspectRatio_CheckedChanged(object sender, EventArgs e)
        {
            UpdateNumUDs();
        }

        private void button_selectOutputFolder_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog_main.ShowDialog() == DialogResult.OK)
            {
                textBox_outputFolderPath.Text = folderBrowserDialog_main.SelectedPath;
            }
        }

        private void radioButton_flat_CheckedChanged(object sender, EventArgs e)
        {
            UpdateRadioButtons();
        }

        private void radioButton_percentage_CheckedChanged(object sender, EventArgs e)
        {
            UpdateRadioButtons();
        }

        private void textBox_outputFolderPath_TextChanged(object sender, EventArgs e)
        {
            button_start.Enabled = Directory.Exists(textBox_outputFolderPath.Text);
        }

        private void Form_Resize_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveSettings();
        }

        private void button_cancel_Click(object sender, EventArgs e)
        {
            Close();
        }
        #endregion
    }
}

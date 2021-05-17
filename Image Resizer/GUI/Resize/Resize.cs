using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using ImageResizer.Properties;

namespace ImageResizer
{
    partial class Form_Resize
    {
        private Image[] _inputImages;

        public void InitializeAttributes(Image[] images)
        {
            _inputImages = (images == null) ? new Image[] { } : images;
        }

        public void SetupControls()
        {
            numUD_width.TextChanged += new EventHandler(numUD_width_ValueChanged);
            numUD_height.TextChanged += new EventHandler(numUD_height_ValueChanged);
            numUD_widthPc.TextChanged += new EventHandler(numUD_widthPc_ValueChanged);
            numUD_heightPc.TextChanged += new EventHandler(numUD_heightPc_ValueChanged);
        }

        public void UpdateControls()
        {
            groupBox_flat.Enabled = radioButton_flat.Checked;
            groupBox_percentage.Enabled = radioButton_percentage.Checked;
            button_start.Enabled = Directory.Exists(textBox_outputFolderPath.Text);
        }
        public void UpdateControls(Control senderControl)
        {
            if (checkBox_keepAspectRatio.Checked)
            {
                if ((senderControl.Equals(numUD_width) ||
                    senderControl.Equals(checkBox_keepAspectRatio)) &&
                    numUD_width.Value != 0)
                {
                    numUD_height.Value = 0;
                }
                if (senderControl.Equals(numUD_height) &&
                    numUD_height.Value != 0)
                {
                    numUD_width.Value = 0;
                }

                if ((senderControl.Equals(numUD_widthPc) ||
                    senderControl.Equals(checkBox_keepAspectRatio)) &&
                    numUD_widthPc.Value != 0)
                {
                    numUD_heightPc.Value = numUD_widthPc.Value;
                }
                if (senderControl.Equals(numUD_heightPc) &&
                    numUD_heightPc.Value != 0)
                {
                    numUD_widthPc.Value = numUD_heightPc.Value;
                }
            }
        }

        public void LoadSettings()
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

        public void SaveSettings()
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

        public void SelectOutputFolder()
        {
            if (folderBrowserDialog_main.ShowDialog() == DialogResult.OK)
            {
                textBox_outputFolderPath.Text = folderBrowserDialog_main.SelectedPath;
            }
        }

        public void ResizeAndSaveImagesAsync()
        {
            if (!backgroundWorker_main.IsBusy)
            {
                backgroundWorker_main.RunWorkerAsync();
                Form_Loading.Singleton.ShowDialog(
                    title: "Resizing and saving images...",
                    cancelProgress: () =>
                    {
                        if (backgroundWorker_main.WorkerSupportsCancellation)
                        {
                            backgroundWorker_main.CancelAsync();
                        }
                    }
                );
            }
        }

        public void BeginResizeAndSaveImages(DoWorkEventArgs e)
        {
            int width = 0;
            int height = 0;
            API.ResizeUnit unit = 0;
            bool overwrite = false;

            if (radioButton_flat.Checked)
            {
                width = (int)numUD_width.Value;
                height = (int)numUD_height.Value;
                unit = API.ResizeUnit.Flat;
            }
            else
            {
                width = (int)numUD_widthPc.Value;
                height = (int)numUD_heightPc.Value;
                unit = API.ResizeUnit.Percentage;
            }

            for (int i = 0; i < _inputImages.Length; i++)
            {
                if (backgroundWorker_main.CancellationPending)
                {
                    e.Cancel = true;
                    break;
                }
                else
                {
                    Image outputImage = _inputImages[i].Resize(width, height, unit);
                    string fileName = outputImage.GetOutputFileName();
                    string folderPath = textBox_outputFolderPath.Text;
                    string fullPath = Path.Combine(folderPath, fileName);

                    if (File.Exists(fullPath) && !overwrite)
                    {
                        var dialogResult = Form_Overwrite.Show(
                            String.Format("This file already exists:\n{0}\n\nOverwrite it ?", fullPath),
                            "File Already Exists");
                        if (dialogResult == DialogResult.Yes)
                        {
                            outputImage.Save(fullPath);
                            backgroundWorker_main.ReportProgressAsPercentage(i + 1, _inputImages.Length);
                            continue;
                        }
                        else if (dialogResult == DialogResult.OK) // YesToAll
                        {
                            outputImage.Save(fullPath);
                            backgroundWorker_main.ReportProgressAsPercentage(i + 1, _inputImages.Length);
                            overwrite = true;
                            continue;
                        }
                        else if (dialogResult == DialogResult.No)
                        {
                            backgroundWorker_main.ReportProgressAsPercentage(i + 1, _inputImages.Length);
                            continue;
                        }
                        else
                        {
                            backgroundWorker_main.ReportProgressAsPercentage(_inputImages.Length, _inputImages.Length);
                            break;
                        }
                    }
                    else
                    {
                        outputImage.Save(fullPath);
                        backgroundWorker_main.ReportProgressAsPercentage(i + 1, _inputImages.Length);
                    }
                }
            }
        }
        public void ProgressResizeAndSaveImages(ProgressChangedEventArgs e)
        {
            Form_Loading.Singleton.SetProgressPercentage(e.ProgressPercentage);
        }
        public void EndResizeAndSaveImages(RunWorkerCompletedEventArgs e)
        {
            Form_Loading.Singleton.Close();
            Close();
        }
    }
}

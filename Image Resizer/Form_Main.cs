using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using ImageResizer.Properties;
using System.ComponentModel;

namespace ImageResizer
{
    public partial class Form_Main : Form
    {
        private List<Image> _inputImages = new List<Image>();
        private Form_Loading _loadingForm = Form_Loading.Singleton;

        public Form_Main()
        {
            InitializeComponent();

            Width = UISettings.Default.Width;
            Height = UISettings.Default.Width;
            WindowState = UISettings.Default.WindowState;
            Location = UISettings.Default.Location;

            comboBox_view.SetDataSource(API.ViewModes, "Title", "ViewX");
            comboBox_view.SelectedValue = (API.ViewX)Settings.Default.View;

            listView_main.AddColumn("Name", 200);
            listView_main.AddColumn("Dimensions", 100);
            listView_main.AddColumn("Size", 100);
            listView_main.AddColumn("Format", 100);
            listView_main.FullRowSelect = true;

            listView_main_SelectedIndexChanged(null, null);
        }

        private void LoadImages(string[] filePaths)
        {
            if (!backgroundWorker_main.IsBusy)
            {
                backgroundWorker_main.RunWorkerAsync(filePaths);
                _loadingForm.Title = "Opening image files...";
                _loadingForm.CancelProgress = () =>
                {
                    if (backgroundWorker_main.WorkerSupportsCancellation)
                    {
                        backgroundWorker_main.CancelAsync();
                    }
                };
                _loadingForm.ShowDialog();
            }
        }

        private void Form_Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            UISettings.Default.Width = Width;
            UISettings.Default.Width = Height;
            UISettings.Default.WindowState = WindowState;
            UISettings.Default.Location = Location;
            UISettings.Default.Save();

            Settings.Default.View = (int)comboBox_view.SelectedValue;
            Settings.Default.Save();
        }

        private void comboBox_view_SelectedIndexChanged(object sender, EventArgs e)
        {
            API.ViewMode viewType = comboBox_view.SelectedItem as API.ViewMode;
            listView_main.SetViewMode(viewType);
        }

        private void listView_main_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool itemsAreSelected = (listView_main.SelectedItems.Count != 0);
            bool itemsExist = (listView_main.Items.Count != 0);
            button_view.Enabled = itemsAreSelected;
            button_remove.Enabled = itemsAreSelected;
            button_clear.Enabled = itemsExist;
            button_resize.Enabled = itemsExist;
            button1.Text = _inputImages.Count.ToString() + " images";
        }

        private void button_about_Click(object sender, EventArgs e)
        {
            new Form_About().ShowDialog();
        }

        private void button_resize_Click(object sender, EventArgs e)
        {
            new Form_Resize(_inputImages.ToArray()).ShowDialog();
        }

        private void button_remove_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in listView_main.SelectedItems)
            {
                listView_main.RemoveImageItem(item);
                _inputImages.RemoveByFilePath(item.ImageKey);
            }
            listView_main_SelectedIndexChanged(sender, e);
        }

        private void button_clear_Click(object sender, EventArgs e)
        {
            listView_main.ClearImageItems();
            _inputImages.Clear();
            listView_main_SelectedIndexChanged(sender, e);
        }

        private void button_add_Click(object sender, EventArgs e)
        {
            if (openFileDialog_main.ShowDialog() == DialogResult.OK)
            {
                LoadImages(openFileDialog_main.FileNames);
            }
        }

        private void Form_Main_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = e.Data.GetDataPresent(DataFormats.FileDrop)
                ? DragDropEffects.Copy : DragDropEffects.None;
        }

        private void Form_Main_DragDrop(object sender, DragEventArgs e)
        {
            string[] paths = (string[])e.Data.GetData(DataFormats.FileDrop);
            var foldersPaths = paths.Where(path => Directory.Exists(path));
            var foldersFilesPaths = foldersPaths
                .Select(folderPath => Directory.GetFiles(folderPath))
                .SelectMany(folderPath => folderPath);
            var filePaths = paths.Except(foldersPaths).Union(foldersFilesPaths);

            string[] validFilePaths = filePaths
                .Where(filePath => filePath.IsImage()).ToArray();
            LoadImages(validFilePaths);

            string[] invalidFilePaths = filePaths.Except(validFilePaths).ToArray();
            if (invalidFilePaths.Length != 0)
            {
                string message =
                    String.Format("These files are invalid image files:\n{0}",
                    String.Join("\n", invalidFilePaths));
                MessageBox.Show(message, "Invalid Image File",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void button_view_Click(object sender, EventArgs e)
        {
            string imageKey = listView_main.SelectedItems[0].ImageKey;
            Image imageToView = _inputImages.FindByFilePath(imageKey);
            new Form_View(imageToView).ShowDialog();
        }

        private void listView_main_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            button_view.PerformClick();
        }

        private void backgroundWorker_main_DoWork(object sender, DoWorkEventArgs e)
        {
            string[] filePaths = e.Argument as string[];
            for (int i = 0; i < filePaths.Length; i++)
            {
                if (backgroundWorker_main.CancellationPending)
                {
                    e.Cancel = true;
                    break;
                }
                else
                {
                    Image image = filePaths[i].LoadImage();
                    _inputImages.Add(image);
                    backgroundWorker_main.ReportProgressAsPercentage(i + 1, 
                        filePaths.Length, image);
                }
            }
        }

        private void backgroundWorker_main_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            _loadingForm.SetProgressPercentage(e.ProgressPercentage);
            Image image = e.UserState as Image;
            listView_main.AddImageItem(image);
        }

        private void backgroundWorker_main_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            _loadingForm.Close();
            listView_main.Focus();
            listView_main_SelectedIndexChanged(null, null);
        }
    }
}

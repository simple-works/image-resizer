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
        private List<Image> inputImages = new List<Image>();
        private Form_Loading form_loading = new Form_Loading();

        public Form_Main()
        {
            InitializeComponent();

            comboBox_view.SetData();
            listView_main.SetColumns();
            listView_main_SelectedIndexChanged(null, null);

            comboBox_view.SelectedValue = (API.ViewX)Settings.Default.View;
            Width = UISettings.Default.Width;
            Height = UISettings.Default.Width;
            WindowState = UISettings.Default.WindowState;
            Location = UISettings.Default.Location;
        }

        private void Form_Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            Settings.Default.View = (int)comboBox_view.SelectedValue;
            Settings.Default.Save();
            UISettings.Default.Width = Width;
            UISettings.Default.Width = Height;
            UISettings.Default.WindowState = WindowState;
            UISettings.Default.Location = Location;
            UISettings.Default.Save();
        }

        private void comboBox_view_SelectedIndexChanged(object sender, EventArgs e)
        {
            var viewType = (API.ViewType)comboBox_view.SelectedItem;
            listView_main.SetViewX(viewType.ViewX);
            listView_main.SetImageSize(viewType.ImageSize, imageList_backup);
        }

        private void listView_main_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool itemsAreSelected = (listView_main.SelectedItems.Count != 0);
            bool itemsExist = (listView_main.Items.Count != 0);
            button_view.Enabled = itemsAreSelected;
            button_remove.Enabled = itemsAreSelected;
            button_clear.Enabled = itemsExist;
            button_resize.Enabled = itemsExist;
            button1.Text = inputImages.Count.ToString() + " images";
        }

        private void button_about_Click(object sender, EventArgs e)
        {
            new Form_About().ShowDialog();
        }

        private void button_resize_Click(object sender, EventArgs e)
        {
            new Form_Resize(inputImages.ToArray()).ShowDialog();
        }

        private void button_remove_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in listView_main.SelectedItems)
            {
                listView_main.Items.Remove(item);
                imageList_main.Images.RemoveByKey(item.ImageKey);
                imageList_backup.Images.RemoveByKey(item.ImageKey);
                inputImages.RemoveByTag<String>(item.ImageKey);
            }
            listView_main_SelectedIndexChanged(sender, e);
        }

        private void button_clear_Click(object sender, EventArgs e)
        {
            listView_main.Items.Clear();
            imageList_main.Images.Clear();
            imageList_backup.Images.Clear();
            inputImages.Clear();
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
            Image imageToView = inputImages.FindByTag(imageKey);
            new Form_View(imageToView).ShowDialog();
        }

        private void listView_main_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            button_view.PerformClick();
        }

        private void LoadImages(string[] filePaths)
        {
            if (!backgroundWorker_main.IsBusy)
            {
                backgroundWorker_main.RunWorkerAsync(filePaths);
                if (form_loading == null || form_loading.IsDisposed)
                {
                    form_loading = new Form_Loading();
                }
                form_loading.Title = "Opening image files...";
                form_loading.CancelProgress = () =>
                {
                    if (backgroundWorker_main.WorkerSupportsCancellation == true)
                    {
                        backgroundWorker_main.CancelAsync();
                    }
                };
                form_loading.ShowDialog();
            }
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
                    inputImages.Add(image);
                    int progressPercentage = (i + 1).ToPercentage(filePaths.Length);
                    backgroundWorker_main.ReportProgress(progressPercentage, image);
                }
            }
        }

        private void backgroundWorker_main_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            form_loading.SetProgressPercentage(e.ProgressPercentage);
            Image image = e.UserState as Image;
            listView_main.AddImageItem(image);
            imageList_main.AddImage(image);
            imageList_backup.AddImage(image);
        }

        private void backgroundWorker_main_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            form_loading.Close();
            listView_main.Focus();
            listView_main_SelectedIndexChanged(null, null);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using ImageResizer.Properties;

namespace ImageResizer
{
    partial class Form_Main
    {
        private List<Image> _inputImages = new List<Image>();

        public void SetupControls()
        {
            listView_main.AddColumn("Name", 200);
            listView_main.AddColumn("Dimensions", 100);
            listView_main.AddColumn("Size", 100);
            listView_main.AddColumn("Format", 100);
            listView_main.FullRowSelect = true;
            comboBox_view.SetDataSource(API.GetViewModes(), "Title", "ViewX");
        }

        public void UpdateControls()
        {
            bool itemsAreSelected = (listView_main.SelectedItems.Count != 0);
            bool itemsExist = (listView_main.Items.Count != 0);
            button_view.Enabled = itemsAreSelected;
            button_remove.Enabled = itemsAreSelected;
            button_clear.Enabled = itemsExist;
            button_resize.Enabled = itemsExist;
            button_imagesCount.Text = String.Format("{0} images", _inputImages.Count);
        }

        public void LoadSettings()
        {
            Width = UISettings.Default.Width;
            Height = UISettings.Default.Width;
            WindowState = UISettings.Default.WindowState;
            Location = UISettings.Default.Location;
            comboBox_view.SelectedValue = (API.ViewX)Settings.Default.View;
        }

        public void SaveSettings()
        {
            UISettings.Default.Width = Width;
            UISettings.Default.Width = Height;
            UISettings.Default.WindowState = WindowState;
            UISettings.Default.Location = Location;
            UISettings.Default.Save();
            Settings.Default.View = (int)comboBox_view.SelectedValue;
            Settings.Default.Save();
        }

        public void ChangeViewMode()
        {
            API.ViewMode viewType = comboBox_view.SelectedItem as API.ViewMode;
            listView_main.SetViewMode(viewType);
        }

        public void AddItemsByFileBrowsing()
        {
            if (openFileDialog_main.ShowDialog() == DialogResult.OK)
            {
                LoadImagesAsync(openFileDialog_main.FileNames);
            }
        }

        private void AddItemsByFileDragDroping(string[] filePaths)
        {
            string[] validFilePaths = filePaths
                .Where(filePath => filePath.IsImage()).ToArray();
            LoadImagesAsync(validFilePaths);

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

        public void RemoveSelectedItems()
        {
            foreach (ListViewItem item in listView_main.SelectedItems)
            {
                listView_main.RemoveImageItem(item);
                _inputImages.RemoveByFilePath(item.ImageKey);
            }
        }

        public void RemoveAllItems()
        {
            listView_main.ClearImageItems();
            _inputImages.Clear();
        }

        public void ViewSelectedItem()
        {
            string imageKey = listView_main.SelectedItems[0].ImageKey;
            Image imageToView = _inputImages.FindByFilePath(imageKey);
            new Form_View(imageToView).ShowDialog();
        }

        public void LoadImagesAsync(string[] filePaths)
        {
            Form_Loading.Show(
                title: "Opening image files...",
                start: (worker, e) =>
                {
                    for (int i = 0; i < filePaths.Length; i++)
                    {
                        if (worker.CancellationPending)
                        {
                            e.Cancel = true;
                            break;
                        }
                        else
                        {
                            Image image = filePaths[i].LoadImage();
                            _inputImages.Add(image);
                            worker.ReportProgress(
                                percentProgress: (i + 1).ToPercentage(filePaths.Length),
                                userState: image
                            );
                        }
                    }
                },
                progress: (worker, e) =>
                {
                    Image image = e.UserState as Image;
                    listView_main.AddImageItem(image);
                    UpdateControls();
                },
                complete: (worker, e) =>
                {
                    listView_main.Focus();
                }
            );
        }

        public void ShowAboutDialog()
        {
            new Form_About().ShowDialog();
        }

        public void ShowResizeDialog()
        {
            new Form_Resize(_inputImages.ToArray()).ShowDialog();
        }
    }
}

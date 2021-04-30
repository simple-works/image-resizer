using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using ImageResizer.Properties;

namespace ImageResizer
{
    public partial class Form_Main : Form
    {
        public List<Image> InputImages { get; set; }

        public Form_Main()
        {
            InitializeComponent();
            InputImages = new List<Image>();

            comboBox_view.SetData();
            listView_main.SetColumns();
            UpdateButtons();

            LoadSettings();
        }

        private void LoadSettings()
        {
            comboBox_view.SelectedValue = (Utils.ViewX)Settings.Default.View;
            Width = UISettings.Default.Width;
            Height = UISettings.Default.Width;
            WindowState = UISettings.Default.WindowState;
            Location = UISettings.Default.Location;
        }

        private void SaveSettings()
        {
            Settings.Default.View = (int)comboBox_view.SelectedValue;
            Settings.Default.Save();
            UISettings.Default.Width = Width;
            UISettings.Default.Width = Height;
            UISettings.Default.WindowState = WindowState;
            UISettings.Default.Location = Location;
            UISettings.Default.Save();
        }

        private void LoadImages(params string[] paths)
        {
            foreach (string path in paths)
            {
                string filename = Path.GetFileName(path);
                Image image = Image.FromFile(path);

                image.Tag = path;
                this.InputImages.Add(image);

                if (!listView_main.Items.ContainsKey(path))
                {
                    var item = new ListViewItem();
                    item.Name = path;
                    item.ImageKey = path;
                    item.Text = filename;
                    item.ToolTipText = filename;
                    item.SubItems.AddRange(new[] { 
                        image.GetSizeString(), 
                        path.ToFileSizeString() 
                    });
                    listView_main.Items.Add(item);

                    imageList_main.Images.Add(item.ImageKey, image);
                    imageList_backup.Images.Add(item.ImageKey, image);

                    UpdateButtons();
                }
            }
        }

        private void UpdateListView()
        {
            var viewType = (Utils.ViewType)comboBox_view.SelectedItem;
            listView_main.SetViewX(viewType.ViewX);
            listView_main.SetImageSize(viewType.ImageSize, imageList_backup);
        }

        private void UpdateButtons()
        {
            bool itemsAreSelected = (listView_main.SelectedItems.Count != 0);
            bool itemsExist = (listView_main.Items.Count != 0);
            button_view.Enabled = itemsAreSelected;
            button_remove.Enabled = itemsAreSelected;
            button_clear.Enabled = itemsExist;
            button_resize.Enabled = itemsExist;
            button1.Text = InputImages.Count.ToString() + " images";
        }

        #region Event Handlers
        private void Form_Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveSettings();
        }

        private void button_add_Click(object sender, EventArgs e)
        {
            if (openFileDialog_main.ShowDialog() == DialogResult.OK)
            {
                LoadImages(openFileDialog_main.FileNames);
                listView_main.Focus();
            }
        }

        private void comboBox_view_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateListView();
        }

        private void listView_main_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateButtons();
        }

        private void button_about_Click(object sender, EventArgs e)
        {
            new Form_About().ShowDialog();
        }

        private void button_resize_Click(object sender, EventArgs e)
        {
            new Form_Resize(InputImages.ToArray()).ShowDialog();
        }

        private void button_remove_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in listView_main.SelectedItems)
            {
                listView_main.Items.Remove(item);
                imageList_main.Images.RemoveByKey(item.ImageKey);
                imageList_backup.Images.RemoveByKey(item.ImageKey);
                InputImages.RemoveByTag<String>(item.ImageKey);
            }
            UpdateButtons();
        }

        private void button_clear_Click(object sender, EventArgs e)
        {
            listView_main.Items.Clear();
            imageList_main.Images.Clear();
            imageList_backup.Images.Clear();
            InputImages.Clear();
            UpdateButtons();
        }

        private void Form_Main_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = e.Data.GetDataPresent(DataFormats.FileDrop)
                ? DragDropEffects.Copy : DragDropEffects.None;
        }

        private void Form_Main_DragDrop(object sender, DragEventArgs e)
        {
            string[] paths = (string[])e.Data.GetData(DataFormats.FileDrop);
            LoadImages(paths);
        }

        private void button_view_Click(object sender, EventArgs e)
        {
            string imageKey = listView_main.SelectedItems[0].ImageKey;
            Image imageToView = InputImages.FindByTag(imageKey);
            new Form_View(imageToView).ShowDialog();
        }

        private void listView_main_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            button_view.PerformClick();
        }
        #endregion
    }
}

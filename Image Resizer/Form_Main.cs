using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Linq;
using System.Collections.Generic;
using ImageResizer.Properties;

namespace ImageResizer
{
    public partial class Form_Main : Form
    {
        public List<Image> Images { get; set; }

        public Form_Main()
        {
            InitializeComponent();
            this.Images = new List<Image>();
            Initialize_comboBox_view();
            Initialize_listView_main();
            LoadSettings();
        }

        private void LoadSettings()
        {
            comboBox_view.SelectedValue = (Utils.ViewX)Settings.Default.View;
        }

        private void LoadImages(params string[] paths)
        {
            foreach (string path in paths)
            {
                string filename = Path.GetFileName(path);
                string size = path.ToFileSizeFormat();
                Image image = Image.FromFile(path);
                string dimensions = image.GetDimensionsString();

                image.Tag = filename;
                this.Images.Add(image);

                if (!listView_main.Items.ContainsKey(path))
                {
                    var item = new ListViewItem();
                    item.Name = path;
                    item.ImageKey = path;
                    item.Text = filename;
                    item.ToolTipText = filename;
                    item.SubItems.AddRange(new[] { dimensions, size });
                    listView_main.Items.Add(item);

                    imageList_main.Images.Add(item.ImageKey, image);
                    imageList_backup.Images.Add(item.ImageKey, image);
                }
            }
            imageList_backup.ImageSize = new Size(256, 256);
        }

        private void Initialize_comboBox_view()
        {
            comboBox_view.DataSource = Utils.ViewTypes;
            comboBox_view.DisplayMember = "Title";
            comboBox_view.ValueMember = "Value";
        }

        private void Initialize_listView_main()
        {
            ColumnHeader nameColumn = new ColumnHeader();
            nameColumn.Text = "Name";
            nameColumn.Width = 200;

            ColumnHeader dimensionsColumn = new ColumnHeader();
            dimensionsColumn.Text = "Dimensions";
            dimensionsColumn.Width = 200;

            ColumnHeader sizeColumn = new ColumnHeader();
            sizeColumn.Text = "Size";
            sizeColumn.Width = 100;

            listView_main.Columns.AddRange(new[] {
                nameColumn, dimensionsColumn, sizeColumn 
            });

            listView_main.FullRowSelect = true;
        }

        private void button_add_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = true;
            openFileDialog.Filter = "Image Files (*.jpg; *.jpeg; *.png; *.gif; *.bmp)|*.jpg; *.jpeg; *.png; *.gif; *.bmp";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                LoadImages(openFileDialog.FileNames);
            }
        }

        private void comboBox_view_SelectedIndexChanged(object sender, EventArgs e)
        {
            var viewType = (Utils.ViewType)comboBox_view.SelectedItem;
            if ((int)viewType.Value < 5)
            {
                listView_main.View = (View)viewType.Value;
            }
            else
            {
                listView_main.View = View.LargeIcon;
            }
            imageList_main.ImageSize = viewType.ImageSize;
            imageList_main.Images.Clear();
            foreach (string path in imageList_backup.Images.Keys)
            {
                imageList_main.Images.Add(path, imageList_backup.Images[path]);
            }
        }

        private void listView_main_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (listView_main.SelectedIndices.Count != 0)
            //{
            //    int index = listView_main.SelectedIndices[0];
            //    string key = listView_main.Items[index].ImageKey;
            //}
        }

        private void button_about_Click(object sender, EventArgs e)
        {
            new Form_About().ShowDialog();
        }

        private void button_resize_Click(object sender, EventArgs e)
        {
            //if (listView_main.Items.Count == 0)
            //{
            //    MessageBox.Show("No images", "Alert",
            //        MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //}
            //else
            {
                new Form_Resize(this.Images.ToArray()).ShowDialog();
            }
        }

        private void button_clear_Click(object sender, EventArgs e)
        {
            listView_main.Items.Clear();
            imageList_main.Images.Clear();
            imageList_backup.Images.Clear();
            this.Images.Clear();
        }

        private void Form_Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            Settings.Default.View = (int)comboBox_view.SelectedValue;
            Settings.Default.Save();
        }

        private void Form_Main_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void Form_Main_DragDrop(object sender, DragEventArgs e)
        {
            string[] paths = (string[])e.Data.GetData(DataFormats.FileDrop);
            LoadImages(paths);
        }
    }
}

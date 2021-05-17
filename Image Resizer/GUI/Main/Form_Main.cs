using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace ImageResizer
{
    public partial class Form_Main : Form
    {
        public Form_Main()
        {
            InitializeComponent();
            SetupControls();
            LoadSettings();
            UpdateControls();
        }

        private void Form_Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveSettings();
        }

        private void comboBox_view_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChangeViewMode();
        }

        private void listView_main_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateControls();
        }

        private void button_about_Click(object sender, EventArgs e)
        {
            ShowAboutDialog();
        }

        private void button_resize_Click(object sender, EventArgs e)
        {
            ShowResizeDialog();
        }

        private void button_remove_Click(object sender, EventArgs e)
        {
            RemoveSelectedItems();
            UpdateControls();
        }

        private void button_clear_Click(object sender, EventArgs e)
        {
            RemoveAllItems();
            UpdateControls();
        }

        private void button_add_Click(object sender, EventArgs e)
        {
            AddItemsByFileBrowsing();
        }

        private void Form_Main_DragEnter(object sender, DragEventArgs e)
        {
            e.AllowFiles();
        }

        private void Form_Main_DragDrop(object sender, DragEventArgs e)
        {
            AddItemsByFileDragDroping(e.GetPaths().ToFilePathsOnly());
        }

        private void button_view_Click(object sender, EventArgs e)
        {
            ViewSelectedItem();
        }

        private void listView_main_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ViewSelectedItem();
        }

        private void backgroundWorker_main_DoWork(object sender, DoWorkEventArgs e)
        {
            BeginLoadImage(e);
        }

        private void backgroundWorker_main_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            ProgressLoadImage(e);
            UpdateControls();

        }

        private void backgroundWorker_main_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            EndLoadImage(e);
            UpdateControls();
        }
    }
}

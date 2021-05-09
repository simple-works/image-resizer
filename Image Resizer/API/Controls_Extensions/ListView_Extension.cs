using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Collections.Generic;

namespace ImageResizer
{
    public static partial class API
    {
        public static void AddColumn(this ListView listView,
            string columnText = "New Column", int columnWidth = 100)
        {
            ColumnHeader column = new ColumnHeader();
            column.Text = columnText;
            column.Width = columnWidth;
            listView.Columns.Add(column);
        }

        public static ImageList GetBackupImageList(this ListView listView)
        {
            if (listView.Tag == null)
            {
                listView.Tag = new ImageList();
                ImageList bckImageList = listView.Tag as ImageList;
                bckImageList.ImageSize = listView.LargeImageList.ImageSize;
                bckImageList.ColorDepth = listView.LargeImageList.ColorDepth;
                return bckImageList;
            }
            return listView.Tag as ImageList;
        }

        public static void SetViewMode(this ListView listView, ViewMode viewMode)
        {
            listView.View = ((int)viewMode.ViewX < 5)
                ? (View)viewMode.ViewX : View.LargeIcon;
            listView.LargeImageList.ImageSize = viewMode.ImageSize;
            listView.LargeImageList.FillWith(listView.GetBackupImageList());
        }

        public static void AddImageItem(this ListView listView, Image image)
        {
            string filePath = image.GetFilePath();
            if (!listView.Items.ContainsKey(filePath))
            {
                ListViewItem item = new ListViewItem();
                item.Name = filePath;
                item.ImageKey = filePath;
                item.Text = item.ToolTipText = Path.GetFileName(filePath);
                item.SubItems.AddRange(new[] { 
                    image.GetSizeString(), 
                    filePath.ToFileSizeString(),
                    image.GetEncoder().MimeType
                });
                listView.Items.Add(item);
                listView.LargeImageList.AddImage(image);
                listView.GetBackupImageList().AddImage(image);
            }
        }

        public static void RemoveImageItem(this ListView listView, ListViewItem item)
        {
            listView.Items.Remove(item);
            listView.LargeImageList.Images.RemoveByKey(item.ImageKey);
            listView.GetBackupImageList().Images.RemoveByKey(item.ImageKey);
        }

        public static void ClearImageItems(this ListView listView)
        {
            listView.Items.Clear();
            listView.LargeImageList.Images.Clear();
            listView.GetBackupImageList().Images.Clear();
        }
    }
}

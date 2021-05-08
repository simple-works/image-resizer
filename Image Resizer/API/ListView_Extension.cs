using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Collections.Generic;

namespace ImageResizer
{
    public static partial class API
    {
        public enum ViewX
        {
            MediumIcon = 0,
            Details = 1,
            SmallIcon = 2,
            List = 3,
            Tile = 4,
            LargeIcon = 5,
            ExtraLargeIcon = 6
        }
        public class ViewType
        {
            public string Title { get; set; }
            public ViewX ViewX { get; set; }
            public Size ImageSize { get; set; }
            public ViewType(string title, ViewX viewX, Size imageSize)
            {
                this.Title = title;
                this.ViewX = viewX;
                this.ImageSize = imageSize;
            }
        }
        public static ViewType[] ViewTypes { get; set; }

        static API()
        {
            ViewTypes = new[]
            {
                new ViewType("Medium Icons", ViewX.MediumIcon, new Size(64, 64)),
                new ViewType("Details", ViewX.Details, new Size(32, 32)),
                new ViewType("Small Icons", ViewX.SmallIcon, new Size(32, 32)),
                new ViewType("List", ViewX.List, new Size(32, 32)),
                new ViewType("Tile", ViewX.Tile, new Size(32, 32)),
                new ViewType("Large Icons", ViewX.LargeIcon, new Size(128, 128)),
                new ViewType("Extra Large Icons", ViewX.ExtraLargeIcon, new Size(256, 256))
            };
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

        public static void Setup(this ListView listView)
        {
            ColumnHeader nameColumn = new ColumnHeader();
            nameColumn.Text = "Name";
            nameColumn.Width = 200;

            ColumnHeader dimensionsColumn = new ColumnHeader();
            dimensionsColumn.Text = "Dimensions";
            dimensionsColumn.Width = 100;

            ColumnHeader sizeColumn = new ColumnHeader();
            sizeColumn.Text = "Size";
            sizeColumn.Width = 100;

            ColumnHeader formatColumn = new ColumnHeader();
            formatColumn.Text = "Format";
            formatColumn.Width = 100;

            listView.Columns.AddRange(new[] {
                nameColumn, 
                dimensionsColumn, 
                sizeColumn,
                formatColumn
            });

            listView.FullRowSelect = true;
        }

        public static void SetViewX(this ListView listView, ViewX viewX)
        {
            listView.View = ((int)viewX < 5) ? (View)viewX : View.LargeIcon;
        }

        public static void SetImageSize(this ListView listView, Size imageSize)
        {
            listView.LargeImageList.ImageSize = imageSize;
            listView.LargeImageList.FillWith(listView.Tag as ImageList);
        }

        public static void SetViewType(this ListView listView, ViewType viewType)
        {
            listView.SetViewX(viewType.ViewX);
            listView.SetImageSize(viewType.ImageSize);
        }

        public static void AddImageItem(this ListView listView, Image image)
        {
            string filePath = image.Tag as string;
            if (!listView.Items.ContainsKey(filePath))
            {
                var item = new ListViewItem();
                item.Name = filePath;
                item.ImageKey = filePath;
                item.Text = item.ToolTipText = Path.GetFileName(filePath);
                item.SubItems.AddRange(new[] { 
                    image.GetSizeString(), 
                    filePath.ToFileSizeString(),
                    image.GetFromat()
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

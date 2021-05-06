using System.Drawing;
using System.Windows.Forms;

namespace ImageResizer
{
    public static partial class Utils
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

        static Utils()
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

        public static void SetViewX(this ListView listView, ViewX viewX)
        {
            listView.View = ((int)viewX < 5) ? (View)viewX : View.LargeIcon;
        }

        public static void SetImageSize(this ListView listView, Size imageSize,
            ImageList bckImageList)
        {
            ImageList srcImageList = listView.LargeImageList;
            srcImageList.ImageSize = imageSize;
            srcImageList.Images.Clear();
            foreach (string key in bckImageList.Images.Keys)
            {
                srcImageList.Images.Add(key, bckImageList.Images[key]);
            }
        }

        public static void SetColumns(this ListView listview)
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

            listview.Columns.AddRange(new[] {
                nameColumn, 
                dimensionsColumn, 
                sizeColumn,
                formatColumn
            });

            listview.FullRowSelect = true;
        }

        public static void SetData(this ComboBox comboBox)
        {
            comboBox.DataSource = Utils.ViewTypes;
            comboBox.DisplayMember = "Title";
            comboBox.ValueMember = "ViewX";
        }
    }
}

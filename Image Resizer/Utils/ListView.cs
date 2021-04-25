
using System.Drawing;
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
            public ViewX Value { get; set; }
            public Size ImageSize { get; set; }
            public ViewType(string title, ViewX value, Size imageSize)
            {
                this.Title = title;
                this.Value = value;
                this.ImageSize = imageSize;
            }
        }

        public static ViewType[] ViewTypes = new[]
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
}

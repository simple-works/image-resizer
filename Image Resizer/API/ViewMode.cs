using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace ImageResizer
{
    public static partial class API
    {
        public static ViewMode[] ViewModes { get; set; }

        static API()
        {
            ViewModes = new[]
            {
                new ViewMode("Medium Icons", ViewX.MediumIcon, new Size(64, 64)),
                new ViewMode("Details", ViewX.Details, new Size(32, 32)),
                new ViewMode("Small Icons", ViewX.SmallIcon, new Size(32, 32)),
                new ViewMode("List", ViewX.List, new Size(32, 32)),
                new ViewMode("Tile", ViewX.Tile, new Size(32, 32)),
                new ViewMode("Large Icons", ViewX.LargeIcon, new Size(128, 128)),
                new ViewMode("Extra Large Icons", ViewX.ExtraLargeIcon, new Size(256, 256))
            };
        }

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

        public class ViewMode
        {
            public string Title { get; set; }
            public ViewX ViewX { get; set; }
            public Size ImageSize { get; set; }

            public ViewMode(string title, ViewX viewX, Size imageSize)
            {
                this.Title = title;
                this.ViewX = viewX;
                this.ImageSize = imageSize;
            }
        }
    }
}

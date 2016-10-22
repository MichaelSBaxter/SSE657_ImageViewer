using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageViewer
{
    public class ActualSizeStrategy : IImageSizingStrategy
    {
        public ImageGeometry GetGeometry(double displayWidth, double displayHeight, double imageWidth, double imageHeight)
        {
            var geo = new ImageGeometry();

            geo.Height = imageHeight;
            geo.Width = imageWidth;

            geo.Left = (imageWidth > displayWidth) ? 0 : (int)((displayWidth - imageWidth) / 2);
            geo.Top = (imageHeight > displayHeight) ? 0 : (int)((displayHeight - imageHeight) / 2);

            return geo;
        }
    }
}

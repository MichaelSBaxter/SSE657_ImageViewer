using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageViewer
{
    public class FitWindowStrategy : IImageSizingStrategy
    {
        public ImageGeometry GetGeometry(double displayWidth, double displayHeight, double imageWidth, double imageHeight)
        {
            return new ImageGeometry(0, 0, displayWidth, displayHeight);       
        }
    }
}

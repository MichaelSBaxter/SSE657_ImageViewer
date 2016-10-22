using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageViewer
{
    public struct ImageGeometry
    {
        public int Top;
        public int Left;
        public double Width;
        public double Height;

        public ImageGeometry(int top, int left, double width, double height)
        {
            Top = top;
            Left = left;
            Width = width;
            Height = height;
        }
    }
    
    public interface IImageSizingStrategy
    {
        ImageGeometry GetGeometry(double displayWidth, double displayHeight, double imageWidth, double imageHeight);
    }
}

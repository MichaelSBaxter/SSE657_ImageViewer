using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace ImageViewer
{
    class ImageDisplayInfo : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private ImageSource source;
        public ImageSource Source
        {
            get { return source; }
            set
            {
                source = value;
                OnPropertyChanged("Source");
            }
        }
        private string path;
        public string Path
        {
            get { return path; }
            set
            {
                path = value;
                OnPropertyChanged("Path");
            }
        }

        private int left;
        public int Left
        {
            get { return left; }
            set
            {
                left = value;
                OnPropertyChanged("Left");
            }
        }

        private int top;
        public int Top
        {
            get { return top; }
            set
            {
                top = value;
                OnPropertyChanged("Top");
            }
        }

        private double width;
        public double Width
        {
            get { return width; }
            set
            {
                width = value;
                OnPropertyChanged("Width");
            }
        }

        private double height;
        public double Height
        {
            get { return height; }
            set
            {
                height = value;
                OnPropertyChanged("Height");
            }
        }

        public ImageDisplayInfo()
        {
            Path = "";
            this.Top = 0;
            this.Left = 0;
            this.Width = 0;
            this.Height = 0;
        }

        public ImageDisplayInfo(string path)
        {
            Path = path;
            this.Top = 0;
            this.Left = 0;
            this.Width = 0;
            this.Height = 0;
        }

        public ImageDisplayInfo(string path, int top, int left)
        {
            this.Path = path;
            this.Top = top;
            this.Left = left;
            this.Width = 0;
            this.Height = 0;
        }

        public ImageDisplayInfo(string path, int top, int left, double width, double height)
        {
            this.Path = path;
            this.Top = top;
            this.Left = left;
            this.Width = width;
            this.Height = height;
        }

        public ImageDisplayInfo(ImageSource source, string path, int top, int left, double width, double height)
        {
            this.Source = source;
            this.Path = path;
            this.Top = top;
            this.Left = left;
            this.Width = width;
            this.Height = height;
        }

        private void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler propertyChanged = PropertyChanged;
            if (propertyChanged != null)
                propertyChanged(this, new PropertyChangedEventArgs(name));
        }
    }
}

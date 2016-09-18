using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace ImageViewer
{
    enum ImageDisplayMode
    {
        Actual,
        Window
    }

    class ImageDisplayManager : INotifyPropertyChanged
    {
        private System.Windows.Controls.ScrollBarVisibility verticalScrollBar = System.Windows.Controls.ScrollBarVisibility.Hidden;
        public System.Windows.Controls.ScrollBarVisibility VerticalScrollBar
        {
            get { return verticalScrollBar; }
            set
            {
                verticalScrollBar = value;
                OnPropertyChanged("VerticalScrollBar");
            }
        }

        public System.Windows.Controls.ScrollBarVisibility horizontalScrollBar = System.Windows.Controls.ScrollBarVisibility.Hidden;
        public System.Windows.Controls.ScrollBarVisibility HorizontalScrollBar
        {
            get { return horizontalScrollBar; }
            set
            {
                horizontalScrollBar = value;
                OnPropertyChanged("HorizontalScrollBar");
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<ImageDisplayInfo> DisplayImages;

        public ImageDisplayMode DisplayMode;

        public ImageDisplayManager()
        {
            DisplayImages = new ObservableCollection<ImageDisplayInfo>();
            DisplayMode = ImageDisplayMode.Window;
        }

        public void Resize(ImageDisplayMode displayMode, double width, double height)
        {
            if(displayMode == ImageDisplayMode.Window)
            {
                foreach(ImageDisplayInfo imageInfo in DisplayImages)
                {
                    imageInfo.Height = height;
                    imageInfo.Width = width;

                    VerticalScrollBar = System.Windows.Controls.ScrollBarVisibility.Hidden;
                    HorizontalScrollBar = System.Windows.Controls.ScrollBarVisibility.Hidden;
                }
            }
            else if(displayMode == ImageDisplayMode.Actual)
            {
                foreach (ImageDisplayInfo imageInfo in DisplayImages)
                {
                    imageInfo.Height = imageInfo.Source.Height;
                    imageInfo.Width = imageInfo.Source.Width;

                    if(imageInfo.Height > height)
                    {
                        VerticalScrollBar = System.Windows.Controls.ScrollBarVisibility.Visible;
                    }
                    else
                    {
                        VerticalScrollBar = System.Windows.Controls.ScrollBarVisibility.Hidden;
                    }

                    if (imageInfo.Width > width)
                    {
                        HorizontalScrollBar = System.Windows.Controls.ScrollBarVisibility.Visible;
                    }
                    else
                    {
                        HorizontalScrollBar = System.Windows.Controls.ScrollBarVisibility.Hidden;
                    }
                }
            }
        }

        public void RefitWindow(double width, double height)
        {
            if(DisplayMode == ImageDisplayMode.Window)
            {
                Resize(DisplayMode, width, height);
            }
        }

        public void ChangeDisplayMode(double width, double height)
        {
            if (DisplayMode == ImageDisplayMode.Actual)
                DisplayMode = ImageDisplayMode.Window;
            else if(DisplayMode == ImageDisplayMode.Window)
                DisplayMode = ImageDisplayMode.Actual;

            Resize(DisplayMode, width, height);
        }

        public void SetSingleImage(string path)
        {
            ImageSource image = new BitmapImage(new Uri(path));
            ImageDisplayInfo imageInfo = new ImageDisplayInfo(image, path, 0, 0, image.Width, image.Height);
            
            DisplayImages.Clear();
            DisplayImages.Add(imageInfo);
        }

        public void SetSingleImage(string path, double width, double height)
        {
            ImageSource image = new BitmapImage(new Uri(path));

            int left = (int)(image.Width - width) / 2;
            int top = (int)(image.Height - height) / 2;

            ImageDisplayInfo imageInfo = new ImageDisplayInfo(image, path, 0, -1, width, height);

            DisplayImages.Clear();
            DisplayImages.Add(imageInfo);
        }

        private void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler propertyChanged = PropertyChanged;
            if (propertyChanged != null)
                propertyChanged(this, new PropertyChangedEventArgs(name));
        }
    }
}

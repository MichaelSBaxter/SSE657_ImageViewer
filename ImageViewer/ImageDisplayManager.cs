using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

    public class ImageDisplayManager
    {
        public ObservableCollection<ImageDisplayInfo> DisplayImages;

        private ImageDisplayMode displayMode;

        private ImageDatabase loadedImages;

        public ImageDisplayManager()
        {
            DisplayImages = new ObservableCollection<ImageDisplayInfo>();
            loadedImages = new ImageDatabase();
            displayMode = ImageDisplayMode.Window;
        }

        public void Resize(double width, double height)
        {
            if(displayMode == ImageDisplayMode.Window)
            {
                foreach(ImageDisplayInfo imageInfo in DisplayImages)
                {
                    imageInfo.Height = height;
                    imageInfo.Width = width;
                    imageInfo.Top = 0;
                    imageInfo.Left = 0;
                }
            }
            else if(displayMode == ImageDisplayMode.Actual)
            {
                foreach (ImageDisplayInfo imageInfo in DisplayImages)
                {
                    imageInfo.Height = imageInfo.Source.Height;
                    imageInfo.Width = imageInfo.Source.Width;

                    if(width > imageInfo.Source.Width)
                    {
                        imageInfo.Left = (int) ((width - imageInfo.Source.Width) / 2);
                    }
                    else
                    {
                        imageInfo.Left = 0;
                    }

                    if(height > imageInfo.Source.Height)
                    {
                        imageInfo.Top = (int)((height - imageInfo.Source.Height) / 2);
                    }
                    else
                    {
                        imageInfo.Top = 0;
                    }
                }
            }
        }

        public void NextDisplayMode(double width, double height)
        {
            if (displayMode == ImageDisplayMode.Actual)
                displayMode = ImageDisplayMode.Window;
            else if (displayMode == ImageDisplayMode.Window)
                displayMode = ImageDisplayMode.Actual;
            
            Resize(width, height);
        }

        public void LoadNewImage(string path, double width, double height)
        {
            loadedImages.LoadNewImage(path);
            SetDisplayedImage(path, width, height);
        }

        public void SetDisplayedImage(string path, double width, double height)
        {
            ImageSource image = loadedImages.GetImage(path);
            displayMode = ImageDisplayMode.Window;

            if (image != null)
            {
                ChangeDisplayedImage(image, width, height);
            }
        }

        public void SetDisplayedImageNext(double width, double height)
        {
            ImageSource image = loadedImages.GetNextImage();

            if(image != null)
            {
                ChangeDisplayedImage(image, width, height);
            }
        }

        public void SetDisplayedImagePrevious(double width, double height)
        {
            ImageSource image = loadedImages.GetPreviousImage();

            if (image != null)
            {
                ChangeDisplayedImage(image, width, height);
            }
        }

        private void ChangeDisplayedImage(ImageSource image, double width, double height)
        {
            ImageDisplayInfo imageInfo = new ImageDisplayInfo(image, 0, 0, width, height);

            if((width > image.Width) && (height > image.Height))
                displayMode = ImageDisplayMode.Actual;                   
            else
                displayMode = ImageDisplayMode.Window;                   

            DisplayImages.Clear();
            DisplayImages.Add(imageInfo);
            Resize(width, height);
        }
    }
}

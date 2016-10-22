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
    public class ImageDisplayManager
    {
        public ObservableCollection<ImageDisplayInfo> DisplayImages;

        private ImageDatabase loadedImages;

        private FitWindowStrategy fitWindowStrategy;
        private ActualSizeStrategy actualSizeStrategy;
        private IImageSizingStrategy currentSizingStrategy;

        private double displayWidth;
        private double displayHeight;

        public ImageDisplayManager()
        {
            DisplayImages = new ObservableCollection<ImageDisplayInfo>();
            loadedImages = new ImageDatabase();
            fitWindowStrategy = new FitWindowStrategy();
            actualSizeStrategy = new ActualSizeStrategy();
            currentSizingStrategy = fitWindowStrategy;
            displayWidth = 0;
            displayHeight = 0;
        }

        public void UpdateDisplaySize(double width, double height)
        {
            displayWidth = width;
            displayHeight = height;
        }

        public void Resize()
        {
            foreach (ImageDisplayInfo imageInfo in DisplayImages)
            {
                var geo = currentSizingStrategy.GetGeometry(displayWidth, displayHeight, imageInfo.Source.Width, imageInfo.Source.Height);

                imageInfo.Height = geo.Height;
                imageInfo.Width = geo.Width;
                imageInfo.Top = geo.Top;
                imageInfo.Left = geo.Left;
            }   
        }

        public void NextDisplayMode()
        {
            if (currentSizingStrategy == actualSizeStrategy)
                currentSizingStrategy = fitWindowStrategy;
            else if (currentSizingStrategy == fitWindowStrategy)
                currentSizingStrategy = actualSizeStrategy;
        }

        public void LoadNewImage(string path)
        {
            loadedImages.LoadNewImage(path);
            SetDisplayedImage(path);
        }

        public void SetDisplayedImage(string path)
        {             
            ChangeDisplayedImage(loadedImages.GetImage(path));
        }

        public void SetDisplayedImageNext()
        {
            ChangeDisplayedImage(loadedImages.GetNextImage());
        }

        public void SetDisplayedImagePrevious()
        {
            ChangeDisplayedImage(loadedImages.GetPreviousImage());
        }

        private void ChangeDisplayedImage(ImageSource image)
        {
            if(image != null)
            {
                ImageDisplayInfo imageInfo = new ImageDisplayInfo(image, 0, 0, displayWidth, displayHeight);

                if ((displayWidth > image.Width) && (displayHeight > image.Height))
                    currentSizingStrategy = actualSizeStrategy;
                else
                    currentSizingStrategy = fitWindowStrategy;

                DisplayImages.Clear();
                DisplayImages.Add(imageInfo);
            }
        }
    }
}

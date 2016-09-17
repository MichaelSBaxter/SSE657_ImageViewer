using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace ImageViewer
{
    class ImageManager : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        //private BackgroundWorker imageLoader;

        /*private string currentImage;
        public string CurrentImage
        {
            get { return currentImage; }
            private set
            {
                currentImage = value;
                OnPropertyChanged("CurrentImage");
            }
        }*/

        private int currentImageHeight;
        public int CurrentImageHeight
        {
            get { return currentImageHeight; }
            private set
            {
                currentImageHeight = value;
                OnPropertyChanged("CurrentImageHeight");
            }
        }

        private int currentImageWidth;
        public int CurrentImageWidth
        {
            get { return currentImageWidth; }
            private set
            {
                currentImageWidth = value;
                OnPropertyChanged("CurrentImageWidth");
            }
        }

        private ImageSource currentImage;
        public ImageSource CurrentImage
        {
            get { return currentImage; }
            private set
            {
                currentImage = value;
                OnPropertyChanged("CurrentImage");
            }   
        }

        //private bool isLoading = false;

        public ImageManager()
        {
            currentImage = null;
            currentImageWidth = 0;
            currentImageHeight = 0;

            //imageLoader = new BackgroundWorker();
            //imageLoader.WorkerSupportsCancellation = false;
            //imageLoader.WorkerReportsProgress = false;
            //imageLoader.DoWork += new DoWorkEventHandler(imageLoader_DoWork);
        }

        public void LoadImage(string filePath)
        {
            CurrentImage = new BitmapImage(new Uri(filePath));
            
            CurrentImageHeight = (int)CurrentImage.Height;
            CurrentImageWidth = (int)CurrentImage.Width;
        }

        /*private void imageLoader_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;

            if(e.Argument is string)
            {
                
                string filePath = e.Argument as string;
                ImageSource newImage = new BitmapImage(new Uri(filePath));
                Application.Current.Dispatcher.Invoke(new Action(() => CurrentImage = newImage));
            }  
        }

        private void imageLoader_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            isLoading = false;
        }*/

        private void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler propertyChanged = PropertyChanged;
            if (propertyChanged != null)
                propertyChanged(this, new PropertyChangedEventArgs(name));
        }
    }
}

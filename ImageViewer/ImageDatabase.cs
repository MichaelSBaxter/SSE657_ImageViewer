using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace ImageViewer
{  
    public class ImageDatabase
    {
        private List<ImageSource> images;
        public List<ImageSource> Images
        {
            get { return images; }
        }

        private int currentImageIndex;
        private string currentDirectory;

        public ImageDatabase()
        {
            images = new List<ImageSource>();
            currentImageIndex = 0;
            currentDirectory = "";
        }
  
        public ImageDatabase(string filePath)
        {
            images = new List<ImageSource>();

            LoadNewImage(filePath);
        }

        public void LoadNewImage(string filePath)
        {
            string folderPath = Path.GetDirectoryName(filePath);

            if(Directory.Exists(folderPath))
            {             
                LoadDirectory(folderPath);
                currentDirectory = folderPath;
                currentImageIndex = GetImageIndex(filePath);
            }
        }

        private void LoadDirectory(string folderPath)
        {
            string[] files = Directory.GetFiles(folderPath);
            ExtensionManager manager = ExtensionManager.GetInstance();

            images.Clear();

            foreach(string file in files)
            {
                string extension = Path.GetExtension(file);

                if (manager.IsValidExtension(extension))
                {
                    var factory = ImageLoadingFactory.GetInstance();
                    var adapter = factory.GetImageLoadingAdapter(file);

                    ImageSource image = adapter.LoadImage(file);
                    images.Add(image);
                }
            }
        }

        private int GetImageIndex(string filePath)
        {
            for (int i = 0; i < images.Count(); i++)
            {
                string imagePath = images[i].ToString().Substring(8);
                if (NormalizePath(imagePath) == NormalizePath(filePath))
                    return i;
            }

            return -1;
        }

        private string NormalizePath(string path)
        {
            return Path.GetFullPath(new Uri(path).LocalPath).TrimEnd(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar).ToUpperInvariant();
        }

        public ImageSource GetImage(string filePath)
        {
            int i = GetImageIndex(filePath);
            if(i >= 0)
            {
                return images[i];
            }

            return null;
        }

        public ImageSource GetNextImage()
        {           
            if(images.Count() > (currentImageIndex + 1))
            {
                currentImageIndex++;
                return images[currentImageIndex];
            }
            else if(images.Count() > 0)
            {
                currentImageIndex = 0;
                return images[currentImageIndex];
            }
            else
            {
                return null;
            }
        }

        public ImageSource GetPreviousImage()
        {
            if (currentImageIndex > 0)
            {
                currentImageIndex--;
                return images[currentImageIndex];
            }
            else if (currentImageIndex == 0 && images.Count > 0)
            {
                currentImageIndex = images.Count() - 1;
                return images[currentImageIndex];
            }
            else
            {
                return null;
            }
        }
    }
}

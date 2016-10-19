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
    public class PngLoadingAdapter : IImageLoadingAdapter
    {
        public ImageSource LoadImage(string filepath)
        {
            ExtensionManager eManager = ExtensionManager.GetInstance();

            if (eManager.GetExtensionType(filepath) != RecognizedExtension.Png)
                throw new FileFormatException();

            return new BitmapImage(new Uri(filepath));
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageViewer
{
    public class ImageLoadingFactory
    {
        static private ImageLoadingFactory instance = null;

        private IImageLoadingAdapter jpgLoadingAdapter;
        private IImageLoadingAdapter pngLoadingAdapter;

        public ImageLoadingFactory()
        {
            jpgLoadingAdapter = new JpgLoadingAdapter();
            pngLoadingAdapter = new PngLoadingAdapter();
        }

        public static ImageLoadingFactory GetInstance()
        {
            if (instance == null)
            {
                instance = new ImageLoadingFactory();
            }

            return instance;
        }

        public IImageLoadingAdapter GetImageLoadingAdapter(string file)
        {
            var extensionManager = ExtensionManager.GetInstance();

            switch(extensionManager.GetExtensionType(file))
            {
                case RecognizedExtension.Jpeg:
                    return jpgLoadingAdapter;
                case RecognizedExtension.Png:
                    return pngLoadingAdapter;
            }            
            
            return null;
        }
    }
}

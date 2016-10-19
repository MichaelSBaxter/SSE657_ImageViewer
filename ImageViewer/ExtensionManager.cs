using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageViewer
{
    public enum RecognizedExtension
    {
        Jpeg,
        Png,
        Unsupported
    }

    public class ExtensionManager
    {
        static private ExtensionManager instance = null;

        private List<string> extensions = new List<string>() { ".jpg", ".png" };
        private List<RecognizedExtension> extensionsEnums = new List<RecognizedExtension>() { RecognizedExtension.Jpeg, RecognizedExtension.Png };

        public static ExtensionManager GetInstance()
        {
            if (instance == null)
            {
                instance = new ExtensionManager();
            }

            return instance;
        }

        public string GetExtensionFilters()
        {
            int i = 0;
            string filter = "Image Files (";

            foreach(string extension in extensions)
            {
                if(i > 0)
                    filter = filter + ", ";

                filter = filter + extension; 
                i++;
            }
                
            filter = filter + ")|";

            i = 0;
            foreach(string extension in extensions)
            {
                if(i > 0)
                    filter = filter + ";";

                filter = filter + "*" + extension; 
                i++;
            }

            return filter;           
        }

        public RecognizedExtension GetExtensionType(string file)
        {
            int i;
            string extension = Path.GetExtension(file);

            for (i = 0; i < extensions.Count(); i++)
            {
                if (extension == extensions[i])
                {
                    return extensionsEnums[i];
                }
            }

            return RecognizedExtension.Unsupported;
        }

        public bool IsValidExtension(string extension)
        {
            return extensions.Contains(extension);
        }
    }
}

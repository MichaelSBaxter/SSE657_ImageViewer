using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageViewer
{  
    static class ExtensionManager
    {
        static private List<string> extensions = new List<string>() { ".jpg" };

        public static string GetExtensionFilters()
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

        public static bool isValidExtension(string extension)
        {
            return extensions.Contains(extension);
        }
    }
}

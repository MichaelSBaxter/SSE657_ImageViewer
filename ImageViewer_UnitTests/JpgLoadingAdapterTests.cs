using System;
using System.IO;
using System.Windows.Media;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ImageViewer;

namespace ImageViewer_UnitTests
{
    [TestClass]
    public class JpgLoadingAdapterTests
    {
        [TestMethod]
        public void JpgLoadingAdapter_LoadImageTest1()
        {
            JpgLoadingAdapter adapter = new JpgLoadingAdapter();

            ImageSource image = adapter.LoadImage(@"C:\Test Images\TestJpg.jpg");

            Assert.AreNotEqual(null, image, "Null image source returned");
        }

        [TestMethod]
        [ExpectedException(typeof(FileFormatException))]
        public void JpgLoadingAdapter_LoadImageTest2()
        {
            JpgLoadingAdapter adapter = new JpgLoadingAdapter();

            ImageSource image = adapter.LoadImage(@"C:\Test Images\TestTga.tga");
        }
    }
}

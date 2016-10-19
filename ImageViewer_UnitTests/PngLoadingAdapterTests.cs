using System;
using System.IO;
using System.Windows.Media;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ImageViewer;

namespace ImageViewer_UnitTests
{
    [TestClass]
    public class PngLoadingAdapterTests
    {
        [TestMethod]
        public void PngLoadingAdapter_LoadImageTest1()
        {
            PngLoadingAdapter adapter = new PngLoadingAdapter();

            ImageSource image = adapter.LoadImage(@"C:\Test Images\TestPng.png");

            Assert.AreNotEqual(null, image, "Null image source returned");
        }

        [TestMethod]
        [ExpectedException(typeof(FileFormatException))]
        public void PngLoadingAdapter_LoadImageTest2()
        {
            PngLoadingAdapter adapter = new PngLoadingAdapter();

            ImageSource image = adapter.LoadImage(@"Test Images\TestTga.tga");
        }
    }
}

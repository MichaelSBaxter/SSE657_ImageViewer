using System;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ImageViewer;

namespace ImageViewer_UnitTests
{
    [TestClass]
    public class ImageDisplayManagerTests
    {
        [TestMethod]
        public void ImageDisplayManager_LoadNewImage1()
        {
            ImageDisplayManager manager = new ImageDisplayManager();

            manager.LoadNewImage(@"C:\Test Images\TestJpg.jpg");

            Assert.AreEqual(true, manager.DisplayImages.Count > 0, "Images failed to load");
        }

        [TestMethod]
        public void ImageDisplayManager_SetDisplayedImage1()
        {
            ImageDisplayManager manager = new ImageDisplayManager();

            manager.LoadNewImage(@"C:\Test Images\TestJpg.jpg");
            manager.SetDisplayedImage(@"C:\Test Images\TestJpg.jpg");

            var a = manager.DisplayImages[0].Source.ToString();

            Assert.AreEqual("file:///C:/Test Images/TestJpg.jpg", a, "Images failed to load");
        }

        [TestMethod]
        public void ImageDisplayManager_SetDisplayedImage2()
        {
            ImageDisplayManager manager = new ImageDisplayManager();

            manager.LoadNewImage(@"C:\Test Images\TestJpg.jpg");
            manager.SetDisplayedImage(@"C:\Test Images\TestPng.png");

            var a = manager.DisplayImages[0].Source.ToString();

            Assert.AreEqual("file:///C:/Test Images/TestPng.png", a, "Images failed to load");
        }

        [TestMethod]
        public void ImageDisplayManager_SetDisplayedImageNext()
        {
            ImageDisplayManager manager = new ImageDisplayManager();

            manager.LoadNewImage(@"C:\Test Images\TestJpg.jpg");
            manager.SetDisplayedImageNext();

            var a = manager.DisplayImages[0].Source.ToString();

            Assert.AreEqual("file:///C:/Test Images/TestPng.png", a, "Images failed to load");
        }

        [TestMethod]
        public void ImageDisplayManager_SetDisplayedImagePrevious()
        {
            ImageDisplayManager manager = new ImageDisplayManager();

            manager.LoadNewImage(@"C:\Test Images\TestJpg.jpg");
            manager.SetDisplayedImagePrevious();

            var a = manager.DisplayImages[0].Source.ToString();

            Assert.AreEqual("file:///C:/Test Images/TestPng.png", a, "Images failed to load");
        }

        [TestMethod]
        public void ImageDisplayManager_Resize_Window1()
        {
            ImageDisplayManager manager = new ImageDisplayManager();

            manager.LoadNewImage(@"C:\Test Images\TestJpg.jpg");
            manager.UpdateDisplaySize(100, 100);

            manager.Resize();

            int left = manager.DisplayImages[0].Left;
            int top = manager.DisplayImages[0].Top;
            double height = manager.DisplayImages[0].Height;
            double width = manager.DisplayImages[0].Width;

            Assert.AreEqual(0, left, "Images failed to size correctly");
            Assert.AreEqual(0, top, "Images failed to size correctly");
            Assert.AreEqual(100, height, "Images failed to size correctly");
            Assert.AreEqual(100, width, "Images failed to size correctly");
        }

        [TestMethod]
        public void ImageDisplayManager_Resize_Window2()
        {
            ImageDisplayManager manager = new ImageDisplayManager();

            manager.LoadNewImage(@"C:\Test Images\TestJpg.jpg");
            manager.UpdateDisplaySize(500, 500);

            manager.Resize();

            int left = manager.DisplayImages[0].Left;
            int top = manager.DisplayImages[0].Top;
            double height = manager.DisplayImages[0].Height;
            double width = manager.DisplayImages[0].Width;

            Assert.AreEqual(0, left, "Images failed to size correctly");
            Assert.AreEqual(0, top, "Images failed to size correctly");
            Assert.AreEqual(500, height, "Images failed to size correctly");
            Assert.AreEqual(500, width, "Images failed to size correctly");
        }

        [TestMethod]
        public void ImageDisplayManager_Resize_Window3()
        {
            ImageDisplayManager manager = new ImageDisplayManager();

            manager.LoadNewImage(@"C:\Test Images\TestJpg.jpg");
            manager.NextDisplayMode();
            manager.UpdateDisplaySize(100, 100);

            manager.Resize();

            int left = manager.DisplayImages[0].Left;
            int top = manager.DisplayImages[0].Top;
            double height = manager.DisplayImages[0].Height;
            double width = manager.DisplayImages[0].Width;

            Assert.AreEqual(0, left, "Images failed to size correctly");
            Assert.AreEqual(0, top, "Images failed to size correctly");
            Assert.AreEqual(100, height, "Images failed to size correctly");
            Assert.AreEqual(100, width, "Images failed to size correctly");
        }

        [TestMethod]
        public void ImageDisplayManager_Resize_Window4()
        {
            ImageDisplayManager manager = new ImageDisplayManager();

            manager.LoadNewImage(@"C:\Test Images\TestJpg.jpg");
            manager.NextDisplayMode();
            manager.UpdateDisplaySize(500, 500);

            manager.Resize();

            int left = manager.DisplayImages[0].Left;
            int top = manager.DisplayImages[0].Top;
            double height = manager.DisplayImages[0].Height;
            double width = manager.DisplayImages[0].Width;

            Assert.AreEqual(200, left, "Images failed to size correctly");
            Assert.AreEqual(200, top, "Images failed to size correctly");
            Assert.AreEqual(100, height, "Images failed to size correctly");
            Assert.AreEqual(100, width, "Images failed to size correctly");
        }
    }
}

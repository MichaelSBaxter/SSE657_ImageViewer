using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ImageViewer;

namespace ImageViewer_UnitTests
{
    [TestClass]
    public class ImageLoadingFactoryTests
    {
        [TestMethod]
        public void ImageLoadingFactory_GetInstance_NotNull()
        {
            object instance = null;

            instance = ImageLoadingFactory.GetInstance();

            Assert.AreNotEqual(null, instance, "Null instance returned");
            Assert.AreEqual(true, instance is ImageLoadingFactory, "Instance returned is not an ImageLoadingFactory");
        }

        [TestMethod]
        public void ImageLoadingFactory_GetInstance_IsSingleton()
        {
            object instance1 = null;
            object instance2 = null;

            instance1 = ImageLoadingFactory.GetInstance();
            instance2 = ImageLoadingFactory.GetInstance();

            Assert.AreEqual(instance1, instance2, "Instance returned different references");
        }

        [TestMethod]
        public void ImageLoadingFactory_GetImageLoadingAdapter_Jpg()
        {
            string testFile = @"C:\Test Images\TestJpg.jpg";
            var instance = ImageLoadingFactory.GetInstance();

            var adapter = instance.GetImageLoadingAdapter(testFile);

            Assert.IsInstanceOfType(adapter, typeof(JpgLoadingAdapter), "Incorrect adapter type returned");
        }

        [TestMethod]
        public void ImageLoadingFactory_GetImageLoadingAdapter_Png()
        {
            string testFile = @"C:\Test Images\TestPng.png";
            var instance = ImageLoadingFactory.GetInstance();

            var adapter = instance.GetImageLoadingAdapter(testFile);

            Assert.IsInstanceOfType(adapter, typeof(PngLoadingAdapter), "Incorrect adapter type returned");
        }

        [TestMethod]
        public void ImageLoadingFactory_GetImageLoadingAdapter_Invalid()
        {
            string testFile = @"C:\Test Images\TestTga.tga";
            var instance = ImageLoadingFactory.GetInstance();

            var adapter = instance.GetImageLoadingAdapter(testFile);

            Assert.IsNull(adapter, "Incorrect adapter type returned");
        }
    }
}

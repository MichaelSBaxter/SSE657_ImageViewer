using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ImageViewer;

namespace ImageViewer_UnitTests
{
    [TestClass]
    public class ExtensionManagerTests
    {
        [TestMethod]
        public void GetInstance_NotNull()
        {
            object instance = null;

            instance = ExtensionManager.GetInstance();

            Assert.AreNotEqual(null, instance, "Null instance returned");
            Assert.AreEqual(true, instance is ExtensionManager, "Instance returned is not an ExtensionManager");
        }

        [TestMethod]
        public void GetInstance_IsSingleton()
        {
            object instance1 = null;
            object instance2 = null;

            instance1 = ExtensionManager.GetInstance();
            instance2 = ExtensionManager.GetInstance();

            Assert.AreEqual(instance1, instance2, "Instance returned different references");
        }

        [TestMethod]
        public void IsValid_Jpeg()
        {
            string testExtension = ".jpg";
            bool validExtension = false;
            ExtensionManager manager = ExtensionManager.GetInstance();

            validExtension = manager.IsValidExtension(testExtension);

            Assert.AreEqual(true, validExtension, "Valid extension returned as invalid");
        }

        [TestMethod]
        public void IsValid_Png()
        {
            string testExtension = ".png";
            bool validExtension = false;
            ExtensionManager manager = ExtensionManager.GetInstance();

            validExtension = manager.IsValidExtension(testExtension);

            Assert.AreEqual(true, validExtension, "Valid extension returned as invalid");
        }

        [TestMethod]
        public void Invalid_File()
        {
            string testExtension = ".txt";
            bool validExtension = false;
            ExtensionManager manager = ExtensionManager.GetInstance();

            validExtension = manager.IsValidExtension(testExtension);

            Assert.AreEqual(false, validExtension, "Valid extension returned as invalid");
        }

        [TestMethod]
        public void FilterString()
        {
            string validatedFilter = "Image Files (.jpg, .png)|*.jpg;*.png";
            ExtensionManager manager = ExtensionManager.GetInstance();

            string managerFilter = manager.GetExtensionFilters();

            Assert.AreEqual(validatedFilter, managerFilter, "Returned filter is incorrect");
        }

        [TestMethod]
        public void GetExtensionType_Jpeg()
        {
            string testFile = @"C:\example\not actual file\test.jpg";
            ExtensionManager manager = ExtensionManager.GetInstance();

            RecognizedExtension extension = manager.GetExtensionType(testFile);

            Assert.AreEqual(RecognizedExtension.Jpeg, extension, "Incorrect filter type returned");
        }

        [TestMethod]
        public void GetExtensionType_Png()
        {
            string testFile = @"C:\example\not actual file\test.png";
            ExtensionManager manager = ExtensionManager.GetInstance();

            RecognizedExtension extension = manager.GetExtensionType(testFile);

            Assert.AreEqual(RecognizedExtension.Png, extension, "Incorrect filter type returned");
        }

        [TestMethod]
        public void GetExtensionType_Unsupported()
        {
            string testFile = @"C:\example\not actual file\test.text";
            ExtensionManager manager = ExtensionManager.GetInstance();

            RecognizedExtension extension = manager.GetExtensionType(testFile);

            Assert.AreEqual(RecognizedExtension.Unsupported, extension, "Incorrect filter type returned");
        }
    }
}

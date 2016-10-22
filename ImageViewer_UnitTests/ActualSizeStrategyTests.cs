using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ImageViewer;

namespace ImageViewer_UnitTests
{
    [TestClass]
    public class ActualSizeStrategyTests
    {
        [TestMethod]
        public void ActualSizeStrategy_GetGeometry1()
        {
            var strategy = new ActualSizeStrategy();

            var geo = strategy.GetGeometry(100, 100, 100, 100);

            Assert.AreEqual(0, geo.Left, "Incorrect geometry returned");
            Assert.AreEqual(0, geo.Top, "Incorrect geometry returned");
            Assert.AreEqual(100, geo.Height, "Incorrect geometry returned");
            Assert.AreEqual(100, geo.Width, "Incorrect geometry returned");
        }

        [TestMethod]
        public void ActualSizeStrategy_GetGeometry2()
        {
            var strategy = new ActualSizeStrategy();

            var geo = strategy.GetGeometry(500, 500, 100, 100);

            Assert.AreEqual(200, geo.Left, "Incorrect geometry returned");
            Assert.AreEqual(200, geo.Top, "Incorrect geometry returned");
            Assert.AreEqual(100, geo.Height, "Incorrect geometry returned");
            Assert.AreEqual(100, geo.Width, "Incorrect geometry returned");
        }

        [TestMethod]
        public void ActualSizeStrategy_GetGeometry3()
        {
            var strategy = new ActualSizeStrategy();

            var geo = strategy.GetGeometry(100, 100, 500, 500);

            Assert.AreEqual(0, geo.Left, "Incorrect geometry returned");
            Assert.AreEqual(0, geo.Top, "Incorrect geometry returned");
            Assert.AreEqual(500, geo.Height, "Incorrect geometry returned");
            Assert.AreEqual(500, geo.Width, "Incorrect geometry returned");
        }
    }
}

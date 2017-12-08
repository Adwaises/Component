using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Drawing;

namespace UnitTest
{
    [TestClass]
    public class UnitTestMainComponent
    {
        [TestMethod]
        public void TestBackgroundImage()
        {
            var mainComp = new MainComp.MainComponent();

            mainComp.BackgroundImage = null;

            Assert.AreEqual(null, mainComp.BackgroundImage);
        }



    }
}

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Drawing;

namespace UnitTest
{
    [TestClass]
    public class UnitTestMainComponent
    {
        //[TestMethod]
        //public void TestBackgroundImage()
        //{
        //    var mainComp = new MainComp.MainComponent();

        //    mainComp.BackgroundImage = null;

        //    Assert.AreEqual(null, mainComp.BackgroundImage);
        //}

        [TestMethod]
        public void MainTestColorLine()
        {
            var mainComp = new MainComp.MainComponent();

            mainComp.ColorLine = Color.Blue;

            Assert.AreEqual(Color.Blue, mainComp.ColorLine);
        }

        [TestMethod]
        public void MainTestErrorNumber()
        {
            var mainComp = new MainComp.MainComponent();

            mainComp.ErrorNumber = 5;

            Assert.AreEqual(5, mainComp.ErrorNumber);
        }

        [TestMethod]
        public void MainTestErrorNumberNonTrue()
        {
            var mainComp = new MainComp.MainComponent();

            var num = mainComp.ErrorNumber;
            mainComp.ErrorNumber = 51;

            Assert.AreEqual(num, mainComp.ErrorNumber);
        }

        [TestMethod]
        public void MainTestCountNonCorrectChild()
        {
            var mainComp = new MainComp.MainComponent();

            //var num = mainComp.CountNonCorrectChild;
            mainComp.CountNonCorrectChild = 5;

            Assert.AreEqual(5, mainComp.CountNonCorrectChild);
        }

        [TestMethod]
        public void MainTestCountNonCorrectChildNonTrue()
        {
            var mainComp = new MainComp.MainComponent();

            var num = mainComp.CountNonCorrectChild;
            mainComp.CountNonCorrectChild = 51;

            Assert.AreEqual(num, mainComp.CountNonCorrectChild);
        }

    }
}

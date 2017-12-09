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

        [TestMethod]
        public void MainTestCountCorrectChild()
        {
            var mainComp = new MainComp.MainComponent();

            //var num = mainComp.CountNonCorrectChild;
            mainComp.CountCorrectChild = 3;

            Assert.AreEqual(3, mainComp.CountCorrectChild);
        }

        [TestMethod]
        public void MainTestCountCorrectChildNonTrue()
        {
            var mainComp = new MainComp.MainComponent();

            var num = mainComp.CountCorrectChild;
            mainComp.CountCorrectChild = 51;

            Assert.AreEqual(num, mainComp.CountCorrectChild);
        }

        
        [TestMethod]
        public void MainTestTextHelp()
        {
            var mainComp = new MainComp.MainComponent();

            //var num = mainComp.CountNonCorrectChild;
            mainComp.TextHelp = "HEEEELLLPPPP";

            Assert.AreEqual("HEEEELLLPPPP", mainComp.TextHelp);
        }


        //[TestMethod]
        //public void MainTestPathRightChildPicture()
        //{
        //    var mainComp = new MainComp.MainComponent();

        //    //var num = mainComp.CountNonCorrectChild;
        //    mainComp.PathRightChildPicture = "C:\\Users";

        //    Assert.AreEqual("C:\\Users", mainComp.PathRightChildPicture);
        //}

        [TestMethod]
        public void MainTestPathRightChildPictureNonTrue()
        {
            var mainComp = new MainComp.MainComponent();

            //var num = mainComp.CountNonCorrectChild;
            mainComp.PathRightChildPicture = "cfgmighi";

            Assert.AreEqual("", mainComp.PathRightChildPicture);
        }


        //[TestMethod]
        //public void MainTestPathNoRightChildPicture()
        //{
        //    var mainComp = new MainComp.MainComponent();

        //    //var num = mainComp.CountNonCorrectChild;
        //    mainComp.PathWrongChildPicture = "C:\\Users\\Andrey\\source\\repos\\RepoComponent\\MainComponent\\MainComponent\\Resources\\FaceImg";

        //    Assert.AreEqual("C:\\Users\\Andrey\\source\\repos\\RepoComponent\\MainComponent\\MainComponent\\Resources\\FaceImg", mainComp.PathWrongChildPicture);
        //}

        [TestMethod]
        public void MainTestPathNoRightChildPictureNonTrue()
        {
            var mainComp = new MainComp.MainComponent();

            //var num = mainComp.CountNonCorrectChild;
            mainComp.PathWrongChildPicture = "cfgmighi";

            Assert.AreEqual("", mainComp.PathWrongChildPicture);
        }

        [TestMethod]
        public void MainTestCaptchaPattern()
        {
            var mainComp = new MainComp.MainComponent();

            //var num = mainComp.CountNonCorrectChild;
            mainComp.CaptchaPattern = TypesOfImages.Face;

            Assert.AreEqual(TypesOfImages.Face, mainComp.CaptchaPattern);
        }


    }
}

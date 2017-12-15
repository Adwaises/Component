using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Drawing;

namespace UnitTest
{
    [TestClass]
    public class UnitTestMainComponent
    {

        [TestMethod]
        public void MainTestColorLine()
        {
            var mainComp = new HumanVerification.HumanVerification();

            mainComp.ColorLine = Color.Blue;

            Assert.AreEqual(Color.Blue, mainComp.ColorLine);
        }

        [TestMethod]
        public void MainTestErrorNumber()
        {
            var mainComp = new HumanVerification.HumanVerification();

            mainComp.ErrorNumber = 5;

            Assert.AreEqual(5, mainComp.ErrorNumber);
        }

        [TestMethod]
        public void MainTestErrorNumberNonTrue()
        {
            var mainComp = new HumanVerification.HumanVerification();

            var num = mainComp.ErrorNumber;
            mainComp.ErrorNumber = 51;

            Assert.AreEqual(num, mainComp.ErrorNumber);
        }

        [TestMethod]
        public void MainTestCountNonCorrectChild()
        {
            var mainComp = new HumanVerification.HumanVerification();
            
            mainComp.CountWrongChild = 5;

            Assert.AreEqual(5, mainComp.CountWrongChild);
        }

        [TestMethod]
        public void MainTestCountNonCorrectChildNonTrue()
        {
            var mainComp = new HumanVerification.HumanVerification();

            var num = mainComp.CountWrongChild;
            mainComp.CountWrongChild = 51;

            Assert.AreEqual(num, mainComp.CountWrongChild);
        }

        [TestMethod]
        public void MainTestCountCorrectChild()
        {
            var mainComp = new HumanVerification.HumanVerification();
            
            mainComp.CountRightChild = 3;

            Assert.AreEqual(3, mainComp.CountRightChild);
        }

        [TestMethod]
        public void MainTestCountCorrectChildNonTrue()
        {
            var mainComp = new HumanVerification.HumanVerification();

            var num = mainComp.CountRightChild;
            mainComp.CountRightChild = 51;

            Assert.AreEqual(num, mainComp.CountRightChild);
        }

        
        [TestMethod]
        public void MainTestTextHelp()
        {
            var mainComp = new HumanVerification.HumanVerification();
            
            mainComp.TextHelp = "HEEEELLLPPPP";

            Assert.AreEqual("HEEEELLLPPPP", mainComp.TextHelp);
        }


        [TestMethod]
        public void MainTestPathRightChildPictureNonTrue()
        {
            var mainComp = new HumanVerification.HumanVerification();
            
            mainComp.PathRightChildPicture = "cfgmighi";

            Assert.AreEqual("", mainComp.PathRightChildPicture);
        }


        [TestMethod]
        public void MainTestPathNoRightChildPictureNonTrue()
        {
            var mainComp = new HumanVerification.HumanVerification();
            
            mainComp.PathWrongChildPicture = "cfgmighi";

            Assert.AreEqual("", mainComp.PathWrongChildPicture);
        }

        [TestMethod]
        public void MainTestCaptchaPattern()
        {
            var mainComp = new HumanVerification.HumanVerification();
            
            mainComp.CaptchaPattern = TypesOfImages.Face;

            Assert.AreEqual(TypesOfImages.Face, mainComp.CaptchaPattern);
        }


    }
}

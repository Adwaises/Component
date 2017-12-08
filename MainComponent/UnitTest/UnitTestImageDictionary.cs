using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Drawing;
using System.Windows.Forms;
using MainComp;
using System.Collections.Generic;

namespace UnitTest
{
    [TestClass]
    public class UnitTestImageDictionary
    {
        [TestMethod]
        public void GetImageListFromPattern()
        {
            var expected = new List<Image>();

            ImageDictionary imgDict = new ImageDictionary();
            var imgList = imgDict.GetImageListFromPattern(TypesOfImages.Flower);

            Assert.AreNotEqual(imgList.Count, 0);
        }

        [TestMethod]
        public void GetRandomWrongImage()
        {
            ImageDictionary imgDict = new ImageDictionary();
            var img = imgDict.GetRandomWrongImage(TypesOfImages.Flower);

            Assert.AreNotEqual(img, null);
        }

        //[TestMethod]
        //public void FindNewCorrectImage()
        //{
        //    ImageDictionary imgDict = new ImageDictionary();
        //    var img = imgDict.FindNewCorrectImage(TypesOfImages.Flower, );

        //}
    }
}

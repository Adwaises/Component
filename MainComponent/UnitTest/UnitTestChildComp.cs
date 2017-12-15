using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Drawing;
using System.Windows.Forms;

namespace UnitTest
{
    [TestClass]
    public class UnitTestChildComp
    {
        [TestMethod]
        public void ChildTestAccessory()
        {
            var childComponent = new ChildComponent.ChildComponent();

            childComponent.Accessory = true;

            Assert.AreEqual(true, childComponent.Accessory);
        }

        [TestMethod]
        public void ChildTestOnPrimaryComp()
        {
            var childComponent = new ChildComponent.ChildComponent();

            childComponent.OnPrimaryComponent = true;

            Assert.AreEqual(true, childComponent.OnPrimaryComponent);
        }
    }
}

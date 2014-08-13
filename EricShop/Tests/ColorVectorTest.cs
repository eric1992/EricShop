using System;
using System.Drawing;
using NUnit.Framework;

namespace EricShop.Tests
{
    [TestFixture]
    class ColorVectorTest
    {
        private ARGBColorVector a;
        private ARGBColorVector b;

        [SetUp]
        public void SetUp()
        {
            a = new ARGBColorVector(Color.FromArgb(255, 20, 20, 20));
            b = new ARGBColorVector(Color.FromArgb(255, 30, 30, 30));
        }

        [Test]
        public void TestMinus()
        {
            var c = b - a;
            Assert.AreEqual(new ARGBColorVector(Color.FromArgb(0, 10, 10, 10)), c);
            c = a - b;
            Assert.AreEqual(new ARGBColorVector(Color.FromArgb(0, 10, 10, 10)), b - a);
        }

        [Test]
        public void Norm()
        {
            Assert.AreEqual(Math.Sqrt(1200), a.Norm());
        }
    }
}

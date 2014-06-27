using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using Moq;
using NUnit.Framework;
using System.Threading.Tasks;

namespace EricShop.Tests
{
    [TestFixture]
    class ColorVectorTest
    {
        private ColorVector a;
        private ColorVector b;

        [SetUp]
        public void SetUp()
        {
            a = new ColorVector(Color.FromArgb(255, 20, 20, 20));
            b = new ColorVector(Color.FromArgb(255, 30, 30, 30));
        }

        [Test]
        public void TestMinus()
        {
            var c = b - a;
            Assert.AreEqual(new ColorVector(Color.FromArgb(0, 10, 10, 10)), c);
            c = a - b;
            Assert.AreEqual(new ColorVector(Color.FromArgb(0, 10, 10, 10)), b - a);
        }
    }
}

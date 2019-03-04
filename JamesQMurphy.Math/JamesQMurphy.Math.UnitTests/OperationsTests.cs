using NUnit.Framework;
using JamesQMurphy.Math;

namespace JamesQMurphy.Math.UnitTests
{
    public class OperationsTests
    {

        [Test]
        public void AddIntegers()
        {
            Assert.AreEqual(10, Operations<int>.Add(7, 3));
        }

        [Test]
        public void AddDoubles()
        {
            Assert.AreEqual(10d, Operations<double>.Add(7d, 3d));
        }

        [Test]
        public void AddDecimals()
        {
            Assert.AreEqual(10m, Operations<decimal>.Add(7m, 3m));
        }

        [Test]
        public void MultiplyIntegers()
        {
            Assert.AreEqual(1271, Operations<int>.Multiply(31, 41));
        }

        [Test]
        public void MultiplyDoubles()
        {
            Assert.AreEqual(1271d, Operations<double>.Multiply(31d, 41d));
        }

        [Test]
        public void MultiplyDecimals()
        {
            Assert.AreEqual(1271m, Operations<decimal>.Multiply(31m, 41m));
        }
    }
}

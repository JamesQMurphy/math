using NUnit.Framework;
using JamesQMurphy.Math;

namespace JamesQMurphy.Math.UnitTests
{
    public class OperationsTests
    {

        [Test]
        public void add_int16()
        {
            Assert.AreEqual((System.Int16)10, Operations<System.Int16>.Add((System.Int16)7, (System.Int16)3));
        }

        [Test]
        public void add_int32()
        {
            Assert.AreEqual(10, Operations<System.Int32>.Add(7, 3));
        }

        [Test]
        public void add_int64()
        {
            Assert.AreEqual(10L, Operations<System.Int64>.Add(7L, 3L));
        }

        [Test]
        public void add_float()
        {
            Assert.AreEqual(10f, Operations<float>.Add(7f, 3f));
        }

        [Test]
        public void add_double()
        {
            Assert.AreEqual(10d, Operations<double>.Add(7d, 3d));
        }

        [Test]
        public void add_decimal()
        {
            Assert.AreEqual(10m, Operations<decimal>.Add(7m, 3m));
        }

        [Test]
        public void multiply_int16()
        {
            Assert.AreEqual((System.Int16)1271, Operations<System.Int16>.Multiply((System.Int16)31, (System.Int16)41));
        }

        [Test]
        public void multiply_int32()
        {
            Assert.AreEqual(1271, Operations<System.Int32>.Multiply(31, 41));
        }

        [Test]
        public void multiply_int64()
        {
            Assert.AreEqual(1271L, Operations<System.Int64>.Multiply(31L, 41L));
        }

        [Test]
        public void multiply_float()
        {
            Assert.AreEqual(1271f, Operations<float>.Multiply(31f, 41f));
        }

        [Test]
        public void multiply_double()
        {
            Assert.AreEqual(1271d, Operations<double>.Multiply(31d, 41d));
        }

        [Test]
        public void multiply_decimal()
        {
            Assert.AreEqual(1271m, Operations<decimal>.Multiply(31m, 41m));
        }
    }
}

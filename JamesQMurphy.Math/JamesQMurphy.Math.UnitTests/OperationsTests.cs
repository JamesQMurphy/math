using NUnit.Framework;
using JamesQMurphy.Math;
using System.Numerics;

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
        public void add_biginteger()
        {
            Assert.AreEqual(new BigInteger(10), Operations<BigInteger>.Add(new BigInteger(7), new BigInteger(3)));
        }

        [Test]
        public void add_complex()
        {
            Assert.AreEqual(new Complex(6, 3), Operations<Complex>.Add(new Complex(4, 7), new Complex(2, -4)));
        }

        [Test]
        public void subtract_int16()
        {
            Assert.AreEqual((System.Int16)4, Operations<System.Int16>.Subtract((System.Int16)7, (System.Int16)3));
        }

        [Test]
        public void subtract_int32()
        {
            Assert.AreEqual(4, Operations<System.Int32>.Subtract(7, 3));
        }

        [Test]
        public void subtract_int64()
        {
            Assert.AreEqual(4L, Operations<System.Int64>.Subtract(7L, 3L));
        }

        [Test]
        public void subtract_float()
        {
            Assert.AreEqual(4f, Operations<float>.Subtract(7f, 3f));
        }

        [Test]
        public void subtract_double()
        {
            Assert.AreEqual(4d, Operations<double>.Subtract(7d, 3d));
        }

        [Test]
        public void subtract_decimal()
        {
            Assert.AreEqual(4m, Operations<decimal>.Subtract(7m, 3m));
        }

        [Test]
        public void subtract_biginteger()
        {
            Assert.AreEqual(new BigInteger(4), Operations<BigInteger>.Subtract(new BigInteger(7), new BigInteger(3)));
        }

        [Test]
        public void subtract_complex()
        {
            Assert.AreEqual(new Complex(2, 11), Operations<Complex>.Subtract(new Complex(4, 7), new Complex(2, -4)));
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

        [Test]
        public void multiply_biginteger()
        {
            Assert.AreEqual(new BigInteger(1271), Operations<BigInteger>.Multiply(new BigInteger(31), new BigInteger(41)));
        }

        [Test]
        public void multiply_complex()
        {
            Assert.AreEqual(new Complex(1, 21), Operations<Complex>.Multiply(new Complex(1, 4), new Complex(5, 1)));
        }


        [Test]
        public void divide_int16()
        {
            Assert.AreEqual((System.Int16)11, Operations<System.Int16>.Divide((System.Int16)143, (System.Int16)13));
        }

        [Test]
        public void divide_int32()
        {
            Assert.AreEqual(11, Operations<System.Int32>.Divide(143, 13));
        }

        [Test]
        public void divide_int64()
        {
            Assert.AreEqual(11L, Operations<System.Int64>.Divide(143L, 13L));
        }

        [Test]
        public void divide_float()
        {
            Assert.AreEqual(11f, Operations<float>.Divide(143f, 13f));
        }

        [Test]
        public void divide_double()
        {
            Assert.AreEqual(11d, Operations<double>.Divide(143d, 13d));
        }

        [Test]
        public void divide_decimal()
        {
            Assert.AreEqual(11m, Operations<decimal>.Divide(143m, 13m));
        }

        [Test]
        public void divide_biginteger()
        {
            Assert.AreEqual(new BigInteger(11), Operations<BigInteger>.Divide(new BigInteger(143), new BigInteger(13)));
        }

        [Test]
        public void divide_complex()
        {
            Assert.AreEqual(new Complex(0.24d, 0.68d), Operations<Complex>.Divide(new Complex(3, 2), new Complex(4, -3)));
        }

        [Test]
        public void constants_int16()
        {
            Assert.AreEqual((System.Int16)0, Operations<System.Int16>.Zero);
            Assert.AreEqual((System.Int16)1, Operations<System.Int16>.One);
        }

        [Test]
        public void constants_int32()
        {
            Assert.AreEqual((System.Int32)0, Operations<System.Int32>.Zero);
            Assert.AreEqual((System.Int32)1, Operations<System.Int32>.One);
        }

        [Test]
        public void constants_int64()
        {
            Assert.AreEqual((System.Int64)0, Operations<System.Int64>.Zero);
            Assert.AreEqual((System.Int64)1, Operations<System.Int64>.One);
        }

        [Test]
        public void constants_float()
        {
            Assert.AreEqual(0f, Operations<float>.Zero);
            Assert.AreEqual(1f, Operations<float>.One);
        }

        [Test]
        public void constants_double()
        {
            Assert.AreEqual(0d, Operations<double>.Zero);
            Assert.AreEqual(1d, Operations<double>.One);
        }

        [Test]
        public void constants_decimal()
        {
            Assert.AreEqual(0m, Operations<decimal>.Zero);
            Assert.AreEqual(1m, Operations<decimal>.One);
        }

        [Test]
        public void constants_biginteger()
        {
            Assert.AreEqual(new BigInteger(0), Operations<BigInteger>.Zero);
            Assert.AreEqual(new BigInteger(1), Operations<BigInteger>.One);
        }

        [Test]
        public void constants_complex()
        {
            Assert.AreEqual(new Complex(0, 0), Operations<Complex>.Zero);
            Assert.AreEqual(new Complex(1, 0), Operations<Complex>.One);
        }
    }
}

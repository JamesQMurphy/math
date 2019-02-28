using NUnit.Framework;
using JamesQMurphy.Matrix;

namespace Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void CreateAsValueType()
        {
            Matrix<int> matrix;
            Assert.IsInstanceOf<Matrix<int>>(matrix);
        }

        [Test]
        public void DefaultIs1by1()
        {
            Matrix<int> matrix;
            Assert.AreEqual(1, matrix.RowCount);
            Assert.AreEqual(1, matrix.ColumnCount);
        }

        [Test]
        public void CanCreateArbitrarySize()
        {
            Matrix<double> matrix = new Matrix<double>(13, 21);
            Assert.AreEqual(13, matrix.RowCount);
            Assert.AreEqual(21, matrix.ColumnCount);
        }

        [Test]
        public void CanAccessElements()
        {
            double d1 = 1.0d;
            double d2 = 6.0d;
            Matrix<double> matrix = new Matrix<double>(3, 4);
            matrix[0, 0] = d1;
            matrix[2, 3] = d2;

            Assert.AreEqual(d1, matrix[0, 0]);
            Assert.AreEqual(d2, matrix[2, 3]);
        }
    }
}
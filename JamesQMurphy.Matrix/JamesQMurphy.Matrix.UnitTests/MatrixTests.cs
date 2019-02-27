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
    }
}
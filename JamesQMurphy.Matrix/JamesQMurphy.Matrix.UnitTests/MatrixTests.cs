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
        public void DefaultIsEmpty()
        {
            Matrix<int> matrix;
            Assert.AreEqual(0, matrix.RowCount);
            Assert.AreEqual(0, matrix.ColumnCount);
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

        [Test]
        public void CanInitializeWithArray()
        {
            double[,] arr = new double[,] { { 1.0d, 2.0d },
                                            { 3.0d, 4.0d },
                                            { 5.0d, 6.0d },
                                            { 7.0d, 8.0d } };

            Matrix<double> matrix = new Matrix<double>(arr);

            for(int i = 0; i < arr.GetLength(0); i++ )
            {
                for (int j = 0; j < arr.GetLength(1); j++ )
                {
                    Assert.AreEqual(arr[i, j], matrix[i, j]);
                }
            }

            // Make sure arrays are independent
            double originalValue = arr[0, 0];
            arr[0, 0] = -1000d;
            Assert.AreEqual(originalValue, matrix[0, 0]);

        }

        [Test]
        public void TestSubmatrix()
        {
            Assert.Fail();
        }
    }
}
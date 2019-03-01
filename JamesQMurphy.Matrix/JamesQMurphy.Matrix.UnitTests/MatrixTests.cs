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
        public void TestSubmatrix_3x4()
        {
            var matrix = new Matrix<double>(new double[,] { { 1d, 2d, 3d, 4d },
                                                            { 5d, 6d, 7d, 8d },
                                                            { 9d, 10d, 11d, 12d} });

            var subMatrix1 = matrix.SubMatrix(1, 2);
            Assert.AreEqual(2, subMatrix1.RowCount);
            Assert.AreEqual(3, subMatrix1.ColumnCount);
            Assert.AreEqual(1d, subMatrix1[0, 0]);
            Assert.AreEqual(2d, subMatrix1[0, 1]);
            Assert.AreEqual(4d, subMatrix1[0, 2]);
            Assert.AreEqual(9d, subMatrix1[1, 0]);
            Assert.AreEqual(10d, subMatrix1[1, 1]);
            Assert.AreEqual(12d, subMatrix1[1, 2]);

            var subMatrix2 = matrix.SubMatrix(0, 0);
            Assert.AreEqual(2, subMatrix2.RowCount);
            Assert.AreEqual(3, subMatrix2.ColumnCount);
            Assert.AreEqual(6d, subMatrix2[0, 0]);
            Assert.AreEqual(7d, subMatrix2[0, 1]);
            Assert.AreEqual(8d, subMatrix2[0, 2]);
            Assert.AreEqual(10d, subMatrix2[1, 0]);
            Assert.AreEqual(11d, subMatrix2[1, 1]);
            Assert.AreEqual(12d, subMatrix2[1, 2]);

            var subMatrix3 = matrix.SubMatrix(2, 3);
            Assert.AreEqual(2, subMatrix3.RowCount);
            Assert.AreEqual(3, subMatrix3.ColumnCount);
            Assert.AreEqual(1d, subMatrix3[0, 0]);
            Assert.AreEqual(2d, subMatrix3[0, 1]);
            Assert.AreEqual(3d, subMatrix3[0, 2]);
            Assert.AreEqual(5d, subMatrix3[1, 0]);
            Assert.AreEqual(6d, subMatrix3[1, 1]);
            Assert.AreEqual(7d, subMatrix3[1, 2]);
        }

        [Test]
        public void TestSubmatrix_1x1()
        {
            var matrix = new Matrix<double>(1, 1);
            var subMatrix = matrix.SubMatrix(0, 0);
            Assert.AreEqual(0, subMatrix.RowCount);
            Assert.AreEqual(0, subMatrix.ColumnCount);
        }

    }
}
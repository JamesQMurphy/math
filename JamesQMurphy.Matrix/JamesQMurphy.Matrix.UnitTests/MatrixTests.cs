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

        [Test]
        public void IsSquare()
        {
            Assert.IsTrue(new Matrix<int>(1, 1).IsSquare);
            Assert.IsTrue(new Matrix<int>(2, 2).IsSquare);
            Assert.IsTrue(new Matrix<int>(4, 4).IsSquare);

            Assert.IsFalse(new Matrix<int>(2, 3).IsSquare);
            Assert.IsFalse(new Matrix<int>(1, 2).IsSquare);
            Assert.IsFalse(new Matrix<int>(33, 32).IsSquare);
        }

        [Test]
        public void Determinant_Empty()
        {
            Assert.AreEqual(1d, Matrix<double>.Empty.Determinant);
        }

        [Test]
        public void Determinant_1x1()
        {
            var matrix = new Matrix<double>(new double[1, 1] { { 42d } });
            Assert.AreEqual(42d, matrix.Determinant);
        }

        [Test]
        public void Determinant_2x2()
        {
            var matrix = new Matrix<double>(new double[2, 2] { { 3d, 4d },
                                                               { 7d, 5d } });
            Assert.AreEqual(-13d, matrix.Determinant);
        }


        [Test]
        public void Determinant_3x3()
        {
            var matrix = new Matrix<double>(new double[3, 3] { { 6d, 1d, 1d },
                                                               { 4d, -2d, 5d },
                                                               { 2d, 8d, 7d } });
            Assert.AreEqual(-306d, matrix.Determinant);
        }

        [Test]
        public void Determinant_5x5()
        {
            var matrix = new Matrix<double>(new double[5, 5] { { 3d, 0d, 22d, -4d, 7d },
                                                               { 0d, 2d, 14d, 0d, -5d },
                                                               { -2d, -5d, -3d, 2d, 9d },
                                                               { 1d, 6d, -2d, 0d, -3d },
                                                               { -11d, 1d, 0d, 5d, 2d } });
            Assert.AreEqual(31170d, matrix.Determinant);
        }
    }
}
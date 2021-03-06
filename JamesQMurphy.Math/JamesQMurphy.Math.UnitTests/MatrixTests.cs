using NUnit.Framework;
using JamesQMurphy.Math;
using System.Numerics;

namespace JamesQMurphy.Math.UnitTests
{
    public class MatrixTests
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
        public void Add_1x2()
        {
            var m1 = new Matrix<double>(new double[,] { { 3d, 4d } });
            var m2 = new Matrix<double>(new double[,] { { 2d, 0d } });

            var expected = new Matrix<double>(new double[,] { { 5d, 4d } });
            Assert.AreEqual(expected, m1 + m2);
        }

        [Test]
        public void Add_3x3()
        {
            var m1 = new Matrix<double>(new double[,] { { 1d, 2d, 4d }, { 3d, 4d, 6d }, { 7d, 8d, 9d } });
            var m2 = new Matrix<double>(new double[,] { { 2d, 0d, -2d }, { 0d, 1d, 2d }, { -4d, 5d, -9d } });

            var expected = new Matrix<double>(new double[,] { { 3d, 2d, 2d }, { 3d, 5d, 8d }, { 3d, 13d, 0d } });
            Assert.AreEqual(expected, m1 + m2);
        }

        [Test]
        public void Add_wrong_dimensions()
        {
            var m1 = new Matrix<double>(new double[,] { { 1d, 2d, 4d }, { 3d, 4d, 6d }, { 7d, 8d, 9d } });
            var m2 = new Matrix<double>(new double[,] { { 2d, 0d } });

            Assert.Throws<System.InvalidOperationException>(() => { var m3 = m1 + m2; });
        }

        [Test]
        public void Subtract_3x3()
        {
            var m1 = new Matrix<double>(new double[,] { { 1d, 2d, 4d }, { 3d, 4d, 6d }, { 7d, 8d, 9d } });
            var m2 = new Matrix<double>(new double[,] { { 2d, 0d, -2d }, { 0d, 1d, 2d }, { -4d, 5d, -9d } });

            var expected = new Matrix<double>(new double[,] { { -1d, 2d, 6d }, { 3d, 3d, 4d }, { 11d, 3d, 18d } });
            Assert.AreEqual(expected, m1 - m2);
        }

        [Test]
        public void Subtract_wrong_dimensions()
        {
            var m1 = new Matrix<double>(new double[,] { { 1d, 2d, 4d }, { 3d, 4d, 6d }, { 7d, 8d, 9d } });
            var m2 = new Matrix<double>(new double[,] { { 2d, 0d } });

            Assert.Throws<System.InvalidOperationException>(() => { var m3 = m1 - m2; });
        }

        [Test]
        public void Multiply_constant_by_3x2()
        {
            var m = new Matrix<double>(new double[,] { { 1d, 2d }, { 4d, 6d }, { -4d, -2d } });

            var expected = new Matrix<double>(new double[,] { { 3d, 6d }, { 12d, 18d }, { -12d, -6d } });
            Assert.AreEqual(expected, m * 3d);
            Assert.AreEqual(expected, 3d * m);
        }

        [Test]
        public void Multiply_1x3_by_3x2()
        {
            var m1 = new Matrix<double>(new double[,] { { 2d, 3d, 4d } });
            var m2 = new Matrix<double>(new double[,] { { 1d, 2d }, { 4d, 6d }, { -4d, -2d } });

            var expected = new Matrix<double>(new double[,] { { -2d, 14d } });
            var actual = m1 * m2;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Multiply_2x2_by_2x2()
        {
            var m1 = new Matrix<double>(new double[,] { { 1d, 2d }, { 3d, 4d } });
            var m2 = new Matrix<double>(new double[,] { { 2d, 0d }, { 1d, 2d } });

            var expected = new Matrix<double>(new double[,] { { 4d, 4d }, { 10d, 8d } });
            Assert.AreEqual(expected, m1 * m2);
        }

        [Test]
        public void Multiply_wrong_dimensions()
        {
            var m1 = new Matrix<double>(2, 4);
            var m2 = new Matrix<double>(3, 3);
            Assert.Throws<System.InvalidOperationException>( () => { var m3 = m1 * m2; });
        }

        [Test]
        public void Divide_3x2_by_constant()
        {
            var m = new Matrix<double>(new double[,] { { 1d, 2d }, { 4d, 6d }, { -4d, -2d } });

            var expected = new Matrix<double>(new double[,] { { 0.5d, 1d }, { 2d, 3d }, { -2d, -1d } });
            Assert.AreEqual(expected, m / 2d);
        }

        [Test]
        public void Equality_empty()
        {
            var empty1 = new Matrix<float>();
            var empty2 = Matrix<float>.Empty;
            Assert.AreEqual(empty1, empty2);
            Assert.IsTrue(empty1 == empty2);
            Assert.IsFalse(empty1 != empty2);
            Assert.IsTrue(empty1.Equals(empty2));
            Assert.IsTrue(object.Equals(empty1, empty2));
        }

        [Test]
        public void Equality_1x1()
        {
            var m1 = new Matrix<double>(new double[1, 1] { { 6d } });
            var m2 = new Matrix<double>(1, 1);
            m2[0, 0] = 6d;

            Assert.AreEqual(m1, m2);
            Assert.IsTrue(m1 == m2);
            Assert.IsFalse(m1 != m2);
            Assert.IsTrue(m1.Equals(m2));
            Assert.IsTrue(object.Equals(m1, m2));
        }

        [Test]
        public void Equality_3x3()
        {
            var m1 = new Matrix<double>(new double[3, 3] { { 1d, 2d, 3d }, { 4d, 5d, 6d }, { 7d, 8d, 9d } });
            var m2 = new Matrix<double>(new double[3, 3] { { 1d, 2d, 3d }, { 4d, 5d, 6d }, { 7d, 8d, 9d } });

            Assert.AreEqual(m1, m2);
            Assert.IsTrue(m1 == m2);
            Assert.IsFalse(m1 != m2);
            Assert.IsTrue(m1.Equals(m2));
            Assert.IsTrue(object.Equals(m1, m2));
        }

        [Test]
        public void Inequality_null()
        {
            var m = new Matrix<float>();
            Assert.IsFalse(m.Equals(null));
            Assert.IsFalse(object.Equals(m, null));
        }

        [Test]
        public void WorksWithListContains()
        {
            var m = new Matrix<double>(new double[,] { { 1d, 2d }, { 3d, 4d } });
            var same = new Matrix<double>(new double[,] { { 1d, 2d }, { 3d, 4d } }); ;
            var different = new Matrix<double>(new double[,] { { 1d, 2d }, { 3d, -4d } }); ;

            var lst = new System.Collections.Generic.List<Matrix<double>>();
            lst.Add(different);
            Assert.IsFalse(lst.Contains(m));
            lst.Add(same);
            Assert.IsTrue(lst.Contains(m));
        }

        [Test]
        public void Inequality_1x1()
        {
            var m1 = new Matrix<double>(new double[1, 1] { { 6d } });
            var m2 = new Matrix<double>(1, 1);
            m2[0, 0] = 7d;

            Assert.AreNotEqual(m1, m2);
            Assert.IsFalse(m1 == m2);
            Assert.IsTrue(m1 != m2);
            Assert.IsFalse(m1.Equals(m2));
            Assert.IsFalse(object.Equals(m1, m2));
        }

        [Test]
        public void Inequality_3x3()
        {
            var m1 = new Matrix<double>(new double[3, 3] { { 1d, 2d, 3d }, { 4d, 5d, 6d }, { 7d, 8d, 9d } });
            var m2 = new Matrix<double>(new double[3, 3] { { 1d, 2d, 3d }, { 4d, 5d, 6d }, { 7d, 8d, -9d } });

            Assert.AreNotEqual(m1, m2);
            Assert.IsFalse(m1 == m2);
            Assert.IsTrue(m1 != m2);
            Assert.IsFalse(m1.Equals(m2));
            Assert.IsFalse(object.Equals(m1, m2));
        }

        [Test]
        public void Inequality_differentSizes()
        {
            var m1 = new Matrix<double>(new double[1, 1] { { 6d } });
            var m2 = new Matrix<double>(new double[2, 2] { { 6d, 6d }, { 6d, 6d } });

            Assert.AreNotEqual(m1, m2);
            Assert.IsFalse(m1 == m2);
            Assert.IsTrue(m1 != m2);
            Assert.IsFalse(m1.Equals(m2));
            Assert.IsFalse(object.Equals(m1, m2));
        }


        [Test]
        public void Submatrix_3x4()
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
        public void Submatrix_1x1()
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
        public void Determinant_3x3_int()
        {
            var matrix = new Matrix<int>(new int[3, 3]       { { 6, 1, 1 },
                                                               { 4, -2, 5 },
                                                               { 2, 8, 7 } });
            Assert.AreEqual(-306, matrix.Determinant);
        }

        [Test]
        public void Determinant_3x3_double()
        {
            var matrix = new Matrix<double>(new double[3, 3] { { 6d, 1d, 1d },
                                                               { 4d, -2d, 5d },
                                                               { 2d, 8d, 7d } });
            Assert.AreEqual(-306d, matrix.Determinant);
        }

        [Test]
        public void Determinant_3x3_complex()
        {
            var matrix = new Matrix<Complex>(3,3);
            matrix[0, 0] = 1; matrix[0, 1] = 2;                matrix[0, 2] = 3;
            matrix[1, 0] = 1; matrix[1, 1] = new Complex(4,1); matrix[1, 2] = 5;
            matrix[2, 0] = 6; matrix[2, 1] = 2;                matrix[2, 2] = 2;


            Assert.AreEqual(new Complex(-12,-16), matrix.Determinant);
        }

        [Test]
        public void Determinant_5x5_double()
        {
            var matrix = new Matrix<double>(new double[5, 5] { { 3d, 0d, 22d, -4d, 7d },
                                                               { 0d, 2d, 14d, 0d, -5d },
                                                               { -2d, -5d, -3d, 2d, 9d },
                                                               { 1d, 6d, -2d, 0d, -3d },
                                                               { -11d, 1d, 0d, 5d, 2d } });
            Assert.AreEqual(31170d, matrix.Determinant);
        }
        [Test]
        public void Determinant_5x5_decimal()
        {
            var matrix = new Matrix<decimal>(new decimal[5, 5] { { 3m, 0m, 22m, -4m, 7m },
                                                                 { 0m, 2m, 14m, 0m, -5m },
                                                                 { -2m, -5m, -3m, 2m, 9m },
                                                                 { 1m, 6m, -2m, 0m, -3m },
                                                                 { -11m, 1m, 0m, 5m, 2m } });
            Assert.AreEqual(31170m, matrix.Determinant);
        }


        [Test]
        public void Transpose_empty()
        {
            Matrix<double> matrix;
            var transpose = matrix.Transpose;
            Assert.AreEqual(0, transpose.RowCount);
            Assert.AreEqual(0, transpose.ColumnCount);
        }

        [Test]
        public void Transpose_1x1()
        {
            Matrix<double> matrix = new Matrix<double>(1, 1);
            var value = 4.0d;
            matrix[0, 0] = value;
            var transpose = matrix.Transpose;
            Assert.AreEqual(1, transpose.RowCount);
            Assert.AreEqual(1, transpose.ColumnCount);
            Assert.AreEqual(value, transpose[0, 0]);
        }

        [Test]
        public void Transpose_1x3()
        {
            Matrix<double> matrix = new Matrix<double>(1, 3);
            var value1 = 4.0d;
            var value2 = 5.0d;
            var value3 = -3.0d;
            matrix[0, 0] = value1;
            matrix[0, 1] = value2;
            matrix[0, 2] = value3;
            var transpose = matrix.Transpose;
            Assert.AreEqual(3, transpose.RowCount);
            Assert.AreEqual(1, transpose.ColumnCount);
            Assert.AreEqual(value1, transpose[0, 0]);
            Assert.AreEqual(value2, transpose[1, 0]);
            Assert.AreEqual(value3, transpose[2, 0]);
        }

        [Test]
        public void Transpose_4x3()
        {
            var arr = new int[,] { { 2, 3, 4 }, { 10, -3, 5 }, { 7, 7, 7 }, { -1, -1, 3 } };

            Matrix<int> matrix = new Matrix<int>(arr);
            var transpose = matrix.Transpose;
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(arr[i, j], transpose[j, i]);
                }

        }

        [Test]
        public void Cofactor()
        {
            var m = new Matrix<double>(new double[,] { { 3d, 0d, 2d }, { 2d, 0d, -2d }, { 0d, 1d, 1d } });

            var expected = new Matrix<double>(new double[,] { { 2d, -2d, 2d }, { 2d, 3d, -3d }, { 0d, 10d, 0d } });
            Assert.AreEqual(expected, m.Cofactor);
        }

        [Test]
        public void Inverse_2x2()
        {
            var matrix = new Matrix<double>(new double[2, 2] { { 4d, 7d }, { 2d, 6d } });
            var inverse = matrix.Inverse;
            Assert.AreEqual(0.6d, inverse[0, 0], 1e-9);
            Assert.AreEqual(-0.7d, inverse[0, 1], 1e-9);
            Assert.AreEqual(-0.2d, inverse[1, 0], 1e-9);
            Assert.AreEqual(0.4d, inverse[1, 1], 1e-9);
        }

        [Test]
        public void Inverse_3x3()
        {
            // https://www.mathsisfun.com/algebra/matrix-inverse-minors-cofactors-adjugate.html

            var matrix = new Matrix<double>(new double[3, 3] { { 3d, 0d, 2d }, { 2d, 0d, -2d }, { 0d, 1d, 1d} });
            var inverse = matrix.Inverse;
            Assert.AreEqual(0.2d, inverse[0, 0], 1e-9);
            Assert.AreEqual(0.2d, inverse[0, 1], 1e-9);
            Assert.AreEqual(0d, inverse[0, 2], 1e-9);
            Assert.AreEqual(-0.2d, inverse[1, 0], 1e-9);
            Assert.AreEqual(0.3d, inverse[1, 1], 1e-9);
            Assert.AreEqual(1.0d, inverse[1, 2], 1e-9);
            Assert.AreEqual(0.2d, inverse[2, 0], 1e-9);
            Assert.AreEqual(-0.3d, inverse[2, 1], 1e-9);
            Assert.AreEqual(0d, inverse[2, 2], 1e-9);
        }

        [Test]
        public void Trace_3x3()
        {
            var m = new Matrix<int>(new int[3, 3] { { -1, 0, 3 }, { 11, 5, 2 }, { 6, 12, -5 } });
            Assert.AreEqual(-1, m.Trace);
        }

    }
}
using System;

namespace JamesQMurphy.Math
{
    public struct Matrix<T> where T : struct
    {
        #region Static Members
        private static T[,] _emptyArray = new T[0, 0];
        public static Matrix<T> Empty = new Matrix<T>(_emptyArray);
        #endregion

        private T[,] _actualArray;

        private T[,] _array
        {
            get
            {
                return _actualArray ?? _emptyArray;
            }
        }

        public Matrix(int numRows, int numColumns)
        {
            _actualArray = new T[numRows, numColumns];
        }

        public Matrix(T[,] array)
        {
            _actualArray = (T[,]) array.Clone();
        }

        public override bool Equals(object obj)
        {
            if (obj.GetType() != typeof(Matrix<T>))
            {
                return false;
            }
            Matrix<T> other = (Matrix<T>)obj;
            if (RowCount != other.RowCount || ColumnCount != other.ColumnCount)
                return false;
            for(int i = 0; i < RowCount; i++)
            {
                for (int j = 0; j < ColumnCount; j++)
                {
                    if (!Object.Equals(this[i,j], other[i,j]))
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public override int GetHashCode()
        {
            return _array.GetHashCode();
        }

        public int RowCount
        {
            get { return _array.GetLength(0); }
        }
        public int ColumnCount
        {
            get { return _array.GetLength(1); }
        }

        public bool IsSquare
        {
            get { return RowCount == ColumnCount; }
        }

        public T this[int i, int j]
        {
            get { return _array[i, j]; }
            set { _array[i, j] = value; }
        }

        public Matrix<T> SubMatrix(int i, int j)
        {
            var newArray = new T[RowCount - 1, ColumnCount - 1];
            for(int m = 0; m < RowCount-1; m++)
            {
                for (int n = 0; n < ColumnCount-1; n++)
                {
                    newArray[m, n] = _array[(m >= i ? m + 1 : m), (n >= j ? n + 1 : n)];
                }
            }
            return new Matrix<T>(newArray);
        }

        public T Determinant
        {
            get
            {
                if (!IsSquare) throw new InvalidOperationException("Cannot find the determinant of a nonsquare matrix");

                switch (RowCount)
                {
                    case 0:
                        return Operations<T>.One;

                    // Technically not needed, but way faster
                    case 1:
                        return this[0, 0];

                    // Also technially not needed
                    case 2:
                        return Operations<T>.Subtract(
                                Operations<T>.Multiply(this[0, 0], this[1, 1]),
                                Operations<T>.Multiply(this[1, 0], this[0, 1])
                            );
                }

                T determinant = default(T);
                for(int j = 0; j < ColumnCount; j++)
                {
                    T term = Operations<T>.Multiply(this[0, j], SubMatrix(0, j).Determinant);
                    
                    // add odd terms, subtract even terms (and remember that j is zero based)
                    if (j % 2 == 0)
                    {
                        determinant = Operations<T>.Add(determinant, term);
                    }
                    else
                    {
                        determinant = Operations<T>.Subtract(determinant, term);
                    }
                }
                return determinant;
            }
        }

        public T Trace
        {
            get
            {
                if (!IsSquare) throw new InvalidOperationException("Cannot find the trace of a nonsquare matrix");
                T trace = Operations<T>.Zero;
                for (int i = 0; i < RowCount; i++)
                {
                    trace = Operations<T>.Add(trace, this[i,i]);
                }
                return trace;
            }
        }

        public Matrix<T> Cofactor
        {
            get
            {
                if (!IsSquare) throw new InvalidOperationException("Cannot find the cofactor of a nonsquare matrix");

                var cofactor = new Matrix<T>(RowCount, ColumnCount);
                for (int i = 0; i < RowCount; i++)
                {
                    for (int j=0; j < ColumnCount; j++)
                    {
                        T det = SubMatrix(i, j).Determinant;
                        cofactor[i, j] = ((i + j) % 2 == 0) ? det : Operations<T>.Subtract(Operations<T>.Zero, det);
                    }
                }

                return cofactor;
            }
        }

        public Matrix<T> Transpose
        {
            get
            {
                var transpose = new T[ColumnCount, RowCount];
                for (int i = 0; i < RowCount; i++)
                {
                    for (int j = 0; j < ColumnCount; j++)
                    {
                        transpose[j, i] = _array[i, j];
                    }
                }
                return new Matrix<T>(transpose);
            }
        }

        public Matrix<T> Inverse
        {
            get
            {
                if (!IsSquare) throw new InvalidOperationException("Cannot find the inverse of a nonsquare matrix");

                var cofactor = this.Cofactor;
                T det = Operations<T>.Zero;
                for (int j = 0; j < ColumnCount; j++)
                {
                    det = Operations<T>.Add(det, Operations<T>.Multiply(this[0, j], cofactor[0, j]));
                }
                return Matrix<T>.Divide(cofactor.Transpose, det);
            }
        }

        #region Static methods

        public static Matrix<T> Add(Matrix<T> left, Matrix<T> right)
        {
            if (left.RowCount != right.RowCount || left.ColumnCount != right.ColumnCount)
            {
                throw new InvalidOperationException("Cannot add matrices with different dimensions");
            }
            var result = new Matrix<T>(left.RowCount, left.ColumnCount);
            for (int i = 0; i < left.RowCount; i++)
            {
                for (int j = 0; j < left.ColumnCount; j++)
                {
                    result[i, j] = Operations<T>.Add(left[i, j], right[i, j]);
                }
            }
            return result;
        }
        public static Matrix<T> Subtract(Matrix<T> left, Matrix<T> right)
        {
            if (left.RowCount != right.RowCount || left.ColumnCount != right.ColumnCount)
            {
                throw new InvalidOperationException("Cannot add matrices with different dimensions");
            }
            var result = new Matrix<T>(left.RowCount, left.ColumnCount);
            for (int i = 0; i < left.RowCount; i++)
            {
                for (int j = 0; j < left.ColumnCount; j++)
                {
                    result[i, j] = Operations<T>.Subtract(left[i, j], right[i, j]);
                }
            }
            return result;
        }
        public static Matrix<T> Multiply(T left, Matrix<T> right)
        {
            return Matrix<T>.Multiply(right, left);
        }
        public static Matrix<T> Multiply(Matrix<T> left, T right)
        {
            var result = new Matrix<T>(left.RowCount, left.ColumnCount);
            for (int i = 0; i < left.RowCount; i++)
            {
                for (int j = 0; j < left.ColumnCount; j++)
                {
                    result[i, j] = Operations<T>.Multiply(left[i, j], right);
                }
            }
            return result;
        }
        public static Matrix<T> Multiply(Matrix<T> left, Matrix<T> right)
        {
            if (left.ColumnCount != right.RowCount )
            {
                throw new InvalidOperationException("Cannot multiply matrices unless the column count of the left equals the row count of the right");
            }
            var result = new Matrix<T>(left.RowCount, right.ColumnCount);
            for (int i = 0; i < left.RowCount; i++)
            {
                for (int j = 0; j < right.ColumnCount; j++)
                {
                    T sum = Operations<T>.Zero;
                    for (int inner = 0; inner < left.ColumnCount; inner++)
                    {
                        sum = Operations<T>.Add(sum, Operations<T>.Multiply(left[i, inner], right[inner, j]));
                    }
                    result[i, j] = sum;
                }
            }
            return result;
        }
        public static Matrix<T> Divide(Matrix<T> left, T right)
        {
            var inverse = Operations<T>.Divide(Operations<T>.One, right);
            return Matrix<T>.Multiply(inverse, left);
        }
        #endregion

        #region Operator Overloads
        public static bool operator ==(Matrix<T> left, Matrix<T> right)
        {
            return Matrix<T>.Equals(left, right);
        }
        public static bool operator !=(Matrix<T> left, Matrix<T> right)
        {
            return !Matrix<T>.Equals(left, right);
        }
        public static Matrix<T> operator +(Matrix<T> left, Matrix<T> right)
        {
            return Add(left, right);
        }
        public static Matrix<T> operator -(Matrix<T> left, Matrix<T> right)
        {
            return Subtract(left, right);
        }
        public static Matrix<T> operator *(Matrix<T> left, Matrix<T> right)
        {
            return Multiply(left, right);
        }
        public static Matrix<T> operator *(T left, Matrix<T> right)
        {
            return Multiply(left, right);
        }
        public static Matrix<T> operator *(Matrix<T> left, T right)
        {
            return Multiply(left, right);
        }
        public static Matrix<T> operator /(Matrix<T> left, T right)
        {
            return Divide(left, right);
        }
        #endregion
    }
}

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
                if (!IsSquare) throw new InvalidOperationException("Determinant requires matrix to be square");

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
                throw new NotImplementedException();
            }
        }

        public Matrix<T> Inverse
        {
            get
            {
                throw new NotImplementedException();
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

        #region Static methods

        public static Matrix<T> Add(Matrix<T> left, Matrix<T> right)
        {
            throw new NotImplementedException();
        }
        public static Matrix<T> Subtract(Matrix<T> left, Matrix<T> right)
        {
            throw new NotImplementedException();
        }
        public static Matrix<T> Multiply(T left, Matrix<T> right)
        {
            throw new NotImplementedException();
        }
        public static Matrix<T> Multiply(Matrix<T> left, T right)
        {
            return Matrix<T>.Multiply(right, left);
        }
        public static Matrix<T> Multiply(Matrix<T> left, Matrix<T> right)
        {
            throw new NotImplementedException();
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

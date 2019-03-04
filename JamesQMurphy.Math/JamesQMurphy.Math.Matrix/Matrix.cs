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

        public double Determinant
        {
            get
            {
                if (!IsSquare) throw new InvalidOperationException("Determinant requires matrix to be square");

                switch (RowCount)
                {
                    case 0:
                        return 1d;

                    // Technically not needed, but way faster
                    case 1:
                        return Convert.ToDouble(this[0, 0]);

                    // Also technially not needed
                    case 2:
                        return Convert.ToDouble(this[0, 0]) * Convert.ToDouble(this[1, 1]) - Convert.ToDouble(this[1, 0]) * Convert.ToDouble(this[0, 1]);
                }

                double sign = 1.0;
                double determinant = 0.0;
                for(int j = 0; j < ColumnCount; j++)
                {
                    determinant += sign * Convert.ToDouble(this[0, j]) * SubMatrix(0, j).Determinant;
                    sign *= -1.0;
                }
                return determinant;
            }
        }
    }
}

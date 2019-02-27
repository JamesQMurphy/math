using System;

namespace JamesQMurphy.Matrix
{
    public struct Matrix<T> where T:struct
    {
        private T[,] _actualArray;

        private T[,] _array
        {
            get
            {
                if (_actualArray == null)
                {
                    _actualArray = new T[1, 1];
                }
                return _actualArray;
            }
        }

        public Matrix(int numRows, int numColumns)
        {
            _actualArray = new T[numRows, numColumns];
        }

        public int RowCount
        {
            get { return _array.GetLength(0); }
        }
        public int ColumnCount
        {
            get { return _array.GetLength(1); }
        }
    }
}

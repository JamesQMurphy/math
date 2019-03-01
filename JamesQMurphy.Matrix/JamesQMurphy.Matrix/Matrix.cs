﻿using System;

namespace JamesQMurphy.Matrix
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
    }
}

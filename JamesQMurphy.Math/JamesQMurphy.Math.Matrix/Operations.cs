﻿using System;
using System.Collections.Generic;
using System.Reflection;

namespace JamesQMurphy.Math
{
    public static class Operations<T> where T:struct
    {
        // thanks to this Stack Overflow answer:
        // https://stackoverflow.com/a/11113450/1001100
        private enum _binaryOperations
        {
            op_Addition = 0,
            op_Subtraction,
            op_Multiply,
            op_Division
        }

        private static List<MethodInfo> _binaryOpMethodInfos = new List<MethodInfo>();

        static Operations()
        {
            // Populate private list of methodinfo objects with all operations in the enum
            foreach (string opName in Enum.GetNames(typeof(_binaryOperations)))
            {
                var mi = typeof(T).GetMethod(opName, BindingFlags.Static | BindingFlags.Public);
                _binaryOpMethodInfos.Add(mi); // Note: can be null
            }
        }

        private static T _InvokeBinaryOperation(_binaryOperations op, T left, T right)
        {
            var mi = _binaryOpMethodInfos[(int)op];
            if (mi != null)
            {
                return (T)mi.Invoke(null, new object[] { left, right });
            }
            throw new MissingMethodException(typeof(T).FullName, op.ToString());
        }

        #region Add
        public static T Add(T left, T right)
        {
            return _InvokeBinaryOperation(_binaryOperations.op_Addition, left, right);
        }

        public static System.Int16 Add(System.Int16 left, System.Int16 right) { return (System.Int16)(left + right); }
        public static System.Int32 Add(System.Int32 left, System.Int32 right) { return left + right; }
        public static System.Int64 Add(System.Int64 left, System.Int64 right) { return left + right; }
        public static float Add(float left, float right) { return left + right; }
        public static double Add(double left, double right) { return left + right; }
        #endregion

        #region Multiply
        public static T Multiply(T left, T right)
        {
            return _InvokeBinaryOperation(_binaryOperations.op_Multiply, left, right);
        }
        public static System.Int16 Multiply(System.Int16 left, System.Int16 right) { return (System.Int16)(left * right); }
        public static System.Int32 Multiply(System.Int32 left, System.Int32 right) { return left * right; }
        public static System.Int64 Multiply(System.Int64 left, System.Int64 right) { return left * right; }
        public static float Multiply(float left, float right) { return left * right; }
        public static double Multiply(double left, double right) { return left * right; }
        #endregion
    }
}
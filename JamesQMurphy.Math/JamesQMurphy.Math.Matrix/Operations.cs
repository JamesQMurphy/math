using System;
using System.Collections.Generic;
using System.Linq.Expressions;
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

        // thanks to this StackOverflow answer:
        // https://stackoverflow.com/a/27584212/1001100
        private static T _CastFrom(object obj)
        {
            var DataParam = Expression.Parameter(typeof(object), "obj");
            var Body = Expression.Block(Expression.Convert(Expression.Convert(DataParam, obj.GetType()), typeof(T)));
            var Run = Expression.Lambda(Body, DataParam).Compile();
            return (T) Run.DynamicInvoke(obj);
        }

        #region Numeric Constants
        public static T Zero
        {
            get
            {
                return _CastFrom((int)0);
            }
        }

        public static T One
        {
            get
            {
                return _CastFrom((int)1);
            }
        }
        #endregion

        private static T _InvokeBinaryOperation(_binaryOperations op, T left, T right)
        {
            var mi = _binaryOpMethodInfos[(int)op];
            if (mi != null)
            {
                return (T)mi.Invoke(null, new object[] { left, right });
            }
            throw new MissingMethodException(typeof(T).FullName, op.ToString());
        }

        public static T Add(T left, T right)
        {
            var exprLeft = Expression.Parameter(typeof(T));
            var exprRight = Expression.Parameter(typeof(T));
            var body = Expression.Block(Expression.Add(exprLeft, exprRight));
            var run = Expression.Lambda(body, exprLeft, exprRight).Compile();
            return (T)run.DynamicInvoke(left, right);
        }

        public static T Subtract(T left, T right)
        {
            var exprLeft = Expression.Parameter(typeof(T));
            var exprRight = Expression.Parameter(typeof(T));
            var body = Expression.Block(Expression.Subtract(exprLeft, exprRight));
            var run = Expression.Lambda(body, exprLeft, exprRight).Compile();
            return (T)run.DynamicInvoke(left, right);
        }

        public static T Multiply(T left, T right)
        {
            var exprLeft = Expression.Parameter(typeof(T));
            var exprRight = Expression.Parameter(typeof(T));
            var body = Expression.Block(Expression.Multiply(exprLeft, exprRight));
            var run = Expression.Lambda(body, exprLeft, exprRight).Compile();
            return (T)run.DynamicInvoke(left, right);
        }

        public static T Divide(T left, T right)
        {
            var exprLeft = Expression.Parameter(typeof(T));
            var exprRight = Expression.Parameter(typeof(T));
            var body = Expression.Block(Expression.Divide(exprLeft, exprRight));
            var run = Expression.Lambda(body, exprLeft, exprRight).Compile();
            return (T)run.DynamicInvoke(left, right);
        }


    }
}

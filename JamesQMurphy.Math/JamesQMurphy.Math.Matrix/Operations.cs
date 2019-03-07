using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;

namespace JamesQMurphy.Math
{
    public static class Operations<T> where T:struct
    {
        private static readonly Delegate _delAdd;
        private static readonly Delegate _delSub;
        private static readonly Delegate _delMul;
        private static readonly Delegate _delDiv;

        static Operations()
        {
            // Build expression tree lambdas for operations
            var exprLeft = Expression.Parameter(typeof(T));
            var exprRight = Expression.Parameter(typeof(T));
            _delAdd = Expression.Lambda(Expression.Block(Expression.Add(exprLeft, exprRight)),      exprLeft, exprRight).Compile();
            _delSub = Expression.Lambda(Expression.Block(Expression.Subtract(exprLeft, exprRight)), exprLeft, exprRight).Compile();
            _delMul = Expression.Lambda(Expression.Block(Expression.Multiply(exprLeft, exprRight)), exprLeft, exprRight).Compile();
            _delDiv = Expression.Lambda(Expression.Block(Expression.Divide(exprLeft, exprRight)),   exprLeft, exprRight).Compile();
        }

        // thanks to this StackOverflow answer:
        // https://stackoverflow.com/a/27584212/1001100
        private static T _CastFrom(object obj)
        {
            var exprParam = Expression.Parameter(typeof(object));
            var exprBlock = Expression.Block(Expression.Convert(Expression.Convert(exprParam, obj.GetType()), typeof(T)));
            var del = Expression.Lambda(exprBlock, exprParam).Compile();
            return (T)del.DynamicInvoke(obj);
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

        public static T Add(T left, T right)
        {
            return (T)_delAdd.DynamicInvoke(left, right);
        }

        public static T Subtract(T left, T right)
        {
            return (T)_delSub.DynamicInvoke(left, right);
        }

        public static T Multiply(T left, T right)
        {
            return (T)_delMul.DynamicInvoke(left, right);
        }

        public static T Divide(T left, T right)
        {
            return (T)_delDiv.DynamicInvoke(left, right);
        }


    }
}

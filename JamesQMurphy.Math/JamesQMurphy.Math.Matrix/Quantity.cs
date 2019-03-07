using System;
using System.Collections.Generic;
using System.Text;

namespace JamesQMurphy.Math
{
    public struct Quantity<T> where T : struct
    {
        // This holds the numeric quantity
        private T _value;

        // This holds the units
        private Int64 _units;


    }
}

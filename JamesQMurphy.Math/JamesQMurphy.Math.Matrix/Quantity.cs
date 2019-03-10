using System;
using System.Collections.Generic;
using System.Text;

namespace JamesQMurphy.Math
{
    public readonly struct Quantity
    {
        private readonly double _SIvalue;
        private readonly UnitExponents _unitExponents;

        public Quantity(double value, Unit unit)
        {
            _SIvalue = value / unit.ConversionFactor;
            _unitExponents = unit.UnitExponents;
        }

        private Quantity(double value, UnitExponents unitExponents)
        {
            _SIvalue = value;
            _unitExponents = unitExponents;
        }

        public Quantity Reciprocal
        {
            get
            {
                return new Quantity(
                    1.0d / _SIvalue,
                    new UnitExponents(
                        (Int16)(0 - _unitExponents.Length),
                        (Int16)(0 - _unitExponents.Mass),
                        (Int16)(0 - _unitExponents.Time),
                        (Int16)(0 - _unitExponents.ElectricCurrent),
                        (Int16)(0 - _unitExponents.Temperature),
                        (Int16)(0 - _unitExponents.AmountOfSubstance),
                        (Int16)(0 - _unitExponents.LuminousIntensity)
                    )
                );
            }
        }

        public double In(Unit unit)
        {
            if (!_unitExponents.Equals(unit.UnitExponents))
            {
                throw new ArgumentException($"Cannot convert to unit {unit.Symbol}", "unit");
            }
            return _SIvalue * unit.ConversionFactor;
        }

        public override string ToString()
        {
            return $"{_SIvalue} {_unitExponents}".TrimEnd();
        }

        public string ToString(Unit asUnit)
        {
            if (_unitExponents != asUnit.UnitExponents)
            {
                throw new ArgumentException($"Cannot express {_unitExponents} in units of {asUnit}", "asUnit");
            }
            return $"{_SIvalue * asUnit.ConversionFactor} {asUnit}";
        }

        public override bool Equals(object obj)
        {
            if (obj.GetType() != typeof(Quantity))
            {
                return false;
            }
            return Quantity.Equals(this, (Quantity)obj);
        }

        public override int GetHashCode()
        {
            return _SIvalue.GetHashCode() ^ _unitExponents.GetHashCode();
        }

        public static bool Equals(Quantity left, Quantity right)
        {
            return (left._SIvalue == right._SIvalue)
                && (left._unitExponents == right._unitExponents);
        }

        public static Quantity Multiply(Quantity left, Quantity right)
        {
            return new Quantity(
                    left._SIvalue * right._SIvalue,
                    left._unitExponents * right._unitExponents
                );
        }

        public static Quantity Multiply(double left, Quantity right)
        {
            return new Quantity(
                    left * right._SIvalue,
                    right._unitExponents
                );
        }

        public static Quantity Multiply(Quantity left, double right)
        {
            return new Quantity(
                    left._SIvalue * right,
                    left._unitExponents
                );
        }

        public static Quantity Divide(Quantity left, Quantity right)
        {
            return new Quantity(
                    left._SIvalue / right._SIvalue,
                    left._unitExponents / right._unitExponents
                );
        }

        public static Quantity Divide(Quantity left, double right)
        {
            return new Quantity(
                    left._SIvalue / right,
                    left._unitExponents
                );
        }
        public static Quantity Divide(double left, Quantity right)
        {
            return Multiply(left, right.Reciprocal);
        }

        #region Operator Overloads
        public static bool operator ==(Quantity left, Quantity right)
        {
            return Quantity.Equals(left, right);
        }
        public static bool operator !=(Quantity left, Quantity right)
        {
            return !Quantity.Equals(left, right);
        }
        public static Quantity operator *(Quantity left, Quantity right)
        {
            return Multiply(left, right);
        }
        public static Quantity operator *(double left, Quantity right)
        {
            return Multiply(left, right);
        }
        public static Quantity operator *(Quantity left, double right)
        {
            return Multiply(left, right);
        }
        public static Quantity operator /(Quantity left, Quantity right)
        {
            return Divide(left, right);
        }
        public static Quantity operator /(Quantity left, double right)
        {
            return Divide(left, right);
        }
        public static Quantity operator /(double left, Quantity right)
        {
            return Divide(left, right);
        }
        #endregion
    }
}

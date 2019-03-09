using System;
using System.Collections.Generic;
using System.Text;

namespace JamesQMurphy.Math
{
    public class Unit
    {
        public UnitExponents UnitExponents { get; }
        public double ConversionFactor { get; }
        public string Symbol { get; }

        public Unit(
            UnitExponents unitExponents,
            double conversionFactor
            )
        {
            UnitExponents = unitExponents;
            ConversionFactor = conversionFactor;
            if (conversionFactor != 1.0d)
            {
                throw new System.InvalidOperationException("Symbol is required if ConversionFactor is not equal to 1.0");
            }
            Symbol = unitExponents.ToString();
        }

        public Unit(
            UnitExponents unitExponents,
            double conversionFactor,
            string symbol
            )
        {
            UnitExponents = unitExponents;
            ConversionFactor = conversionFactor;
            Symbol = symbol;
        }

        public Unit(
            Int16 length,
            Int16 mass,
            Int16 time,
            Int16 electricCurrent,
            Int16 temperature,
            Int16 amountOfSubstance,
            Int16 luminousIntensity,
            double conversionFactor
            ) : this(
                new UnitExponents(length, mass, time, electricCurrent, temperature, amountOfSubstance, luminousIntensity),
                conversionFactor
                )
        {
        }

        public Unit(
            Int16 length,
            Int16 mass,
            Int16 time,
            Int16 electricCurrent,
            Int16 temperature,
            Int16 amountOfSubstance,
            Int16 luminousIntensity,
            double conversionFactor,
            string symbol
            ) : this(
                new UnitExponents(length, mass, time, electricCurrent, temperature, amountOfSubstance, luminousIntensity),
                conversionFactor,
                symbol
                )
        {
        }

        public override string ToString()
        {
            return Symbol;
        }

        public override bool Equals(object obj)
        {
            if (obj.GetType() != typeof(Unit))
            {
                return false;
            }
            return Unit.Equals(this, (Unit)obj);
        }

        public override int GetHashCode()
        {
            return UnitExponents.GetHashCode() ^ ConversionFactor.GetHashCode();
        }

        public static bool Equals(Unit left, Unit right)
        {
            return (left.UnitExponents == right.UnitExponents)
                && (left.ConversionFactor == right.ConversionFactor);
        }

        public static Unit Multiply(Unit left, Unit right)
        {
            return new Unit(
                    left.UnitExponents * right.UnitExponents,
                    left.ConversionFactor * right.ConversionFactor,
                    left.Symbol + "*" + right.Symbol
                );
        }

        public static Unit Divide(Unit left, Unit right)
        {
            return new Unit(
                    left.UnitExponents / right.UnitExponents,
                    left.ConversionFactor / right.ConversionFactor,
                    left.Symbol + "/" + right.Symbol
                );
        }

        #region Operator Overloads
        public static bool operator ==(Unit left, Unit right)
        {
            return Unit.Equals(left, right);
        }
        public static bool operator !=(Unit left, Unit right)
        {
            return !Unit.Equals(left, right);
        }
        public static Unit operator *(Unit left, Unit right)
        {
            return Multiply(left, right);
        }
        public static Unit operator /(Unit left, Unit right)
        {
            return Divide(left, right);
        }
        #endregion
    }

    public static class Units
    {
        // SI Base Units
        public static Unit Meter    = new Unit(1, 0, 0, 0, 0, 0, 0, 1.0d);
        public static Unit Kilogram = new Unit(0, 1, 0, 0, 0, 0, 0, 1.0d);
        public static Unit Second   = new Unit(0, 0, 1, 0, 0, 0, 0, 1.0d);
        public static Unit Ampere   = new Unit(0, 0, 0, 1, 0, 0, 0, 1.0d);
        public static Unit Kelvin   = new Unit(0, 0, 0, 0, 1, 0, 0, 1.0d);
        public static Unit Mole     = new Unit(0, 0, 0, 0, 0, 1, 0, 1.0d);
        public static Unit Candela  = new Unit(0, 0, 0, 0, 0, 0, 1, 1.0d);

        // SI Prefixed units
        public static Unit Kilometer = new Unit(1, 0, 0, 0, 0, 0, 0, 0.001d, "km");

        // SI Derived Units
        public static Unit Newton = new Unit(1, 1, -2, 0, 0, 0, 0, 1.0d, "N");

        // Imperial units
        public static Unit Foot = new Unit(1, 0, 0, 0, 0, 0, 0, 3.28084d, "ft");
        public static Unit Inch = new Unit(1, 0, 0, 0, 0, 0, 0, 1.09361d, "in");
    }


}

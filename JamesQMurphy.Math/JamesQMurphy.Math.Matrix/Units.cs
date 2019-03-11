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
            var up = new UnitParser();
            up.Append(left.Symbol);
            up.Append(right.Symbol);
            return new Unit(
                    left.UnitExponents * right.UnitExponents,
                    left.ConversionFactor * right.ConversionFactor,
                    up.ToString()
                );
        }

        public static Unit Divide(Unit left, Unit right)
        {
            var up = new UnitParser();
            up.Append(left.Symbol);
            up.AppendFlipped(right.Symbol);
            return new Unit(
                    left.UnitExponents / right.UnitExponents,
                    left.ConversionFactor / right.ConversionFactor,
                    up.ToString()
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
        // Dimensionless
        public static Unit None = new Unit(0, 0, 0, 0, 0, 0, 0, 1.0d);
        public static Unit Dimensionless = new Unit(0, 0, 0, 0, 0, 0, 0, 1.0d);

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
        public static Unit Hertz  = new Unit(0, 0, -1, 0, 0, 0, 0, 1.0d, "Hz");
        public static Unit Newton = new Unit(1, 1, -2, 0, 0, 0, 0, 1.0d, "N");

        // Other SI Units
        public static Unit DegreesCelsius = new Unit(0, 0, 0, 0, 1, 0, 0, 1.0d, "°C");

        // Imperial units
        // Source: https://www.unitconverters.net
        public static Unit Yard = new Unit(1, 0, 0, 0, 0, 0, 0, 1.0936132983d, "yd");
        public static Unit Foot = new Unit(1, 0, 0, 0, 0, 0, 0, 3.280839895d, "ft");
        public static Unit Inch = new Unit(1, 0, 0, 0, 0, 0, 0, 39.37007874d, "in");
        public static Unit Rankine = new Unit(0, 0, 0, 0, 1, 0, 0, 1.8d, "°R");
        public static Unit DegreesFahrenheit = new Unit(0, 0, 0, 0, 1, 0, 0, 1.8d, "°F");

        public static double Convert(double value, Unit from, Unit to)
        {
            return value * to.ConversionFactor / from.ConversionFactor;
        }

    }


}

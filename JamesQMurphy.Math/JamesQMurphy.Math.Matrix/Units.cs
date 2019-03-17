using System;
using System.Collections.Generic;
using System.Text;

namespace JamesQMurphy.Math
{
    public class Unit
    {
        public UnitExponents UnitExponents { get; }
        public string Symbol { get; }
        public Func<double, double> ConvertToSI { get; }
        public Func<double, double> ConvertFromSI { get; }

        private readonly double _conversionFactor;

        public Unit(
            UnitExponents unitExponents,
            double conversionFactor
            ) : this(unitExponents, conversionFactor, unitExponents.ToString())
        {
            if (conversionFactor != 1.0d)
            {
                throw new InvalidOperationException("Symbol is required if ConversionFactor is not equal to 1.0");
            }
        }

        public Unit(
            UnitExponents unitExponents,
            double conversionFactor,
            string symbol
            )
        {
            if (conversionFactor == 0d)
            {
                throw new ArgumentException("ConversionFactor must not be zero", "conversionFactor");
            }
            UnitExponents = unitExponents;
            _conversionFactor = conversionFactor;
            ConvertToSI = d => d / _conversionFactor;
            ConvertFromSI = d => d * _conversionFactor;
            Symbol = symbol;
        }

        public Unit(
            UnitExponents unitExponents,
            Func<double, double> convertFromSI,
            Func<double, double> convertToSI,
            string symbol
            )
        {
            UnitExponents = unitExponents;
            _conversionFactor = 0d;
            ConvertToSI = convertToSI;
            ConvertFromSI = convertFromSI;
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
            Func<double, double> convertFromSI,
            Func<double, double> convertToSI,
            string symbol
            ) : this(
                new UnitExponents(length, mass, time, electricCurrent, temperature, amountOfSubstance, luminousIntensity),
                convertFromSI,
                convertToSI,
                symbol
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
            return UnitExponents.GetHashCode() ^ _conversionFactor.GetHashCode();
        }

        public static bool Equals(Unit left, Unit right)
        {
            return (left.UnitExponents == right.UnitExponents)
                && (left._conversionFactor == right._conversionFactor)
                && (left._conversionFactor != 0d)
                && (right._conversionFactor != 0d);
        }

        public static Unit Multiply(Unit left, Unit right)
        {
            if (left._conversionFactor == 0d)
            {
                throw new InvalidOperationException($"Cannot multiply ${left} because it has a special conversion function");
            }
            if (right._conversionFactor == 0d)
            {
                throw new InvalidOperationException($"Cannot multiply ${right} because it has a special conversion function");
            }
            var up = new UnitParser();
            up.Append(left.Symbol);
            up.Append(right.Symbol);
            return new Unit(
                    left.UnitExponents * right.UnitExponents,
                    left._conversionFactor * right._conversionFactor,
                    up.ToString()
                );
        }

        public static Unit Divide(Unit left, Unit right)
        {
            if (left._conversionFactor == 0d)
            {
                throw new InvalidOperationException($"Cannot divide ${left} because it has a special conversion function");
            }
            if (right._conversionFactor == 0d)
            {
                throw new InvalidOperationException($"Cannot divide ${right} because it has a special conversion function");
            }
            var up = new UnitParser();
            up.Append(left.Symbol);
            up.AppendFlipped(right.Symbol);
            return new Unit(
                    left.UnitExponents / right.UnitExponents,
                    left._conversionFactor / right._conversionFactor,
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

        // SI Derived Units
        public static Unit Liter   = new Unit(3, 0, 0, 0, 0, 0, 0, 1e3d, "L");
        public static Unit Hertz   = new Unit(0, 0, -1, 0, 0, 0, 0, 1.0d, "Hz");
        public static Unit Newton  = new Unit(1, 1, -2, 0, 0, 0, 0, 1.0d, "N");
        public static Unit Pascal  = new Unit(-1, 1, -2, 0, 0, 0, 0, 1.0d, "Pa");
        public static Unit Joule   = new Unit(2, 1, -2, 0, 0, 0, 0, 1.0d, "J");
        public static Unit Watt    = new Unit(2, 1, -3, 0, 0, 0, 0, 1.0d, "W");
        public static Unit Coulomb = new Unit(0, 0, 1, 1, 0, 0, 0, 1.0d, "C");
        public static Unit Volt    = new Unit(2, 1, -3, -1, 0, 0, 0, 1.0d, "V");
        public static Unit Farad   = new Unit(-2, -1, 4, 2, 0, 0, 0, 1.0d, "F");
        public static Unit Ohm     = new Unit(2, 1, -3, -2, 0, 0, 0, 1.0d, "Ω");
        public static Unit Siemens = new Unit(-2, -1, 3, 2, 0, 0, 0, 1.0d, "S");
        public static Unit Weber   = new Unit(2, 1, -2, -1, 0, 0, 0, 1.0d, "Wb");
        public static Unit Tesla   = new Unit(0, 1, -2, -1, 0, 0, 0, 1.0d, "T");
        public static Unit Henry   = new Unit(2, 1, -2, -2, 0, 0, 0, 1.0d, "H");

        // SI Prefixed units
        public static Unit Kilometer = new Unit(1, 0, 0, 0, 0, 0, 0, 1e-3d, "km");
        public static Unit Centometer = new Unit(1, 0, 0, 0, 0, 0, 0, 1e2d, "cm");
        public static Unit Millimeter = new Unit(1, 0, 0, 0, 0, 0, 0, 1e3d, "mm");
        public static Unit Micrometer = new Unit(1, 0, 0, 0, 0, 0, 0, 1e6d, "μm");
        public static Unit Nanometer = new Unit(1, 0, 0, 0, 0, 0, 0, 1e9d, "nm");

        public static Unit Gigajoule = new Unit(2, 1, -2, 0, 0, 0, 0, 1e-9d, "GJ");
        public static Unit Megajoule = new Unit(2, 1, -2, 0, 0, 0, 0, 1e-6d, "MJ");
        public static Unit Kilojoule = new Unit(2, 1, -2, 0, 0, 0, 0, 1e-3d, "kJ");
        public static Unit Millijoule = new Unit(2, 1, -2, 0, 0, 0, 0, 1e3d, "mJ");
        public static Unit Microjoule = new Unit(2, 1, -2, 0, 0, 0, 0, 1e6d, "μJ");
        public static Unit Nanojoule = new Unit(2, 1, -2, 0, 0, 0, 0, 1e9d, "nJ");

        // Other SI Units
        public static Unit Erg = new Unit(2, 1, -2, 0, 0, 0, 0, 1e7d, "erg");

        // Imperial units
        // Source: https://www.unitconverters.net
        public static Unit Mile = new Unit(1, 0, 0, 0, 0, 0, 0, 6.21371192e-4d, "mi");
        public static Unit Furlong = new Unit(1, 0, 0, 0, 0, 0, 0, 0.00497097d, "fur");
        public static Unit Yard = new Unit(1, 0, 0, 0, 0, 0, 0, 1.0936132983d, "yd");
        public static Unit Foot = new Unit(1, 0, 0, 0, 0, 0, 0, 3.280839895d, "ft");
        public static Unit Inch = new Unit(1, 0, 0, 0, 0, 0, 0, 39.37007874d, "in");

        public static Unit Firkin = new Unit(0, 1, 0, 0, 0, 0, 0, 0.0244958069d, "fir");

        public static Unit Fortnight = new Unit(0, 0, 1, 0, 0, 0, 0, 8.2671957672e-7, "ftn");
        public static Unit BritishThermalUnit = new Unit(2, 1, -2, 0, 0, 0, 0, 0.948213e-3, "Btu");
        public static Unit Rankine = new Unit(0, 0, 0, 0, 1, 0, 0, 1.8d, "°R");

        // Temperature units use special converters
        public static Unit DegreesCelsius = new Unit(0, 0, 0, 0, 1, 0, 0, (k) => k - 273.15d, (c) => c + 273.15d, "°C");
        public static Unit DegreesFahrenheit = new Unit(0, 0, 0, 0, 1, 0, 0, (k)=>1.8d*(k-273.15d) + 32d, (f) => (f-32d)*5d/9d + 273.15d, "°F");

        // Miscellaneous Units
        public static Unit Atmosphere = new Unit(-1, 1, -2, 0, 0, 0, 0, 9.8692e-6d, "atm");


        public static double Convert(double value, Unit from, Unit to)
        {
            return to.ConvertFromSI(from.ConvertToSI(value));
        }

    }


}

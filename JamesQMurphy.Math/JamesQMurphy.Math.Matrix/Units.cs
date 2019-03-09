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

    }

    public static class Units
    {
        // SI Base Units
        public static Unit Meter    = new Unit(1, 0, 0, 0, 0, 0, 0, 1.0d, "m");
        public static Unit Kilogram = new Unit(0, 1, 0, 0, 0, 0, 0, 1.0d, "kg");
        public static Unit Second   = new Unit(0, 0, 1, 0, 0, 0, 0, 1.0d, "s");
        public static Unit Ampere   = new Unit(0, 0, 0, 1, 0, 0, 0, 1.0d, "A");
        public static Unit Kelvin   = new Unit(0, 0, 0, 0, 1, 0, 0, 1.0d, "K");
        public static Unit Mole     = new Unit(0, 0, 0, 0, 0, 1, 0, 1.0d, "mol");
        public static Unit Candela  = new Unit(0, 0, 0, 0, 0, 0, 1, 1.0d, "cd");

        // SI Prefixed units
        public static Unit Kilometer = new Unit(1, 0, 0, 0, 0, 0, 0, 0.001d, "km");

        // SI Derived Units
        public static Unit Newton = new Unit(1, 1, -2, 0, 0, 0, 0, 1.0d, "N");

        // Imperial units
        public static Unit Foot = new Unit(1, 0, 0, 0, 0, 0, 0, 3.28084d, "ft");
        public static Unit Inch = new Unit(1, 0, 0, 0, 0, 0, 0, 1.09361d, "in");
    }


}

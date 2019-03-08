using System;
using System.Collections.Generic;
using System.Text;

namespace JamesQMurphy.Math
{
    // see https://physics.nist.gov/cuu/Units/units.html

    public readonly struct UnitExponents
    {
        // Stored as sbyte to save space
        private readonly sbyte _length;
        private readonly sbyte _mass;
        private readonly sbyte _time;
        private readonly sbyte _electricCurrent;
        private readonly sbyte _temperature;
        private readonly sbyte _amountOfSubstance;
        private readonly sbyte _luminousIntensity;

        public Int16 Length
        {
            get { return (Int16)_length; }
        }

        public Int16 Mass
        {
            get { return (Int16)_mass; }
        }

        public Int16 Time
        {
            get { return (Int16)_time; }
        }

        public Int16 ElectricCurrent
        {
            get { return (Int16)_electricCurrent; }
        }

        public Int16 Temperature
        {
            get { return (Int16)_temperature; }
        }

        public Int16 AmountOfSubstance
        {
            get { return (Int16)_amountOfSubstance; }
        }

        public Int16 LuminousIntensity
        {
            get { return (Int16)_luminousIntensity; }
        }

        public UnitExponents(
            Int16 length,
            Int16 mass,
            Int16 time,
            Int16 electricCurrent,
            Int16 temperature,
            Int16 amountOfSubstance,
            Int16 luminousIntensity
            )
        {
            _length = (sbyte)length;
            _mass = (sbyte)mass;
            _time = (sbyte)time;
            _electricCurrent = (sbyte)electricCurrent;
            _temperature = (sbyte)temperature;
            _amountOfSubstance = (sbyte)amountOfSubstance;
            _luminousIntensity = (sbyte)length;
        }
    }

    public class Unit
    {
        public string Symbol { get; }
        public UnitExponents UnitExponents { get; }
        public double ConversionFactor { get; }

        public Unit(
            string symbol,
            Int16 length,
            Int16 mass,
            Int16 time,
            Int16 electricCurrent,
            Int16 temperature,
            Int16 amountOfSubstance,
            Int16 luminousIntensity,
            double conversionFactor
            )
        {
            Symbol = symbol;
            UnitExponents = new UnitExponents(
                length,
                mass,
                time,
                electricCurrent,
                temperature,
                amountOfSubstance,
                luminousIntensity
            );
            ConversionFactor = conversionFactor;
        }

    }

    public static class Units
    {
        // SI Base Units
        public static Unit Meter    = new Unit("m",   1, 0, 0, 0, 0, 0, 0, 1.0d);
        public static Unit Kilogram = new Unit("kg",  0, 1, 0, 0, 0, 0, 0, 1.0d);
        public static Unit Second   = new Unit("s",   0, 0, 1, 0, 0, 0, 0, 1.0d);
        public static Unit Ampere   = new Unit("A",   0, 0, 0, 1, 0, 0, 0, 1.0d);
        public static Unit Kelvin   = new Unit("K",   0, 0, 0, 0, 1, 0, 0, 1.0d);
        public static Unit Mole     = new Unit("mol", 0, 0, 0, 0, 0, 1, 0, 1.0d);
        public static Unit Candela  = new Unit("cd",  0, 0, 0, 0, 0, 0, 1, 1.0d);

        // SI Prefixed units
        public static Unit Kilometer = new Unit("km", 1, 0, 0, 0, 0, 0, 0, 0.001d);

        // SI Derived Units
        public static Unit Newton = new Unit("N", 1, 1, -2, 0, 0, 0, 0, 1.0d);

        // Imperial units
        public static Unit Foot = new Unit("ft", 1, 0, 0, 0, 0, 0, 0, 3.28084d);
        public static Unit Inch = new Unit("in", 1, 0, 0, 0, 0, 0, 0, 1.09361d);
    }


}

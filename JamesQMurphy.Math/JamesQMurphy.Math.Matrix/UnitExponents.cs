using System;
using System.Text;

namespace JamesQMurphy.Math
{
    // see https://physics.nist.gov/cuu/Units/units.html

    public readonly struct UnitExponents
    {
        private const string _meterSymbol = "m";
        private const string _kilgogramSymbol = "kg";
        private const string _secondsSymbol = "s";
        private const string _ampereSymbol = "A";
        private const string _kelvinSymbol = "K";
        private const string _moleSymbol = "mol";
        private const string _candelaSymbol = "cd";
        private const string _dotSymbol = "*";
        private const string _solidusSymbol = "/";

        // Stored as sbyte to save space
        private readonly sbyte _length;
        private readonly sbyte _mass;
        private readonly sbyte _time;
        private readonly sbyte _electricCurrent;
        private readonly sbyte _temperature;
        private readonly sbyte _amountOfSubstance;
        private readonly sbyte _luminousIntensity;

        private string _getUnitString()
        {
            //var sbNumerator = new StringBuilder();
            //var sbDenominator = new StringBuilder();

            return String.Empty;
        }

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
            _luminousIntensity = (sbyte)luminousIntensity;
        }

        public override string ToString()
        {
            return _getUnitString();
        }
    }
}
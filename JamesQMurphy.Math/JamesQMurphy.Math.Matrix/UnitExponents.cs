using System;
using System.Text;

namespace JamesQMurphy.Math
{
    // see https://physics.nist.gov/cuu/Units/units.html

    public readonly struct UnitExponents : IEquatable<UnitExponents>
    {
        private const string _meterSymbol = "m";
        private const string _kilgogramSymbol = "kg";
        private const string _secondsSymbol = "s";
        private const string _ampereSymbol = "A";
        private const string _kelvinSymbol = "K";
        private const string _moleSymbol = "mol";
        private const string _candelaSymbol = "cd";
        private const string _dotSymbol = "*";
        private const string _exponentSymbol = "^";
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
            var up = new UnitParser();
            up.Append(_meterSymbol, _length);
            up.Append(_kilgogramSymbol, _mass);
            up.Append(_secondsSymbol, _time);
            up.Append(_ampereSymbol, _electricCurrent);
            up.Append(_kelvinSymbol, _temperature);
            up.Append(_moleSymbol, _amountOfSubstance);
            up.Append(_candelaSymbol, _luminousIntensity);
            return up.ToString();
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

        public override bool Equals(object obj)
        {
            if (obj is UnitExponents)
            {
                return Equals((UnitExponents)obj);
            }
            else
            {
                return false;
            }
        }

        public override int GetHashCode()
        {
            return (int)_length &
                   ((int)_mass << 4) &
                   ((int)_time << 8) &
                   ((int)_electricCurrent << 12) &
                   ((int)_temperature << 16) &
                   ((int)_amountOfSubstance << 20) &
                   ((int)_luminousIntensity << 24);
        }

        public bool Equals(UnitExponents other)
        {
            return Equals(this, other);
        }

        public static bool Equals(UnitExponents left, UnitExponents right)
        {
            return (left._length == right._length)
                && (left._mass == right._mass)
                && (left._time == right._time)
                && (left._electricCurrent == right._electricCurrent)
                && (left._temperature == right._temperature)
                && (left._amountOfSubstance == right._amountOfSubstance)
                && (left._luminousIntensity == right._luminousIntensity);
        }

        public static UnitExponents Multiply(UnitExponents left, UnitExponents right)
        {
            return new UnitExponents(
                (Int16)(left.Length + right.Length),
                (Int16)(left.Mass + right.Mass),
                (Int16)(left.Time + right.Time),
                (Int16)(left.ElectricCurrent + right.ElectricCurrent),
                (Int16)(left.Temperature + right.Temperature),
                (Int16)(left.AmountOfSubstance + right.AmountOfSubstance),
                (Int16)(left.LuminousIntensity + right.LuminousIntensity)
                );
        }

        public static UnitExponents Divide(UnitExponents left, UnitExponents right)
        {
            return new UnitExponents(
                (Int16)(left.Length - right.Length),
                (Int16)(left.Mass - right.Mass),
                (Int16)(left.Time - right.Time),
                (Int16)(left.ElectricCurrent - right.ElectricCurrent),
                (Int16)(left.Temperature - right.Temperature),
                (Int16)(left.AmountOfSubstance - right.AmountOfSubstance),
                (Int16)(left.LuminousIntensity - right.LuminousIntensity)
                );
        }

        #region Operator Overloads
        public static bool operator ==(UnitExponents left, UnitExponents right)
        {
            return UnitExponents.Equals(left, right);
        }
        public static bool operator !=(UnitExponents left, UnitExponents right)
        {
            return !UnitExponents.Equals(left, right);
        }
        public static UnitExponents operator *(UnitExponents left, UnitExponents right)
        {
            return Multiply(left, right);
        }
        public static UnitExponents operator /(UnitExponents left, UnitExponents right)
        {
            return Divide(left, right);
        }
        #endregion
    }
}
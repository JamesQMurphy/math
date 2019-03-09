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
            var sbNumerator = new StringBuilder();
            var sbDenominator = new StringBuilder();
            int numNumeratorTerms = 0;
            int numDenominatorTerms = 0;

            void AppendToProperStringBuilder(sbyte exponent, string symbol)
            {
                if (exponent < 0)
                {
                    sbDenominator.Append($"{_dotSymbol}{symbol}{_exponentSymbol}{exponent}");
                    ++numDenominatorTerms;
                }
                if (exponent > 0)
                {
                    sbNumerator.Append($"{_dotSymbol}{symbol}");
                    ++numNumeratorTerms;
                }
                if (exponent > 1)
                {
                    sbNumerator.Append($"{_exponentSymbol}{exponent}");
                }
            }

            AppendToProperStringBuilder(_length, _meterSymbol);
            AppendToProperStringBuilder(_mass, _kilgogramSymbol);
            AppendToProperStringBuilder(_time, _secondsSymbol);
            AppendToProperStringBuilder(_electricCurrent, _ampereSymbol);
            AppendToProperStringBuilder(_temperature, _kelvinSymbol);
            AppendToProperStringBuilder(_amountOfSubstance, _moleSymbol);
            AppendToProperStringBuilder(_luminousIntensity, _candelaSymbol);

            // Remove leading dot symbols
            if (sbNumerator.Length > 0)
            {
                sbNumerator.Remove(0, 1);
            }
            if (sbDenominator.Length > 0)
            {
                sbDenominator.Remove(0, 1);
            }

            // If there's only a denominator, just return that
            if (numNumeratorTerms == 0)
            {
                return sbDenominator.ToString();
            }

            if (numDenominatorTerms > 0)
            {
                // Since there is both a numerator and a denominator, we need to
                // reformat the denominator by changing the signs on the exponents
                // and removing any "^1"'s
                sbDenominator.Replace("-", String.Empty);
                sbDenominator.Replace($"{_exponentSymbol}1", String.Empty);

                // If the denominator has more than one term, wrap it in parentheses
                if (numDenominatorTerms > 1)
                {
                    sbDenominator.Insert(0, '(');
                    sbDenominator.Append(')');
                }

                // Append the modified denominator
                sbNumerator.Append(_solidusSymbol);
                sbNumerator.Append(sbDenominator.ToString());

            }
            return sbNumerator.ToString();
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
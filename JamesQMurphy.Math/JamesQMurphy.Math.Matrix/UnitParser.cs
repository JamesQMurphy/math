using System;
using System.Collections.Generic;
using System.Text;

namespace JamesQMurphy.Math
{
    public class UnitParser
    {
        private Dictionary<string, int> _units = new Dictionary<string, int>();

        public string DotSymbol { get; set; } = "*";
        public string ExponentSymbol { get; set; } = "^";
        public string SolidusSymbol { get; set; } = "/";

        private void _parse(string s, int flipped = 1)
        {
            // break into numerator and denominator
            string[] bothHalves = s.Split(new string[] { SolidusSymbol }, 2, StringSplitOptions.None);
            var numerator = bothHalves[0].Trim();

            // check if surrounded by parentheses
            if (numerator.StartsWith("("))
            {
                if (numerator.EndsWith(")"))
                {
                    _parse(numerator.Substring(1, numerator.Length - 2), flipped);
                    return;
                }
                throw new FormatException($"Expected ) at the end of {numerator}");
            }
            if (numerator.EndsWith(")"))
            {
                throw new FormatException($"Missing ( at the beginning of {numerator}");
            }

            // numerator is in bothHalves[0]
            // break into terms
            foreach ( var term in numerator.Split(new string[] { DotSymbol }, StringSplitOptions.None))
            {
                // split each term on the exponent sign
                var exponent = flipped;
                string[] termParts = term.Split(new string[] { ExponentSymbol }, 2, StringSplitOptions.None);
                if (termParts.Length == 2)
                {
                    exponent *= Convert.ToInt32(termParts[1]);
                }
                Append(termParts[0], exponent);
            }

            // if there's a denominator, parse it flipped
            if (bothHalves.Length == 2)
            {
                _parse(bothHalves[1], flipped * -1);
            }
        }

        public void Append(string units)
        {
            _parse(units);
        }
        public void AppendFlipped(string units)
        {
            _parse(units, -1);
        }
        public void Append(string unit, int exponent)
        {
            if (unit.Contains(DotSymbol) || unit.Contains(SolidusSymbol) || unit.Contains(ExponentSymbol))
            {
                throw new ArgumentException($"Encountered unexpected symbol in unit {unit}", "unit");
            }
            if ( _units.ContainsKey(unit))
            {
                _units[unit] += exponent;
            }
            else
            {
                _units[unit] = exponent;
            }
        }
        public override string ToString()
        {
            var sbNumerator = new StringBuilder();
            var sbDenominator = new StringBuilder();
            int numNumeratorTerms = 0;
            int numDenominatorTerms = 0;

            foreach (string unit in _units.Keys)
            {
                var exponent = _units[unit];
                if (exponent < 0)
                {
                    sbDenominator.Append($"{DotSymbol}{unit}{ExponentSymbol}{exponent}");
                    ++numDenominatorTerms;
                }
                if (exponent > 0)
                {
                    sbNumerator.Append($"{DotSymbol}{unit}");
                    ++numNumeratorTerms;
                }
                if (exponent > 1)
                {
                    sbNumerator.Append($"{ExponentSymbol}{exponent}");
                }
            }
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
                sbDenominator.Replace($"{ExponentSymbol}1", String.Empty);

                // If the denominator has more than one term, wrap it in parentheses
                if (numDenominatorTerms > 1)
                {
                    sbDenominator.Insert(0, '(');
                    sbDenominator.Append(')');
                }

                // Append the modified denominator
                sbNumerator.Append(SolidusSymbol);
                sbNumerator.Append(sbDenominator.ToString());

            }
            return sbNumerator.ToString();
        }
    }
}

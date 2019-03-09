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
            return $"{_SIvalue} {_unitExponents}";
        }
    }
}

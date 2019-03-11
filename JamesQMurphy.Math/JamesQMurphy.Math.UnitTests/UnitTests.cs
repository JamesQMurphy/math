using NUnit.Framework;
using JamesQMurphy.Math;
using System;

namespace JamesQMurphy.Math.UnitTests
{
    public class UnitTests
    {
        [Test]
        public void MustSupplySymbolIfConversionFactorNot1()
        {
            Assert.Throws<InvalidOperationException>(
                () => new Unit(1, 0, 0, 0, 0, 0, 0, 2.0d)
            );
        }

        [Test]
        public void BaseUnitsToString()
        {
            Assert.AreEqual("m", Units.Meter.ToString());
            Assert.AreEqual("kg", Units.Kilogram.ToString());
            Assert.AreEqual("s", Units.Second.ToString());
            Assert.AreEqual("A", Units.Ampere.ToString());
            Assert.AreEqual("K", Units.Kelvin.ToString());
            Assert.AreEqual("mol", Units.Mole.ToString());
            Assert.AreEqual("cd", Units.Candela.ToString());
        }

        [Test]
        public void Equality()
        {
            var u1 = new Unit(1, 4, 0, 2, -3, -2, 1, 2.0d, "one");
            var u2 = new Unit(1, 4, 0, 2, -3, -2, 1, 2.0d, "two");
            var u3 = new Unit(0, 4, 0, 2, -3, -2, -1, 4.0d, "three");
            Assert.AreEqual(u1, u2);
            Assert.AreNotSame(u1, u2);

            Assert.IsTrue(u1 == u2);
            Assert.IsFalse(u1 == u3);
            Assert.IsTrue(u1.Equals(u2));
            Assert.IsTrue(object.Equals(u1, u2));
        }

        [Test]
        public void InEquality()
        {
            var u1 = new Unit(1, 4, 0, 2, -3, -2, 1, 2.0d, "one");
            var u2 = new Unit(1, 4, 0, 2, -3, -2, 1, 2.0d, "two");
            var u3 = new Unit(0, 4, 0, 2, -3, -2, -1, 4.0d, "three");
            Assert.AreNotEqual(u1, u3);
            Assert.AreNotSame(u1, u2);

            Assert.IsFalse(u1 != u2);
            Assert.IsTrue(u1 != u3);
            Assert.IsFalse(u1.Equals(u3));
            Assert.IsFalse(object.Equals(u1, u3));
        }



        [Test]
        public void CanMultiply()
        {
            var u1 = new Unit(1, 0, 0, 2, -3, -2, 1, 2.0d, "one");
            var u2 = new Unit(0, 4, 1, -1, 0, -2, -1, 4.0d, "two");
            var uProduct = u1 * u2;
            Assert.AreEqual(1, uProduct.UnitExponents.Length);
            Assert.AreEqual(4, uProduct.UnitExponents.Mass);
            Assert.AreEqual(1, uProduct.UnitExponents.Time);
            Assert.AreEqual(1, uProduct.UnitExponents.ElectricCurrent);
            Assert.AreEqual(-3, uProduct.UnitExponents.Temperature);
            Assert.AreEqual(-4, uProduct.UnitExponents.AmountOfSubstance);
            Assert.AreEqual(0, uProduct.UnitExponents.LuminousIntensity);
            Assert.AreEqual(8.0d, uProduct.ConversionFactor);
            Assert.AreEqual("one*two", uProduct.Symbol);
        }

        [Test]
        public void CanDivide()
        {
            var u1 = new Unit(1, 0, 0, 2, -3, -2, 1, 6.0d, "one");
            var u2 = new Unit(0, 4, 1, -1, 0, -2, -1, 3.0d, "two");
            var uQuotient = u1 / u2;
            Assert.AreEqual(1, uQuotient.UnitExponents.Length);
            Assert.AreEqual(-4, uQuotient.UnitExponents.Mass);
            Assert.AreEqual(-1, uQuotient.UnitExponents.Time);
            Assert.AreEqual(3, uQuotient.UnitExponents.ElectricCurrent);
            Assert.AreEqual(-3, uQuotient.UnitExponents.Temperature);
            Assert.AreEqual(0, uQuotient.UnitExponents.AmountOfSubstance);
            Assert.AreEqual(2, uQuotient.UnitExponents.LuminousIntensity);
            Assert.AreEqual(2.0d, uQuotient.ConversionFactor);
            Assert.AreEqual("one/two", uQuotient.Symbol);
        }

        [Test]
        public void CanDivideTwice()
        {
            var u1 = new Unit(1, 0, 0, 2, -3, -2, 1, 6.0d, "one");
            var u2 = new Unit(0, 4, 1, -1, 0, -2, -1, 3.0d, "two");
            var u3 = new Unit(1, 2, 1, -1, 4, -2, -1, 2.0d, "three");
            var uQuotient = (u1 / u2) / u3;
            Assert.AreEqual(0, uQuotient.UnitExponents.Length);
            Assert.AreEqual(-6, uQuotient.UnitExponents.Mass);
            Assert.AreEqual(-2, uQuotient.UnitExponents.Time);
            Assert.AreEqual(4, uQuotient.UnitExponents.ElectricCurrent);
            Assert.AreEqual(-7, uQuotient.UnitExponents.Temperature);
            Assert.AreEqual(2, uQuotient.UnitExponents.AmountOfSubstance);
            Assert.AreEqual(3, uQuotient.UnitExponents.LuminousIntensity);
            Assert.AreEqual(1.0d, uQuotient.ConversionFactor);
            Assert.AreEqual("one/(two*three)", uQuotient.Symbol);
        }

        [Test]
        public void CompositeUnitsUseUnitsSupplied1()
        {
            var kilowatt = new Unit(2, 1, -3, 0, 0, 0, 0, 1000d, "kW");
            var hour = new Unit(0, 0, 1, 0, 0, 0, 0, 3600d, "h");
            var kilowatt_hour = kilowatt * hour;

            Assert.AreEqual(2, kilowatt_hour.UnitExponents.Length);
            Assert.AreEqual(1, kilowatt_hour.UnitExponents.Mass);
            Assert.AreEqual(-2, kilowatt_hour.UnitExponents.Time);
            Assert.AreEqual(0, kilowatt_hour.UnitExponents.ElectricCurrent);
            Assert.AreEqual(0, kilowatt_hour.UnitExponents.Temperature);
            Assert.AreEqual(0, kilowatt_hour.UnitExponents.AmountOfSubstance);
            Assert.AreEqual(0, kilowatt_hour.UnitExponents.LuminousIntensity);
            Assert.AreEqual(3600000d, kilowatt_hour.ConversionFactor);
            Assert.AreEqual("kW*h", kilowatt_hour.ToString());
        }

        [Test]
        public void CompositeUnitsUseUnitsSupplied2()
        {
            var footPerSecond = Units.Foot / Units.Second;

            Assert.AreEqual(1, footPerSecond.UnitExponents.Length);
            Assert.AreEqual(0, footPerSecond.UnitExponents.Mass);
            Assert.AreEqual(-1, footPerSecond.UnitExponents.Time);
            Assert.AreEqual(0, footPerSecond.UnitExponents.ElectricCurrent);
            Assert.AreEqual(0, footPerSecond.UnitExponents.Temperature);
            Assert.AreEqual(0, footPerSecond.UnitExponents.AmountOfSubstance);
            Assert.AreEqual(0, footPerSecond.UnitExponents.LuminousIntensity);
            Assert.AreEqual(3.28d, footPerSecond.ConversionFactor, 0.001d);
            Assert.AreEqual("ft/s", footPerSecond.ToString());
        }

        [Test]
        public void Convert()
        {
            Assert.AreEqual(24d, Units.Convert(2d, Units.Foot, Units.Inch), 1e-9d);
        }

        [Test]
        public void ConvertTemperature()
        {
            Assert.AreEqual(273.15d, Units.Convert(0d, Units.DegreesCelsius, Units.Kelvin), 1e-9);
            Assert.AreEqual(491.67d, Units.Convert(0d, Units.DegreesCelsius, Units.Rankine), 1e-9);
            Assert.AreEqual(32d, Units.Convert(0d, Units.DegreesCelsius, Units.DegreesFahrenheit), 1e-9);
        }
    }
}

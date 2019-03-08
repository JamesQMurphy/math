using NUnit.Framework;
using JamesQMurphy.Math;
using System;

namespace JamesQMurphy.Math.UnitTests
{
    public class QuantityTests
    {
        [Test]
        public void ToString_NoParameters_BaseUnits()
        {
            Assert.AreEqual("2 m", new Quantity(2d, Units.Meter).ToString());
            Assert.AreEqual("2 kg", new Quantity(2d, Units.Kilogram).ToString());
            Assert.AreEqual("2 s", new Quantity(2d, Units.Second).ToString());
            Assert.AreEqual("2 A", new Quantity(2d, Units.Ampere).ToString());
            Assert.AreEqual("2 K", new Quantity(2d, Units.Kelvin).ToString());
            Assert.AreEqual("2 mol", new Quantity(2d, Units.Mole).ToString());
            Assert.AreEqual("2 cd", new Quantity(2d, Units.Candela).ToString());
        }

        [Test]
        public void CanConvert()
        {
            var q = new Quantity(2d, Units.Kilometer);
            Assert.AreEqual(2000d, q.In(Units.Meter));
        }

        [Test]
        public void ThrowsConversionException()
        {
            var q = new Quantity(1d, Units.Meter);
            Assert.Throws<ArgumentException>(()=> q.In(Units.Kilogram));
        }
    }
}

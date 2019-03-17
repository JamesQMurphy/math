using NUnit.Framework;
using System;

namespace JamesQMurphy.Math.UnitTests
{
    public class QuantityTests
    {
        [Test]
        public void DefaultIsZero()
        {
            var q = default(Quantity);

            Assert.AreEqual(0d, q.In(Units.Dimensionless));
            Assert.AreEqual("0", q.ToString());
        }

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
        public void CanConvert1()
        {
            var q = new Quantity(2d, Units.Kilometer);
            Assert.AreEqual(2000d, q.In(Units.Meter));
        }

        [Test]
        public void CanConvert2()
        {
            var q1 = new Quantity(1e6, Units.BritishThermalUnit);
            var q2 = new Quantity(1.054615, Units.Gigajoule);
            Assert.AreEqual(q1.In(Units.Joule), q2.In(Units.Joule), 500d);
        }



        [Test]
        public void CanConvertTemperature()
        {
            var q = new Quantity(212d, Units.DegreesFahrenheit);
            Assert.AreEqual(100d, q.In(Units.DegreesCelsius), 1e-9d);
        }

        [Test]
        public void ThrowsConversionException()
        {
            var q = new Quantity(1d, Units.Meter);
            Assert.Throws<ArgumentException>(()=> q.In(Units.Kilogram));
            Assert.Throws<ArgumentException>(() => q.ToString(Units.Kilogram));
        }

        [Test]
        public void CanMultiplyByScalar()
        {
            var q = new Quantity(2d, Units.Kilogram);
            var q2 = 4.0d * q;
            var q3 = q * 4.0d;
            Assert.AreEqual(new Quantity(8d, Units.Kilogram), q2);
            Assert.AreEqual(new Quantity(8d, Units.Kilogram), q3);
        }

        [Test]
        public void CanDivideByScalar()
        {
            var q = new Quantity(8d, Units.Mole);
            var q2 = q / 4.0d;
            Assert.AreEqual(new Quantity(2d, Units.Mole), q2);

            var q3 = 4.0d / q;
            Assert.AreEqual(new Quantity(0.5d, new Unit(0, 0, 0, 0, 0, -1, 0, 1.0d)), q3);
        }

        [Test]
        public void Reciprocal()
        {
            var q = new Quantity(8d, Units.Second);
            var q2 = q.Reciprocal;
            Assert.AreEqual(new Quantity(0.125d, Units.Hertz), q2);
        }

        [Test]
        public void Calculation1()
        {
            var accel = new Quantity(15d, Units.Meter / (Units.Second * Units.Second));
            var mass = new Quantity(5d, Units.Kilogram);
            var force = mass * accel;
            Assert.AreEqual("75 m*kg/s^2", force.ToString());
            Assert.AreEqual(new Quantity(75d, Units.Newton), force);
            Assert.AreEqual(75d, force.In(Units.Newton));
            Assert.AreEqual("75 N", force.ToString(Units.Newton));
        }

        [Test]
        public void Calculation2()
        {
            // At what temperature will 0.654 moles of neon gas occupy 12.30 liters at 1.95 atmospheres?
            // source:  https://www.chemteam.info/GasLaw/Gas-Ideal-Prob1-10.html (Problem #3)

            var P = new Quantity(1.95, Units.Atmosphere);
            var V = new Quantity(12.30, Units.Liter);
            var n = new Quantity(0.654, Units.Mole);

            // We can specify the gas constant in *any* units
            var R = new Quantity(8.3144598, Units.Joule / (Units.Mole * Units.Kelvin));

            var T = P * V / (n * R);
            Assert.AreEqual(447d, T.In(Units.Kelvin), 0.5d);
        }
    }
}

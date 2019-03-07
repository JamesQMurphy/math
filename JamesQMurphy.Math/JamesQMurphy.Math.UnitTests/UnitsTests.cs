using NUnit.Framework;
using JamesQMurphy.Math;

namespace JamesQMurphy.Math.UnitTests
{
    public class UnitsTests
    {
        [Test]
        public void Second()
        {
            Assert.AreEqual(0, Units.Second.Length);
            Assert.AreEqual(0, Units.Second.Mass);
            Assert.AreEqual(1, Units.Second.Time);
            Assert.AreEqual(0, Units.Second.ElectricCurrent);
            Assert.AreEqual(0, Units.Second.Temperature);
            Assert.AreEqual(0, Units.Second.AmountOfSubstance);
            Assert.AreEqual(0, Units.Second.LuminousIntensity);

        }
    }
}

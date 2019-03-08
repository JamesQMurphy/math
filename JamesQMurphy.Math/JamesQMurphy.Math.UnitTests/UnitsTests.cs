using NUnit.Framework;
using JamesQMurphy.Math;

namespace JamesQMurphy.Math.UnitTests
{
    public class UnitsTests
    {
        [Test]
        public void SingleSymbol()
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
        public void SquaredSymbols()
        {
            Assert.AreEqual("m^2", new UnitExponents(2, 0, 0, 0, 0, 0, 0).ToString());
            Assert.AreEqual("kg^2", new UnitExponents(0, 2, 0, 0, 0, 0, 0).ToString());
            Assert.AreEqual("s^2", new UnitExponents(0, 0, 2, 0, 0, 0, 0).ToString());
            Assert.AreEqual("A^2", new UnitExponents(0, 0, 0, 2, 0, 0, 0).ToString());
            Assert.AreEqual("K^2", new UnitExponents(0, 0, 0, 0, 2, 0, 0).ToString());
            Assert.AreEqual("mol^2", new UnitExponents(0, 0, 0, 0, 0, 2, 0).ToString());
            Assert.AreEqual("cd^2", new UnitExponents(0, 0, 0, 0, 0, 0, 2).ToString());
        }

        [Test]
        public void InverseSymbols()
        {
            Assert.AreEqual("m^-1", new UnitExponents(-1, 0, 0, 0, 0, 0, 0).ToString());
            Assert.AreEqual("kg^-1", new UnitExponents(0, -1, 0, 0, 0, 0, 0).ToString());
            Assert.AreEqual("s^-1", new UnitExponents(0, 0, -1, 0, 0, 0, 0).ToString());
            Assert.AreEqual("A^-1", new UnitExponents(0, 0, 0, -1, 0, 0, 0).ToString());
            Assert.AreEqual("K^-1", new UnitExponents(0, 0, 0, 0, -1, 0, 0).ToString());
            Assert.AreEqual("mol^-1", new UnitExponents(0, 0, 0, 0, 0, -1, 0).ToString());
            Assert.AreEqual("cd^-1", new UnitExponents(0, 0, 0, 0, 0, 0, -1).ToString());
        }

        [Test]
        public void InverseSquaredSymbols()
        {
            Assert.AreEqual("m^-2", new UnitExponents(-2, 0, 0, 0, 0, 0, 0).ToString());
            Assert.AreEqual("kg^-2", new UnitExponents(0, -2, 0, 0, 0, 0, 0).ToString());
            Assert.AreEqual("s^-2", new UnitExponents(0, 0, -2, 0, 0, 0, 0).ToString());
            Assert.AreEqual("A^-2", new UnitExponents(0, 0, 0, -2, 0, 0, 0).ToString());
            Assert.AreEqual("K^-2", new UnitExponents(0, 0, 0, 0, -2, 0, 0).ToString());
            Assert.AreEqual("mol^-2", new UnitExponents(0, 0, 0, 0, 0, -2, 0).ToString());
            Assert.AreEqual("cd^-2", new UnitExponents(0, 0, 0, 0, 0, 0, -2).ToString());
        }

        [Test]
        public void SymbolProducts()
        {
            Assert.AreEqual("m*kg", new UnitExponents(1, 1, 0, 0, 0, 0, 0).ToString());
            Assert.AreEqual("m*s", new UnitExponents(1, 0, 1, 0, 0, 0, 0).ToString());
            Assert.AreEqual("kg*s", new UnitExponents(0, 1, 1, 0, 0, 0, 0).ToString());
            Assert.AreEqual("s*A", new UnitExponents(0, 0, 1, 1, 0, 0, 0).ToString());
            Assert.AreEqual("K*mol", new UnitExponents(0, 0, 0, 0, 1, 1, 0).ToString());
            Assert.AreEqual("s*cd", new UnitExponents(0, 0, 1, 0, 0, 0, 1).ToString());
            Assert.AreEqual("m*kg*s", new UnitExponents(1, 1, 1, 0, 0, 0, 0).ToString());
        }

        [Test]
        public void SymbolDivision()
        {
            Assert.AreEqual("kg/m", new UnitExponents(-1, 1, 0, 0, 0, 0, 0).ToString());
            Assert.AreEqual("m/s", new UnitExponents(1, 0, -1, 0, 0, 0, 0).ToString());
            Assert.AreEqual("kg/s", new UnitExponents(0, 1, -1, 0, 0, 0, 0).ToString());
            Assert.AreEqual("cd/s", new UnitExponents(0, 0, -1, 0, 0, 0, -1).ToString());
        }

        [Test]
        public void SymbolComplicated()
        {
            Assert.AreEqual("K/(s*mol)", new UnitExponents(0, 0, -1, 0, 1, 1, 0).ToString());
            Assert.AreEqual("m*kg/s", new UnitExponents(1, 1, -1, 0, 0, 0, 0).ToString());
            Assert.AreEqual("m*kg/s^2", new UnitExponents(1, 1, -2, 0, 0, 0, 0).ToString());
            Assert.AreEqual("m*kg/(K*mol)", new UnitExponents(1, 1, 0, 0, -1, -1, 0).ToString());
            Assert.AreEqual("m^2*s^3/(kg^2*K*mol^3)", new UnitExponents(2, -2, 3, 0, 1, -3, 0).ToString());
        }

    }
}

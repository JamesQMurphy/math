using NUnit.Framework;
using JamesQMurphy.Math;

namespace JamesQMurphy.Math.UnitTests
{
    public class UnitExponentsTests
    {
        [Test]
        public void SingleSymbol()
        {
            Assert.AreEqual("m", new UnitExponents(1, 0, 0, 0, 0, 0, 0).ToString());
            Assert.AreEqual("kg", new UnitExponents(0, 1, 0, 0, 0, 0, 0).ToString());
            Assert.AreEqual("s", new UnitExponents(0, 0, 1, 0, 0, 0, 0).ToString());
            Assert.AreEqual("A", new UnitExponents(0, 0, 0, 1, 0, 0, 0).ToString());
            Assert.AreEqual("K", new UnitExponents(0, 0, 0, 0, 1, 0, 0).ToString());
            Assert.AreEqual("mol", new UnitExponents(0, 0, 0, 0, 0, 1, 0).ToString());
            Assert.AreEqual("cd", new UnitExponents(0, 0, 0, 0, 0, 0, 1).ToString());
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
            Assert.AreEqual("cd/s", new UnitExponents(0, 0, -1, 0, 0, 0, 1).ToString());
        }

        [Test]
        public void SymbolComplicated()
        {
            Assert.AreEqual("K/(s*mol)", new UnitExponents(0, 0, -1, 0, 1, -1, 0).ToString());
            Assert.AreEqual("m*kg/s", new UnitExponents(1, 1, -1, 0, 0, 0, 0).ToString());
            Assert.AreEqual("m*kg/s^2", new UnitExponents(1, 1, -2, 0, 0, 0, 0).ToString());
            Assert.AreEqual("m*kg/(K*mol)", new UnitExponents(1, 1, 0, 0, -1, -1, 0).ToString());
            Assert.AreEqual("m^2*s^3/(kg^2*K*mol^3)", new UnitExponents(2, -2, 3, 0, -1, -3, 0).ToString());
            Assert.AreEqual("m^2*s^3*K/(kg^2*mol^3)", new UnitExponents(2, -2, 3, 0, 1, -3, 0).ToString());
        }

        [Test]
        public void Equality()
        {
            var ue1 = new UnitExponents(1, 4, 0, 2, -3, -2, 1);
            var ue2 = new UnitExponents(1, 4, 0, 2, -3, -2, 1);
            var ue3 = new UnitExponents(0, 4, 0, 2, -3, -2, -1);
            Assert.AreEqual(ue1, ue2);
            Assert.AreNotSame(ue1, ue2);

            Assert.IsTrue(ue1 == ue2);
            Assert.IsFalse(ue1 == ue3);
            Assert.IsTrue(ue1.Equals(ue2));
            Assert.IsTrue(object.Equals(ue1, ue2));
        }

        [Test]
        public void InEquality()
        {
            var ue1 = new UnitExponents(1, 4, 0, 2, -3, -2, 1);
            var ue2 = new UnitExponents(1, 4, 0, 2, -3, -2, 1);
            var ue3 = new UnitExponents(0, 4, 0, 2, -3, -2, -1);
            Assert.AreNotEqual(ue1, ue3);
            Assert.AreNotSame(ue1, ue2);

            Assert.IsFalse(ue1 != ue2);
            Assert.IsTrue(ue1 != ue3);
            Assert.IsFalse(ue1.Equals(ue3));
            Assert.IsFalse(object.Equals(ue1, ue3));
        }



        [Test]
        public void CanMultiply()
        {
            var ue1 = new UnitExponents(1, 0, 0, 2, -3, -2, 1);
            var ue2 = new UnitExponents(0, 4, 1, -1, 0, -2, -1);
            var ueProduct = ue1 * ue2;
            Assert.AreEqual(1, ueProduct.Length);
            Assert.AreEqual(4, ueProduct.Mass);
            Assert.AreEqual(1, ueProduct.Time);
            Assert.AreEqual(1, ueProduct.ElectricCurrent);
            Assert.AreEqual(-3, ueProduct.Temperature);
            Assert.AreEqual(-4, ueProduct.AmountOfSubstance);
            Assert.AreEqual(0, ueProduct.LuminousIntensity);
        }

        [Test]
        public void CanDivide()
        {
            var ue1 = new UnitExponents(1, 0, 0, 2, -3, -2, 1);
            var ue2 = new UnitExponents(0, 4, 1, -1, 0, -2, -1);
            var ueQuotient = ue1 / ue2;
            Assert.AreEqual(1, ueQuotient.Length);
            Assert.AreEqual(-4, ueQuotient.Mass);
            Assert.AreEqual(-1, ueQuotient.Time);
            Assert.AreEqual(3, ueQuotient.ElectricCurrent);
            Assert.AreEqual(-3, ueQuotient.Temperature);
            Assert.AreEqual(0, ueQuotient.AmountOfSubstance);
            Assert.AreEqual(2, ueQuotient.LuminousIntensity);
        }

        [Test]
        public void ToStringReflectsDivide()
        {
            var ueMeter = new UnitExponents(1, 0, 0, 0, 0, 0, 0);
            var ueSecond = new UnitExponents(0, 0, 1, 0, 0, 0, 0);
            var ueMeterPerSecond = ueMeter / ueSecond;
            Assert.AreEqual("m/s", ueMeterPerSecond.ToString());
        }
    }
}

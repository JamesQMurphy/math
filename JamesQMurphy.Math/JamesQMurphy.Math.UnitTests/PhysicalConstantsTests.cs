using NUnit.Framework;
using System;

namespace JamesQMurphy.Math.UnitTests
{
    public class PhysicalConstantsTests
    {
        [Test]
        public void SpeedOfLight()
        {
            Assert.AreEqual(186282d, PhysicalConstants.SpeedOfLightInVacuum.In(Units.Mile / Units.Second), 0.5d);
        }

        [Test]
        public void GasConstant()
        {
            Assert.AreEqual(0.0821d, PhysicalConstants.GasConstant.In(Units.Liter * Units.Atmosphere / (Units.Mole * Units.Kelvin)), 0.00005d);
        }
    }
}

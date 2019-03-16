using System;
using System.Collections.Generic;
using System.Text;

namespace JamesQMurphy.Math
{
    public static class PhysicalConstants
    {
        // Source: https://en.wikipedia.org/wiki/Physical_constant#Table_of_physical_constants

        // Universal Constants
        public static Quantity ImpedanceOfFreeSpace = new Quantity(376.730313461, Units.Ohm);
        public static Quantity GravitationalConstant = new Quantity(6.67408e-11, new Unit(3, -1, -2, 0, 0, 0, 0, 1.0d));
        public static Quantity PlanckConstant = new Quantity(6.626070040e-34, Units.Joule * Units.Second);
        public static Quantity PlanckConstantReduced = new Quantity(1.054571800e-34, Units.Joule * Units.Second);
        public static Quantity SpeedOfLightInVacuum = new Quantity(299792458d, new Unit(1, 0, -1, 0, 0, 0, 0, 1.0d));

        // Physico-chemical Constants
        public static Quantity AvogadroConstant = new Quantity(6.022140857e-23, new Unit(0, 0, 0, 0, 0, -1, 0, 1.0d));
        public static Quantity BoltzmannConstant = new Quantity(1.38064852e-23, Units.Joule / Units.Kelvin);
        public static Quantity GasConstant = new Quantity(8.3144598, Units.Joule / (Units.Mole * Units.Kelvin));

        // Planck Units
        // Full list at: https://en.wikipedia.org/wiki/Planck_units#Derived_units
        public static Quantity PlanckLength = new Quantity(1.616229e-35, Units.Meter);
        public static Quantity PlanckMass = new Quantity(2.176470e-8, Units.Kilogram);
        public static Quantity PlanckTime = new Quantity(5.39116e-44, Units.Second);
        public static Quantity PlanckCharge = new Quantity(1.875545956e-18, Units.Coulomb);
        public static Quantity PlanckTemperature = new Quantity(1.416808e32, Units.Kelvin);
        public static Quantity PlanckForce = new Quantity(1.21027e44, Units.Newton);

    }
}

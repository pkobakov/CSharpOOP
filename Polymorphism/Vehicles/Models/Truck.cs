using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles.Models
{
    public class Truck:Vehicle
    {
        private const double AC = 1.6;
        private const double wasted = 0.05;
        public Truck (double fuelquantity, double fuelconsumption, int tankCapacity)
            : base(fuelquantity, fuelconsumption + AC, tankCapacity)
        {

        }

        public override double Refuel(double amount)
        {
            base.Refuel(amount);
            return Fuelquantity -= amount * wasted;
        }

    }
}

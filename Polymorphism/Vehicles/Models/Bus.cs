using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles.Models
{
    public class Bus:Vehicle
    {
        private const double AC = 1.4;
        public Bus(double fuelquantity, double fuelconsumption, int tankCapacity)
            : base(fuelquantity, fuelconsumption + AC, tankCapacity)
        {

        }

        public string DriveEmpty(double distance) 
        {

            this.FuelComsumption -= AC;
            return base.Drive(distance);
        }
    }
}

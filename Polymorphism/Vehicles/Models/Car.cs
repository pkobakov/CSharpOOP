using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles.Models
{
   public class Car:Vehicle
    {
        private const double AC = 0.9;
       
        public Car(double fuelquantity, double fuelconsumption, int tankCapacity) 
            : base(fuelquantity, fuelconsumption + AC, tankCapacity)
        {

        }

        
    }
}

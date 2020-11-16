using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles.Models
{
    public abstract class Vehicle
    {
        private double fuelquantity;
        public double  FuelComsumption { get; protected set; }
        public double Fuelquantity  
        {
            get => fuelquantity;

            protected set
            {

                if (value > TankCapacity)
                {
                    fuelquantity = 0;
                }
                else
                {
                    fuelquantity = value;
                }
            } 
        
        }
        public int TankCapacity { get; private set; }
        public Vehicle(double fuelquantity, double fuelconsumption, int tankCapacity)
        {
            this.TankCapacity = tankCapacity;
            this.FuelComsumption = fuelconsumption;
            this.Fuelquantity = fuelquantity;
            
        }
        public virtual double  Refuel (double amount) 
        {
            if (amount<=0)
            {
                throw new Exception("Fuel must be a positive number");
            }

            double totalfuelamount = amount + this.Fuelquantity;


            if (totalfuelamount>TankCapacity)
            {
                throw new Exception($"Cannot fit {amount} fuel in the tank");
            }
            return Fuelquantity += amount;
        }

        public string Drive (double distance)
        {
            string vehicle = this.GetType().Name;
            double neededFuel = FuelComsumption * distance;

            if (Fuelquantity >= neededFuel)
            {
                Fuelquantity -= neededFuel;
                return $"{vehicle} travelled {distance} km";
            }

            else
            {
                return $"{vehicle} needs refueling"; 
            }
           
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.Fuelquantity:f2}";
        }

    }
}

using EasterRaces.Utilities.Messages; 
using System;
using System.Collections.Generic;
using System.Text;

namespace EasterRaces.Models.Cars.Entities
{
    public class MuscleCar : Car
    {
        private const double cubicCentimeters = 5000;
        private const double minHorsePower = 400;
        private const double maxHorsePower = 600;
        private int horsePower;

        public MuscleCar(string model, int horsePower):base(model, horsePower)
        {
            
            this.CubicCentimeters = cubicCentimeters;
        }

        public override double CubicCentimeters { get; }

        public override int HorsePower 
        { 
            get=> this.horsePower;
            protected set 
            {
                if (value<minHorsePower||value>maxHorsePower)
                {
                    string msg = string.Format(ExceptionMessages.InvalidHorsePower, value);
                    throw new ArgumentException(msg);
                }

                horsePower = value;
            } 
            
        }

    }
}

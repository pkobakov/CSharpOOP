using System;
using System.Collections.Generic;
using System.Text;
using EasterRaces.Utilities.Messages;

namespace EasterRaces.Models.Cars.Entities
{
    public class SportsCar:Car
    {
        private const double cubicCentimeters = 3000;
        private const double minHorsePower = 250;
        private const double maxHorsePower = 450;
        private int horsePower;

        public SportsCar(string model, int horsePower):base(model, horsePower)
        {
            this.CubicCentimeters = cubicCentimeters; 
        }

        public override double CubicCentimeters { get;}
        public override int HorsePower
        {
            get => horsePower;
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

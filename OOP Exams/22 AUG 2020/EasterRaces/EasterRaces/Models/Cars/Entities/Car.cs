using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasterRaces.Models
{
    public abstract class Car : ICar
    {
        private string model;
        private const int minimumValueLenght = 4;

        public Car(string model, int horsePower)
        {
            this.Model = model;
            this.HorsePower = horsePower;
           
        }
        public string Model 
        {
            get => this.model;

            private set
            {
                if (string.IsNullOrWhiteSpace(value)||minimumValueLenght<4)
                {
                    string msg = string.Format(ExceptionMessages.InvalidModel, value, minimumValueLenght);
                    throw new ArgumentException(msg);
                }

                this.model = value;
            }
        
        }

        public abstract int HorsePower
        {
            get; protected set;
        }
        

        public abstract double CubicCentimeters 
        {
            get;
        }

        public double CalculateRacePoints(int laps)
        {
            double racePoints = this.CubicCentimeters / this.HorsePower * laps;
            return racePoints;
        }
    }
}

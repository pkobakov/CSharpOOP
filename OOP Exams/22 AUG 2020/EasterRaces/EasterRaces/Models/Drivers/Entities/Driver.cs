using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasterRaces.Models.Drivers.Entities
{
    public  class Driver : IDriver
    {
        private const int minLenght = 5;
        private string name;
        private bool canParticipate;
       

        public Driver(string name)
        {
            this.Name = name;
            this.CanParticipate = false;
        }
        public string Name 
        { 
            get => name;
            private set 
            {

                if (value.Length<minLenght||string.IsNullOrEmpty(value))
                {
                    string msg = string.Format(ExceptionMessages.InvalidName, value, minLenght);
                    throw new ArgumentException(msg);
                }

                name = value;
            
            } 
        }
        public bool CanParticipate 
        {
            get => canParticipate;

            private set
            {
                if ( Car != null)
                {
                    canParticipate = true;
                }

                else
                {
                    canParticipate = false;
                }
               
            }
        
        }
        public ICar Car { get; private set; }

        public int NumberOfWins { get; private set; }

        public void AddCar(ICar car)
        {
            if (car == null)
            {
                string msg = string.Format(ExceptionMessages.CarInvalid);
                throw new ArgumentException(msg);
            }

            Car = car;
            this.CanParticipate = true;
        }

        public void WinRace()
        {
            this.NumberOfWins++;
        }
    }
}

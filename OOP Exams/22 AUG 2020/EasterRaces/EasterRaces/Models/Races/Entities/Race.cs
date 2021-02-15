using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Models.Races.Contracts;
using EasterRaces.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasterRaces.Models.Races.Entities
{
    class Race : IRace
    {
        private const int minLenght = 5;
        private const int minLaps = 1;
        private string name;
        private int laps;
        private readonly List<IDriver> drivers;

        public Race()
        {
            drivers = new List<IDriver>();
        }
        public Race(string name, int laps):this()
        {
            this.Name = name;
            this.Laps = laps;
            
        }
        public string Name 
        {
            get => name;
            private set 
            {
                if (string.IsNullOrEmpty(value)||value.Length<minLenght)
                {
                    string msg = string.Format(ExceptionMessages.InvalidName, value, minLenght);
                    throw new ArgumentException(msg);
                }
                name = value;
            }
         
        }

        public int Laps 
        {
            get => laps;
            private set
            {
                if (value<minLaps)
                {
                    string msg = string.Format(ExceptionMessages.InvalidNumberOfLaps, minLaps);
                    throw new ArgumentException(msg);
                }

                laps = value;
            }
        }

        public IReadOnlyCollection<IDriver> Drivers { get => this.drivers; }

        public void AddDriver(IDriver driver)
        {
            if (driver == null)
            {
                string msg = string.Format(ExceptionMessages.DriverInvalid);
                throw new ArgumentException(msg);
            }

            else if (!driver.CanParticipate)
            {
                string msg = string.Format(ExceptionMessages.DriverNotParticipate, driver.Name);
                throw new ArgumentException(msg);
            }

            else if (drivers.Contains(driver))
            {
                string msg = string.Format(ExceptionMessages.DriversExists, driver.Name, this.Name);
                throw new ArgumentException(msg);
            }

            this.drivers.Add(driver);
        }
    }
}

using System;
using System.Text;
using System.Reflection;
using System.Collections.Generic;

using EasterRaces.Core.Contracts;
using EasterRaces.Repositories.Entities;
using System.Linq;
using EasterRaces.Utilities.Messages;
using EasterRaces.Models.Drivers.Entities;
using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Models.Cars.Entities;
using EasterRaces.Models.Races.Contracts;
using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Models.Races.Entities;
using EasterRaces.Models;

namespace EasterRaces.Core.Entities
{
    public class ChampionshipController : IChampionshipController
    {
        private const int minParticipantsCount = 3;
        private readonly CarRepository carRepository;
        private readonly DriverRepository driverRepository;
        private readonly RaceRepository raceRepository;

        public ChampionshipController()
        {
            carRepository = new CarRepository();
            driverRepository = new DriverRepository();
            raceRepository = new RaceRepository();
        }

        public string AddCarToDriver(string driverName, string carModel)
        {
            if (!driverRepository.GetAll().Any(d=>d.Name == driverName))
            {
                string exceptionMessage = string.Format(ExceptionMessages.DriverNotFound, driverName);
                throw new InvalidOperationException(exceptionMessage);
            }

            if (!carRepository.GetAll().Any(c=>c.Model == carModel))
            {
                string exceptionMessage = string.Format(ExceptionMessages.CarNotFound, carModel);
                throw new InvalidOperationException(exceptionMessage);
            }

            ICar car = carRepository.GetAll().FirstOrDefault(c=>c.Model  == carModel);
            IDriver driver = driverRepository.GetAll().FirstOrDefault(d => d.Name == driverName);
            driver.AddCar(car);
            string outputMessage = string.Format(OutputMessages.CarAdded,driverName, carModel);
            return outputMessage;
        }

        public string AddDriverToRace(string raceName, string driverName)
        {
            if (!raceRepository.GetAll().Any(r => r.Name == raceName))
            {
                string exceptionMessage = string.Format(ExceptionMessages.RaceNotFound, raceName);
                throw new InvalidOperationException(exceptionMessage);
            }

            if (!driverRepository.GetAll().Any(d=>d.Name == driverName))
            {
                string exceptionMessage = string.Format(ExceptionMessages.DriverNotFound, driverName);
                throw new InvalidOperationException(exceptionMessage);
            }

            IRace race = raceRepository.GetAll().FirstOrDefault(r => r.Name == raceName);
            IDriver driver = driverRepository.GetAll().FirstOrDefault(d => d.Name == driverName);
            race.AddDriver(driver);
            string message = string.Format(OutputMessages.DriverAdded, driverName,raceName);
            return message;
        }

        public string CreateCar(string type, string model, int horsePower)
        {
            if (carRepository.GetAll().Any(c=>c.Model == model))
            {
                string exceptionMessage = string.Format(ExceptionMessages.CarExists, model);
                throw new ArgumentException(exceptionMessage);
            }

            ICar car = CarFactory(type, model, horsePower);
            carRepository.Add(car);
            string outputMessage = string.Format(OutputMessages.CarCreated,car.GetType().Name, model);
            return outputMessage; 
        }

        public string CreateDriver(string driverName)
        {
            if (driverRepository.GetAll().Any(n => n.Name == driverName))
            {
                string exceptionMessage = string.Format(ExceptionMessages.DriversExists, driverName);
                throw new ArgumentException(exceptionMessage);
            }

            Driver driver = new Driver(driverName);
            driverRepository.Add(driver);
            string msg = string.Format(OutputMessages.DriverCreated, driverName);
            return msg;
        }

        public string CreateRace(string name, int laps)
        {
            if (raceRepository.GetAll().Any(r=>r.Name == name))
            {
                string exceptionMessage = string.Format(ExceptionMessages.RaceExists, name);
                throw new InvalidOperationException(exceptionMessage);
            }

            Race race = new Race(name, laps);
            raceRepository.Add(race);
            string outputMessage = string.Format(OutputMessages.RaceCreated, name,laps);
            return outputMessage;
        }

        public string StartRace(string raceName)
        {
            if (!raceRepository.GetAll().Any(r=>r.Name == raceName))
            {
                string exceptionMessage = string.Format(ExceptionMessages.RaceNotFound, raceName);
                throw new InvalidOperationException(exceptionMessage);
            }
            IRace race = raceRepository.GetAll().FirstOrDefault(r => r.Name == raceName);

            if (race.Drivers.Count<minParticipantsCount)
            {
                string exceptionMessage = string.Format(ExceptionMessages.RaceInvalid, raceName, minParticipantsCount);
                throw new InvalidOperationException(exceptionMessage);
            }

            int lapsCount = race.Laps;
            List<IDriver> drivers = race.Drivers
                                        .ToList()
                                        .OrderByDescending(d => d.Car.CalculateRacePoints(lapsCount))
                                        .Take(3)
                                        .ToList();

            
            int count = 1;
            string message = null;
            StringBuilder sb = new StringBuilder();
            raceRepository.Remove(race);
            foreach (var driver in drivers)
            {
                if (count == 1 )
                {
                    message = string.Format(OutputMessages.DriverFirstPosition, driver.Name, race.Name);
                    
                }

                else if (count == 2)
                {
                    message = string.Format(OutputMessages.DriverSecondPosition, driver.Name, race.Name);
                }

                else if (count == 3)
                {
                    message = string.Format(OutputMessages.DriverThirdPosition, driver.Name, race.Name);
                }

                sb.AppendLine(message);
                count++;
            }

            return sb.ToString().Trim();
        }


        private static ICar CarFactory(string type, string model, int horsePower) 
        {
            ICar car = null;

            if (type == "Muscle"  )
            {
                car = new MuscleCar(model, horsePower);
            }

            if (type == "Sports")
            {
                car = new SportsCar(model, horsePower);
            }

            return car;
        }

    }

   

}

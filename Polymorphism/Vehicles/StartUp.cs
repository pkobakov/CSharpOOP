using System;
using System.Linq;
using System.Collections.Generic;
using Vehicles.Models;

namespace Vehicles
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[]carArgs = Console.ReadLine()
                                    .Split()
                                    .ToArray();
            
            double carFuelQuantity = double.Parse(carArgs[1]);
            double carFuelConsumption = double.Parse(carArgs[2]);
            int cartankcapacity = int.Parse(carArgs[3]); 
            Car car = new Car(carFuelQuantity, carFuelConsumption, cartankcapacity);

            string[] truckArgs = Console.ReadLine()
                                    .Split()
                                    .ToArray();
          
            double truckFuelQuantity = double.Parse(truckArgs[1]);
            double truckFuelConsumption = double.Parse(truckArgs[2]);
            int truckTankCapacity = int.Parse(truckArgs[3]);

            Truck truck = new Truck(truckFuelQuantity, truckFuelConsumption,truckTankCapacity);

            string[] busArgs = Console.ReadLine()
                                    .Split()
                                    .ToArray();

            double busFuelQuantity = double.Parse(busArgs[1]);
            double busFuelConsumption = double.Parse(busArgs[2]);
            int busTankCapacity = int.Parse(busArgs[3]);

            Bus bus = new Bus(busFuelQuantity, busFuelConsumption, busTankCapacity);


            int commands = int.Parse(Console.ReadLine());

            for (int i = 0; i < commands; i++)
            {
                string[] commandArgs = Console.ReadLine()
                                             .Split()
                                             .ToArray();
                string command = commandArgs[0];
                string vehicleType = commandArgs[1];

                if (command == "Drive")
                {
                    double distance = double.Parse(commandArgs[2]);

                    if (vehicleType == "Car")
                    {

                        Console.WriteLine(car.Drive(distance));
                    }

                    else if(vehicleType == "Truck")
                    {
                        Console.WriteLine(truck.Drive(distance));
                    }

                    else
                    {
                        Console.WriteLine(bus.Drive(distance));
                    }
                }

                else if (command == "Refuel")
                {
                    double fuelAmount = double.Parse(commandArgs[2]);

                    try
                    {
                        if (vehicleType == "Car")
                        {

                            car.Refuel(fuelAmount);
                        }

                        else if (vehicleType == "Truck")
                        {
                            truck.Refuel(fuelAmount);
                        }

                        else
                        {
                            bus.Refuel(fuelAmount);
                        }
                    }
                    catch (Exception ex)
                    {

                        Console.WriteLine(ex.Message);
                    }
                }

                else
                {
                    double distance = double.Parse(commandArgs[2]);
                    Console.WriteLine(bus.DriveEmpty(distance));
                }
            }

            Console.WriteLine(car);
            Console.WriteLine(truck);
            Console.WriteLine(bus);

        }
    }
}

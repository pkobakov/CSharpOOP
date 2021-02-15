using RobotService.Models.Robots.Contracts;
using RobotService.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace RobotService.Models.Robots
{
    public abstract class Robot : IRobot // The Robot is a base class for any robot and it should not be able to be instantiated.
    {
        //take a look at the interface class!!!!!!!!!!!!!!!

        private const int MinValue = 0;
        private const int MaxValue = 100;
        private const string defaultOwnerName = "Service";
        private int happiness;
        private int energy;

        public Robot(string name, int energy, int happiness, int procedureTime)
        {
            Name = name;
            Energy = energy;
            Happiness = happiness;
            ProcedureTime = procedureTime;
            Owner = defaultOwnerName;

        }
        public string Name { get; }
        public int Happiness 
        { 
            get => happiness; 
            set
            {
                if (value<MinValue||value>MaxValue)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidHappiness);
                }
                happiness = value;
            } 
        }
        public int Energy 
        {
            get => energy;
            set 
            {
                if (value < MinValue || value > MaxValue)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidEnergy);
                }
                energy = value;
            }
        }
        public int ProcedureTime { get; set; }
        public string Owner { get; set; }
        public bool IsBought { get; set; }
        public bool IsChipped { get; set; }
        public bool IsChecked { get; set; }


        public override string ToString()
        {
            return $" Robot type: {GetType().Name} - {Name} - Happiness: {Happiness} - Energy: {Energy}";
        }

    }
}

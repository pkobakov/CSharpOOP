using RobotService.Core.Contracts;
using RobotService.Models.Garages;
using RobotService.Models.Garages.Contracts;
using RobotService.Models.Procedures;
using RobotService.Models.Procedures.Contracts;
using RobotService.Models.Robots;
using RobotService.Models.Robots.Contracts;
using RobotService.Utilities.Enums;
using RobotService.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;


namespace RobotService.Core
{
    public class Controller : IController
    {
        //For each command except for "Manufacture" and "History", 
        //you must check if a robot with that name exist in the garage.
        //If it doesn't, throw an ArgumentException with the message
        //"Robot {robot name} does not exist". 

        private readonly Dictionary<ProcedureType, IProcedure> procedures;
        private readonly IGarage garage;
        private IRobot currentRobot ;
        private IProcedure currentProcedure;
        public Controller()
        {
            garage = new Garage();
            procedures = new Dictionary<ProcedureType, IProcedure>();
            ProceduresList();
            
        }
        
        public string Charge(string robotName, int procedureTime)
        {
            if (!garage.Robots.ContainsKey(robotName))
            {
                string exceptionMsg = String.Format(ExceptionMessages.InexistingRobot, robotName);
                return exceptionMsg;
            }

            currentRobot = garage.Robots[robotName];
            currentProcedure = procedures[ProcedureType.Charge];
            currentProcedure.DoService(currentRobot, procedureTime);
            string OutMsg = string.Format(OutputMessages.ChargeProcedure, robotName);
            return OutMsg;

        }

        public string Chip(string robotName, int procedureTime)
        {
            if (!garage.Robots.ContainsKey(robotName))
            {

                string excMsg = string.Format(ExceptionMessages.InexistingRobot, robotName);
                return excMsg;
            }

            currentRobot = garage.Robots[robotName];
            currentProcedure = procedures[ProcedureType.Chip];
            currentProcedure.DoService(currentRobot,procedureTime);

            string OutMsg = string.Format(OutputMessages.ChipProcedure, robotName);
            return OutMsg;
        }

        public string History(string procedureType)
        {
           Enum.TryParse(procedureType, out ProcedureType procedureTypeEnum);
           return procedures[procedureTypeEnum].History();

        }

        public string Manufacture(string currentRobotType, string name, int energy, int happiness, int procedureTime)
        {
            if (!Enum.TryParse(currentRobotType, out RobotType robotType))
            {
                string exception = string.Format(ExceptionMessages.InvalidRobotType, currentRobotType);
                return exception;
            }

            currentRobot = currentRobotType switch
            {
                nameof(RobotType.HouseholdRobot)=>(IRobot) new HouseholdRobot(name, energy, happiness, procedureTime),
                nameof(RobotType.PetRobot) => new PetRobot(name, energy,happiness,procedureTime),
                nameof(RobotType.WalkerRobot) => new WalkerRobot(name, energy, happiness, procedureTime),
                
            };

            garage.Manufacture(currentRobot);
            string msg = string.Format(OutputMessages.RobotManufactured, name);
            return msg;


        }

        public string Polish(string robotName, int procedureTime)
        {
            if (!garage.Robots.ContainsKey(robotName))
            {
                string exceptionMsg = String.Format(ExceptionMessages.InexistingRobot, robotName);
                return exceptionMsg;
            }

            currentRobot = garage.Robots[robotName];
            currentProcedure = procedures[ProcedureType.Polish];
            currentProcedure.DoService(currentRobot, procedureTime);
            string OutMsg = string.Format(OutputMessages.PolishProcedure, robotName);
            return OutMsg;
        }

        public string Rest(string robotName, int procedureTime)
        {
            if (!garage.Robots.ContainsKey(robotName))
            {

                string excMsg = string.Format(ExceptionMessages.InexistingRobot, robotName);
                return excMsg;
            }

            currentRobot = garage.Robots[robotName];
            currentProcedure = procedures[ProcedureType.Rest];
            currentProcedure.DoService(currentRobot, procedureTime);

            string OutMsg = string.Format(OutputMessages.RestProcedure, robotName);
            return OutMsg;
        }

        public string Sell(string robotName, string ownerName)
        {
            if (!garage.Robots.ContainsKey(robotName))
            {

                string msg = string.Format(ExceptionMessages.InexistingRobot, robotName);
            }

            currentRobot = garage.Robots[robotName];
            garage.Sell(robotName, ownerName);

            if (currentRobot.IsChipped)
            {
                return string.Format(OutputMessages.SellChippedRobot, ownerName);
            }

            else 
            {
                return string.Format(OutputMessages.SellNotChippedRobot, ownerName);
            }
            
           
        }

        public string TechCheck(string robotName, int procedureTime)
        {
            if (!garage.Robots.ContainsKey(robotName))
            {

                string excMsg = string.Format(ExceptionMessages.InexistingRobot, robotName);
                return excMsg;
            }

            currentRobot = garage.Robots[robotName];
            currentProcedure = procedures[ProcedureType.TechCheck];
            currentProcedure.DoService(currentRobot, procedureTime);

            string OutMsg = string.Format(OutputMessages.TechCheckProcedure, robotName);
            return OutMsg;
        }

        public string Work(string robotName, int procedureTime)
        {
            if (!garage.Robots.ContainsKey(robotName))
            {

                string exceptionMsg = string.Format(ExceptionMessages.InexistingRobot, robotName);
            }
            currentRobot = garage.Robots[robotName];
            currentProcedure = procedures[ProcedureType.Work];
            currentProcedure.DoService(currentRobot,procedureTime);

            string outputMsg = string.Format(OutputMessages.WorkProcedure, robotName, procedureTime);
            return outputMsg;
        }


        private void ProceduresList() 
        {

            procedures.Add(ProcedureType.Charge, new Charge());
            procedures.Add(ProcedureType.Chip, new Chip());
            procedures.Add(ProcedureType.Polish, new Polish());
            procedures.Add(ProcedureType.Rest, new Rest());
            procedures.Add(ProcedureType.TechCheck, new TechCheck());
            procedures.Add(ProcedureType.Work, new Work());
        }
    }
}

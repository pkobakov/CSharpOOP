using RobotService.Models.Garages.Contracts;
using RobotService.Models.Robots.Contracts;
using RobotService.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RobotService.Models.Garages
{
    public class Garage : IGarage
    {
        private readonly Dictionary<string, IRobot> robots;
        private const int capacity = 10;
        public Garage()
        {
            robots = new Dictionary<string, IRobot>();
        }

        public IReadOnlyDictionary<string, IRobot> Robots 
        {
            get => robots;
                
        }

        public void Manufacture(IRobot robot)
        {
            if (robots.ContainsKey(robot.Name))
            {
                throw new ArgumentException(ExceptionMessages.ExistingRobot, robot.Name);
            }
            
            if (robots.Count == capacity)
            {
                throw new ArgumentException(ExceptionMessages.NotEnoughCapacity);
            }

            robots.Add(robot.Name,robot);
        }

        public void Sell(string robotName, string ownerName)
        {
            //If a robot with that name exists, change its owner, its bought status and remove the robot from the garage.
            if (!robots.ContainsKey(robotName))
            {
                string msg = string.Format(ExceptionMessages.InexistingRobot, robotName);
                throw new ArgumentException(msg);
            }

            IRobot robot = robots[robotName];
            robot.Owner = ownerName;
            robot.IsBought = true;
            robots.Remove(robot.Name);
        }
    }
}

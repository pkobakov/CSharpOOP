using RobotService.Models.Robots.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace RobotService.Models.Procedures
{
    public class TechCheck:Procedure
    {
        public override void DoService(IRobot robot, int procedureTime)
        {
            base.DoService(robot, procedureTime);

            //removes 8 energy and checks current robot (set IsChecked to true). 
            //If robot is already checked, just remove 8 energy again.
            robot.ProcedureTime -= procedureTime;
            robot.IsChecked = true;
            robot.Energy -= 8;
               
            
        }
    }
}

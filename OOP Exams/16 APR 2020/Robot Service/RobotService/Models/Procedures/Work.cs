using RobotService.Models.Robots.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace RobotService.Models.Procedures
{
    public class Work:Procedure
    {
        public override void DoService(IRobot robot, int procedureTime)
        {
            base.DoService(robot, procedureTime);

            //removes 6 energy and adds 12 happiness

            robot.ProcedureTime -= procedureTime;
            robot.Happiness += 12;
            robot.Energy -= 6;
            

        }
    }
}

using RobotService.Models.Procedures.Contracts;
using RobotService.Models.Robots.Contracts;
using RobotService.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace RobotService.Models.Procedures
{
   public abstract class Procedure : IProcedure //The Procedure is a base class for any procedures and it should not be able to be instantiated.
    {
        protected IList<IRobot> robots { get; }

        // Collection of Robots accessible only by the child classes. 
        // Collection should contains all robots which has visited specific procedure.
        protected Procedure()
        {
            robots = new List<IRobot>(); 
        }

        //Each procedure implements its own DoService() method with different logic.
        public virtual void DoService(IRobot robot, int procedureTime)
        {
            //Each procedure must check if the robot procedure time is more than or equal to the time each procedure will take.  

            if (robot.ProcedureTime<procedureTime)
            {
                string msg = string.Format(ExceptionMessages.InsufficientProcedureTime);
                throw new ArgumentException(msg);
            }

            robots.Add(robot);
        }

        public string History() 
        {

            StringBuilder sb = new StringBuilder();

            sb.AppendLine(GetType().Name);

            foreach (IRobot robot in robots)
            {
                sb.AppendLine(robot.ToString());
            }

            return sb.ToString().Trim();
        }
   }
}

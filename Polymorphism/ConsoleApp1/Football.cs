using System;
using System.Collections.Generic;
using System.Text;

namespace Demo
{
   public  class Football:Game
    {
        private List<Player> team;

        public Football()
        {
            team = new List<Player>();
        }

        public override void Start()
        {
            base.Start();
            Console.WriteLine("The game begins");
        }

        public override void Stop()
        {
            base.Stop();
            Console.WriteLine($"And the winner is {team}");
        }

        public override string GetDescription()
        {
            return $"The team got mad and starts fighting !?@#$!";
        }

    }
}

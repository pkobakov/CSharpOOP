using CounterStrike.Models.Guns.Contracts;
using CounterStrike.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace CounterStrike.Models.Guns
{
    public abstract class Gun : IGun
    {
        private string name;
        private int bulletsCount;

        public Gun(string name, int bulletsCount)
        {
            this.Name = name;
            this.BulletsCount = bulletsCount;
        }


        public string Name 
        { 
            get => name;
            private set 
            {
                if (string.IsNullOrEmpty(value))
                {
                    string msg = String.Format(ExceptionMessages.InvalidGunName);
                    throw new ArgumentException(msg);
                }

                name = value;
            }
        
        }

        public int BulletsCount 
        {

            get => bulletsCount;
            protected set 
            {
                if (value<0)
                {
                    string msg = String.Format(ExceptionMessages.InvalidGunBulletsCount);
                    throw new ArgumentException(msg);
                }

                bulletsCount = value;
            }
        
        }

        public abstract int Fire();
      
    }
}

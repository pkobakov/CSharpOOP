using CounterStrike.Models.Guns;
using System;
using System.Collections.Generic;
using System.Text;

namespace CounterStrike.Models
{
    public class Pistol : Gun
    {
        private int bulletsFired = 1;
        public Pistol(string name, int bulletsCount):base(name, bulletsCount)
        {
          
        }
        public override int Fire()
        {
            if (BulletsCount-bulletsFired>=0)
            {
                return bulletsFired; //how many bullets you have after shooting
            }

            return 0;

        }
    }
}

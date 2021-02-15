using System;
using System.Collections.Generic;
using System.Text;

namespace CounterStrike.Models.Guns
{
    public class Rifle : Gun
    {
        private  int bulletsFired = 10;
        public Rifle(string name, int bulletsCount):base(name, bulletsCount)
        {

        }
        public override int Fire()
        {
            if (BulletsCount - bulletsFired >= 0)
            {
                return bulletsFired;
            }

            else
            {
                int restedBullets = BulletsCount;
                BulletsCount = 0;
                return restedBullets;
            }
        }
    }
}

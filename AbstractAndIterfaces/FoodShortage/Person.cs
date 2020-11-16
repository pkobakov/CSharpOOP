using System;
using System.Collections.Generic;
using System.Text;

namespace FoodShortage
{
    public abstract class Person : IBuyer
    {
        private int food;

        public string Name { get; set; }
        public int Food { get; set; }

        public abstract void BuyFood();



    }
}

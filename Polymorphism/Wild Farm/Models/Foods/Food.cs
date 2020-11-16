using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm.Models.Foods
{
    public abstract class Food
    {
        public int Quantity { get; private set; }
        protected Food(int quantity)
        {
            this.Quantity = quantity;  
        }
    }
}

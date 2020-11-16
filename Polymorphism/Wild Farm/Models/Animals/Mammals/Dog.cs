using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Models.Foods;

namespace WildFarm.Models.Animals.Mammals
{
    public class Dog:Mammal
    { 
        private double GainValue = 0.40;
        public Dog(string name, double weight, string livingRegion):base(name, weight,livingRegion)
        {

        }

        public override void Feed(Food food)
        {
            this.BaseFeed(food, new List<string>(){nameof(Meat)}, GainValue);
        }
        public override string ProduceSound()
        {
            return "Woof!";
        }
    }
}

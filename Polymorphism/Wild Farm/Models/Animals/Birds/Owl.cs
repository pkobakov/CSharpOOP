using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Models.Foods;

namespace WildFarm.Models.Animals.Birds
{
    class Owl:Bird
    {
        private const double GainValue = 0.25;
        public Owl(string name, double weight, double wingSize)
            :base(name, weight, wingSize)
        {

        }
        public override void Feed(Food food)
        {
            this.BaseFeed(food, new List<string>() { nameof(Meat) }, GainValue);
        }
        public override string ProduceSound()
        {
            return "Hoot Hoot";
        }

    }
}

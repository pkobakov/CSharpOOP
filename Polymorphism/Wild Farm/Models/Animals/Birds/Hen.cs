using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Models.Foods;

namespace WildFarm.Models.Animals.Birds
{
    public class Hen:Bird
    {
        private const double GainValue = 0.35;
        public Hen (string name, double weight, double wingSize)
            : base(name, weight, wingSize)
        {

        }
        public override void Feed(Food food)
        {
            this.BaseFeed(food, new List<string>() {nameof(food) }, GainValue);
        }
        public override string ProduceSound()
        {
            return "Cluck";
        }
    }

    
}

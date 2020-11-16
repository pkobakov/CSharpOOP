using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Models.Foods;

namespace WildFarm.Models.Animals
{
    public abstract class Animal
    {
        //string Name
        //double Weight
        //string FoodEaten

        public string Name{ get; protected set; }
        public double Weight { get; protected set; }
        public int FoodEaten { get; protected set; }

        protected Animal(string name, double weight)
        {
            this.Name = name;
            this.Weight = weight;
            this.FoodEaten = 0;
        }

        public abstract string ProduceSound();
        public abstract void Feed(Food food);
        public  void BaseFeed(Food food, List<string>foodEaten, double gainValue)
        {
            string foodType = food.GetType().Name;

            if (!foodEaten.Contains(foodType))
            {
                throw new Exception($"{GetType().Name} does not eat {foodType}!");
                
            }

            this.Weight += food.Quantity * gainValue;
            this.FoodEaten = food.Quantity;
        }

        public override string ToString()
        {
            return $"{GetType().Name} [{this.Name},";
        }
    }
}

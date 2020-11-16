using System;
using System.Collections.Generic;
using WildFarm.Models.Animals;
using WildFarm.Models.Foods;

namespace WildFarm
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            List<Animal> animals = new List<Animal>();

            while (input != "End")
            {
                string[] animalArgs = input.Split();
                Animal animal = AnimalFactory.CreateAnimalCollection(animalArgs);

                string[] foodArgs = Console.ReadLine().Split();
                Food food = FoodFactory.CreateFoodCollection(foodArgs);

                Console.WriteLine(animal.ProduceSound());

                try
                {
                    animal.Feed(food);
                }
                catch (Exception ae)
                {

                  Console.WriteLine(ae.Message);
                }

                animals.Add(animal); 
                input = Console.ReadLine();
            }

            foreach (var animal  in animals)
            {
                Console.WriteLine(animal);
            }
        }
    }
}

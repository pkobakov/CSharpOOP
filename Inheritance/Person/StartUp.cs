using System;

namespace Person
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            
            string name = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());

            Person person = new Child (name, age);
            Console.WriteLine(person.ToString());
        }
    }
}

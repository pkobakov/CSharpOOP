using System;
using System.Linq;
using Telephony.Models;

namespace Telephony
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string[] numbers = Console.ReadLine().Split().ToArray();
            string[] urls = Console.ReadLine().Split().ToArray();

            Stationaryphone statphone = new Stationaryphone();
            Smartphone smartphone = new Smartphone();

            foreach (var number in numbers)
            {

                try
                {
                    if (number.Length == 7)
                    {
                        Console.WriteLine(statphone.Call(number));
                    }
                    else if (number.Length == 10)
                    {
                        Console.WriteLine(smartphone.Call(number));
                    }

                    else
                    {
                        throw new Exception("Invalid number!");
                    }
                }
                catch (Exception ae)
                {

                    Console.WriteLine(ae.Message);
                }
            }

            foreach (var url in urls)
            {
                try
                {
                    Console.WriteLine(smartphone.Browse(url));
                }
                catch (Exception ae)
                {

                    Console.WriteLine(ae.Message);
                }
                
                
            }


        }
    }
}

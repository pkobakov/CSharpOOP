using System;

namespace Demo
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Magazine magazine = new Magazine();
            magazine.AddGame(new Football());
            magazine.AddGame(new Chess(new Player("Karpov"), new Player("Kasparov")));

            magazine.PrintDescriptions();

          

        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Demo
{
    class Magazine
    {
        private List<Game> magazine;
        public Magazine()
        {
            magazine = new List<Game>();
        }

        public void AddGame(Game game) { magazine.Add(game); }
        public void StopGames()
        {
            foreach (var game in magazine)
            {
                game.Stop();
            }
        }

        public void PrintDescriptions() 
        {
            foreach (var game in magazine)
            {
                Console.WriteLine(game.GetDescription()); 
            }
        }
    }
}

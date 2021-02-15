using System;
using System.Collections.Generic;
using System.Text;

namespace PlayersAndMonsters.Models.Cards
{
    public class MagicCard:Card
    {
        private const int magicCardDamagePoints = 5;
        private const int magicCardHealthPoints = 80;
        public MagicCard(string name) : base(name, magicCardDamagePoints, magicCardHealthPoints)
        {

        }
    }
}

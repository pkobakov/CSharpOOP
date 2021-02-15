using PlayersAndMonsters.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlayersAndMonsters.Models.Players
{
    public class Advanced:Player
    {
        private const int advancedHealth = 250;
        public Advanced(ICardRepository CardRepository, string username)
            :base (CardRepository, username, advancedHealth)
        {

        }
    }
}

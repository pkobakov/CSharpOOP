using PlayersAndMonsters.Common.Enums;
using PlayersAndMonsters.Core.Factories.Contracts;
using PlayersAndMonsters.Models.Players;
using PlayersAndMonsters.Models.Players.Contracts;
using PlayersAndMonsters.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlayersAndMonsters.Core.Factories
{
    public class PlayerFactory : IPlayerFactory
    {
        public IPlayer CreatePlayer(string type, string username)
        {
            IPlayer player = null;

            if (type == nameof(PlayerType.Beginner))
            {
                player = new Beginner(new CardRepository(), username);
            }

            else if (type == nameof(PlayerType.Advanced))
            {
                player = new Advanced(new CardRepository(), username);
            }

            return player;
        }
    }
}

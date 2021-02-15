namespace PlayersAndMonsters.Core
{
    using System;
    using System.Linq;
    using System.Text;
    using Contracts;
    using PlayersAndMonsters.Common;
    using PlayersAndMonsters.Common.Enums;
    using PlayersAndMonsters.Core.Factories;
    using PlayersAndMonsters.Core.Factories.Contracts;
    using PlayersAndMonsters.Models.BattleFields;
    using PlayersAndMonsters.Models.Cards;
    using PlayersAndMonsters.Models.Cards.Contracts;
    using PlayersAndMonsters.Models.Players;
    using PlayersAndMonsters.Models.Players.Contracts;
    using PlayersAndMonsters.Repositories;
    using PlayersAndMonsters.Repositories.Contracts;
   


    public class ManagerController : IManagerController
    {
        private IPlayerRepository players;
        private ICardRepository cards;
        private CardFactory cardFactory;
        private PlayerFactory playerFactory;
        private BattleField battleField;
        public ManagerController()
        {
            players = new PlayerRepository();
            cards = new CardRepository();
            cardFactory = new CardFactory();
            playerFactory = new PlayerFactory();
            battleField = new BattleField();
        }

        public string AddPlayer(string type, string username)
        {
            var player = playerFactory.CreatePlayer(type, username);

            players.Add(player);
            string message = String.Format(ConstantMessages.SuccessfullyAddedPlayer, type, username);
            return message;
        }

        public string AddCard(string type, string name)
        {
           var card = cardFactory.CreateCard(type, name);
            cards.Add(card);
            string message = String.Format(ConstantMessages.SuccessfullyAddedCard, type, name);
            return message;
        }

        public string AddPlayerCard(string username, string cardName)
        {
            var player = players.Players.FirstOrDefault(p => p.Username == username);
            var card = cards.Cards.FirstOrDefault(c => c.Name == cardName);

            player.CardRepository.Add(card);


            return $"Successfully added card: {cardName} to user: {username}";
        }

        public string Fight(string attackUser, string enemyUser)
        {
            var attacker = players.Players.FirstOrDefault(a => a.Username == attackUser);
            var enemy = players.Players.FirstOrDefault(e => e.Username == enemyUser);

            battleField.Fight(attacker, enemy);
            return $"Attack user health {attacker.Health} - Enemy user health {enemy.Health}";
        }

        public string Report()
        {

            StringBuilder sb = new StringBuilder();
            foreach (var player in players.Players)
            {
                sb.AppendLine($"Username: {player.Username} - Health: {player.Health} – Cards: {player.CardRepository.Cards.Count}");

                foreach (var card in player.CardRepository.Cards)
                {
                    sb.AppendLine($"Card: {card.Name} - Damage: {card.DamagePoints}");
                }

                sb.AppendLine(ConstantMessages.DefaultReportSeparator );
            }
            


            return sb.ToString().Trim();

        }
    }
}

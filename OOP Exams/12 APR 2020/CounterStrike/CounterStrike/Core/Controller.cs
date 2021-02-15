using CounterStrike.Core.Contracts;
using CounterStrike.Models;
using CounterStrike.Models.Guns;
using CounterStrike.Models.Guns.Contracts;
using CounterStrike.Models.Maps;
using CounterStrike.Models.Maps.Contracts;
using CounterStrike.Models.Players;
using CounterStrike.Models.Players.Contracts;
using CounterStrike.Repositories;
using CounterStrike.Utilities.Enums;
using CounterStrike.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CounterStrike.Core
{
    public class Controller : IController
    {
        private GunRepository gunsRepository;
        private PlayerRepository playersRepository;
        private IMap map;

        public Controller()
        {
            gunsRepository = new GunRepository();
            playersRepository = new PlayerRepository();
            map = new Map();

        }

        public string AddGun(string type, string name, int bulletsCount)
        {
            IGun gun;

            if (type == nameof(GunTypes.Pistol))
            {
                gun = new Pistol (name, bulletsCount);
            }

            else if (type == nameof(GunTypes.Rifle))
            {
                gun = new Rifle(name, bulletsCount);
            }

            else
            {
                string exception = String.Format(ExceptionMessages.InvalidGunType);
                throw new ArgumentException(exception);
                
            }

            gunsRepository.Add(gun);

            return String.Format(OutputMessages.SuccessfullyAddedGun, name);
        }

        public string AddPlayer(string type, string username, int health, int armor, string gunName)
        {
            IGun gun = gunsRepository.FindByName(gunName);
            if (gun == null)
            {
                string exception = String.Format(ExceptionMessages.GunCannotBeFound);
            }

            IPlayer player;

            if (type == nameof(PlayersTypes.Terrorist))
            {

                player = new Terrorist(username, health, armor, gun);
            }

            else if (type == nameof(PlayersTypes.CounterTerrorist))
            {
                player = new CounterTerrorist(username, health, armor, gun);
            }

            else
            {
                string exception = String.Format(ExceptionMessages.InvalidPlayerType);
                throw new ArgumentException(exception);
            }

            playersRepository.Add(player);
            string outputMessage = String.Format(OutputMessages.SuccessfullyAddedPlayer, username );
            return outputMessage;

        }

        public string Report()
        {
            var sortedRepo = playersRepository.Models
                                              .OrderBy(p => p.GetType().Name)
                                              .ThenByDescending(p => p.Health)
                                              .ThenBy(p => p.Username);
            StringBuilder sb = new StringBuilder();

            foreach (IPlayer player in sortedRepo)
            {
                sb.Append(player);
            }

            return sb.ToString().Trim();
        }

        public string StartGame()
        {
           return  map.Start(playersRepository.Models.ToList()); 
        }
    }
}

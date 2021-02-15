using CounterStrike.Models.Maps.Contracts;
using CounterStrike.Models.Players.Contracts;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using CounterStrike.Models.Players;

namespace CounterStrike.Models.Maps
{
    public class Map : IMap
    {

        private List<IPlayer> terrorists;
        private List<IPlayer> counterTerrorists;

        public Map()
        {
            terrorists = new List<IPlayer>();
            counterTerrorists = new List<IPlayer>();
        }


        public string Start(ICollection<IPlayer> players)
        {
            SeparateTeams(players);

            while (isTeamAlive(terrorists)&&isTeamAlive(counterTerrorists))
            {
                Attack(terrorists, counterTerrorists);
                Attack(counterTerrorists, terrorists);
            }

            if (!isTeamAlive(counterTerrorists))
            {
                return "Terrorist wins!";
            }

            return "Counter Terrorist wins!";



        }

        private void SeparateTeams(ICollection<IPlayer> players)
        {
            foreach (var player in players)
            {
                if (player.GetType().Name == nameof(Terrorist))
                {
                    terrorists.Add(player);
                }

                else if (player.GetType().Name == nameof(CounterTerrorist))
                {
                    counterTerrorists.Add(player);
                }
            }
        }

        public bool isTeamAlive(ICollection<IPlayer> players) 
        {

            return players.Any(p=>p.IsAlive);
        
        }

        public void Attack(List<IPlayer> attackingTeam, List<IPlayer> deffendingTeam) 
        {
            foreach (var attackingPlayer in attackingTeam)
            {
                if (attackingPlayer.IsAlive) continue;

                foreach (var deffendingPlayer in deffendingTeam)
                {
                    if (deffendingPlayer.IsAlive)
                    {
                        deffendingPlayer.TakeDamage(attackingPlayer.Gun.Fire());
                    }
                }
            }
        
        }
    }
}
    
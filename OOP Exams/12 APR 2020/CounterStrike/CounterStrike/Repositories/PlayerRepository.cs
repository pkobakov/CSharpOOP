using CounterStrike.Models.Players.Contracts;
using CounterStrike.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CounterStrike.Repositories
{
    public class PlayerRepository : IRepository<IPlayer>
    {
        private List<IPlayer> models;

        public PlayerRepository()
        {
            models = new List<IPlayer>();
        }
        public IReadOnlyCollection<IPlayer> Models
        {
            get { return models.AsReadOnly(); }
        }

        public void Add(IPlayer model)
        {
            //If the gun is null, throw an ArgumentException with message: "Cannot add null in Gun Repository".
            //Adds a gun in the collection.

            if (model == null)
            {
                string msg = String.Format("Cannot add null in Gun Repository");
                throw new ArgumentException(msg);
            }

            models.Add(model);
        }

        public IPlayer FindByName(string name)
        {
            var player = models.FirstOrDefault(p => p.Username == name);
            return player;
        }

        public bool Remove(IPlayer model)
        {
            return models.Remove(model);
        }
    }
}


using CounterStrike.Models.Guns.Contracts;
using CounterStrike.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CounterStrike.Repositories
{
    public class GunRepository : IRepository<IGun>
    {
        private List<IGun> models;

        public GunRepository()
        {
            models = new List<IGun>();
        }
        public IReadOnlyCollection<IGun> Models 
        {
            get { return models.AsReadOnly(); } 
        }

        public void Add(IGun model)
        {
            //If the gun is null, throw an ArgumentException with message: "Cannot add null in Gun Repository".
            //Adds a gun in the collection.

            if (model == null )
            {
                string msg = String.Format("Cannot add null in Gun Repository");
                throw new ArgumentException(msg);
            }

            models.Add(model);
        }

        public IGun FindByName(string name)
        {
            var gun = models.FirstOrDefault(g => g.Name == name);
            return gun;
        }

        public bool Remove(IGun model)
        {
            return models.Remove(model);
        }
    }
}

using EasterRaces.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;


namespace EasterRaces.Repositories.Entities
{
    public abstract class Repository<T> : IRepository<T>
    {
        private List<T> models;

        public Repository()
        {
            models = new List<T>();  
        }
        public void Add(T model)
        {
            models.Add(model);
        }

        public IReadOnlyCollection<T> GetAll()
        {
            return models.AsReadOnly();
        }

        public T GetByName(string name)
        {
            return models.FirstOrDefault(m => nameof(m) == name);
        }

        public bool Remove(T model)
        {
            if (models.Contains(model))
            {
                models.Remove(model);
                return true;
            }

            return false;
        }
    }
}
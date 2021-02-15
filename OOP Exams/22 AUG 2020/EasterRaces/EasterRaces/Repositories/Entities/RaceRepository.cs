using EasterRaces.Models.Races.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasterRaces.Repositories.Entities
{
    class RaceRepository: Repository<IRace>
    {
        private readonly List<IRace> cars;
        public RaceRepository()
        {
            cars = new List<IRace>();
        }
    }
    
}

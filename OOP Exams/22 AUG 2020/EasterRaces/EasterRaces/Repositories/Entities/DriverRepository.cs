using EasterRaces.Models.Drivers.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasterRaces.Repositories.Entities
{
    class DriverRepository: Repository<IDriver>
    {
        private readonly List<IDriver> cars;
        public DriverRepository()
        {
            cars = new List<IDriver>();
        }
    }
}

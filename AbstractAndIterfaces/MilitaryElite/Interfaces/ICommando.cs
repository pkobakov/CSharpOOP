using MilitaryElite.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.Interfaces
{
    public interface ICommando
    {
        ICollection<Mission> Missions { get; }
    }
}

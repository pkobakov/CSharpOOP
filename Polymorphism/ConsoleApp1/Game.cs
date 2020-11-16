using System;
using System.Collections.Generic;
using System.Text;

namespace Demo
{
    public abstract class Game
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public virtual void Start() //методите в абстрактните класове трябва да са virtual, ако ще се ovveride;
        {
            StartDate = DateTime.Now;

        }

        public virtual void Stop()
        {
            EndDate = DateTime.Now;
        }
        public abstract string GetDescription();
        

    }
}

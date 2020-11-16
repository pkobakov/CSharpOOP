using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Zoo
{
    public class Gorilla : Mammal
    {
        public Gorilla(string name):base(name)
        {
            this.Name = name;
        }
    }
}

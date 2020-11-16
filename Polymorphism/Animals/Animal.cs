using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    public  class Animal
    {
 


        public string Name{ get; protected set; }
        public string Food { get; protected set; }

        public Animal(string name, string food)
        {
            this.Name = name;
            this.Food = food;
        }

        public virtual string ExplainSelf() 
        {
            return $"I'm {this.Name} and my favotite food is {this.Food}";
        }
       
    }
}

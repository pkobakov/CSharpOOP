using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Person
{
    public class Child : Person
    {
        public string Name { get; set; }
        public override int Age
        {
            get { return this.Age; }

            set
            {
                if (value < 15)
                {
                    throw new ArgumentException("Age must be less than 15");

                }
                base.Age = value;
            }
            
        }

        public Child(string name, int age) :base( name,age)
        {
            this.Name = name;
            this.Age = age;
        }
    }
}

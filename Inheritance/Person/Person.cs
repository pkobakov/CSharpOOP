using System;
using System.Collections.Generic;
using System.Text;



namespace Person
{
    public class Person
    {
        public  string Name { get; set; }
        public virtual int Age 
        {
            get 
            {
                
                return this.Age; 
            } 
            set 
            {
                if (value<0)
                {

                    throw new ArgumentException("Age must be positive");
                }
              
            } 
        }

        public Person(string name, int age)
        {
           this.Name = name;
            this.Age = age;
        }

        public override string ToString()
        {
            StringBuilder printPerson = new StringBuilder();
            printPerson.AppendLine($"Name: {Name}, Age: {Age}");

            return printPerson.ToString().Trim();
        }
    }
}

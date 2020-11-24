using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using ValidationAttributes;

namespace ValidationAttributes
{
    public class Person
    {
        

        [MyRangeAttribute(12,90)]
        public int Age { get; set; }

        [MyRequired]
        public string FullName { get; set; }

        public Person(string fullName,int age )
        {
            this.FullName = fullName;
            this.Age = age;

        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Schema;

namespace Cars
{
    public interface ICar
    {
        public string Model { get;}
        public string  Color { get;}


        public string Start();
        public string Stop();

    }
}

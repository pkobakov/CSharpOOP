using System;
using System.Collections.Generic;
using System.Text;

namespace P02.Graphic_Editor
{
    public class Rectangle : IShape
    {
        public string Shape { get; set; }

        public Rectangle(string shape)
        {
            this.Shape = shape;
        }
    }
}

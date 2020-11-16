using System;
using System.Collections.Generic;
using System.Text;

namespace P02.Graphic_Editor
{
    public class Square : IShape
    {
        public string Shape { get; set; }

        public Square(string shape)
        {
            this.Shape = shape;
        }
    }
}

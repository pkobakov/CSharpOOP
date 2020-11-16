using System;
using System.Collections.Generic;
using System.Text;

namespace P02.Graphic_Editor
{
    public class Circle : IShape
    {
        public string Shape { get; set; }

        public Circle (string shape)
        {
            this.Shape = shape;
        }
    }
}

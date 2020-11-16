using System;

namespace P02.Graphic_Editor
{
    class Program
    {
        static void Main()
        {


            Rectangle rectangle = new Rectangle("This is a rectangle");
            GraphicEditor rectDraw = new GraphicEditor();
            rectDraw.DrawShape(rectangle);

            Square square = new Square ("This is a square");
            GraphicEditor sqDraw = new GraphicEditor();
            sqDraw.DrawShape(square);

            Circle circle = new Circle("This is a circle.");
            GraphicEditor circlDraw = new GraphicEditor();
            circlDraw.DrawShape(circle);




        }
    }
}

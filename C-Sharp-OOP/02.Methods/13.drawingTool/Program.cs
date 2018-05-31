using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CordDraw;

public abstract class Shape
{
    public abstract void Draw();
}
public class CordDraw
{
    public CordDraw(Shape shape)
    {
        this.Draw(shape);
    }

    public void Draw(Shape shape)
    {
        shape.Draw();
    }
    public class Rectangle : Shape
    {
        private int width;
        private int heigth;

        public Rectangle(int width, int heigth)
        {
            this.width = width;
            this.heigth = heigth;
        }

        public override void Draw()
        {
            Console.WriteLine($"|{new string('-', this.width)}|");
            for (int i = 0; i < this.heigth - 2; i++)
            {
                Console.WriteLine($"|{new string(' ', this.width)}|");
            }
            Console.WriteLine($"|{new string('-', this.width)}|");
        }
    }
    public class Square : Shape
    {
        public int side;

        public Square(int side)
        {
            this.side = side;
        }

        public override void Draw()
        {
            Console.WriteLine($"|{new string('-', this.side)}|");
            for (int i = 0; i < this.side - 2; i++)
            {
                Console.WriteLine($"|{new string(' ', this.side)}|");
            }
            Console.WriteLine($"|{new string('-', this.side)}|");
        }
    }
}
public class Program
{
    public static void Main()
    {
        string figure = Console.ReadLine();
        int width = int.Parse(Console.ReadLine());
        int heigth = 0;

        if (figure == "Rectangle")
        {
            heigth = int.Parse(Console.ReadLine());
            var rectangle = new Rectangle(width, heigth);
            rectangle.Draw();
        }
        else
        {
            var square = new Square(width);
            square.Draw();
        }
    }
}
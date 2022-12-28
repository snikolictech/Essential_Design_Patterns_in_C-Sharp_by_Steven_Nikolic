using System;

namespace FactorMethodDrawObjects
{
    class Program
    {
        static void Main(string[] args)
        {
            Shape square1 = new FactoryCornered().CreateShape("square");
            square1.Draw();

            Shape oval1 = new FactoryRounded().CreateShape("oval");
            oval1.Draw();

            Shape spiral1 = new FactorySpiraled().CreateShape("spiral");
            spiral1.Draw();
        }
    }


    interface Shape
    {
        void Draw();
    }

    class Circle : Shape
    {
        public void Draw()
        {
            Console.WriteLine("Drawing a Circle...one moment please...");
        }
    }

    class Oval : Shape
    {
        public void Draw()
        {
            Console.WriteLine("Drawing an Oval...one moment please...");
        }
    }

    class Square : Shape
    {
        public void Draw()
        {
            Console.WriteLine("Drawing a Square...one moment please...");
        }
    }

    class Rectangle : Shape
    {
        public void Draw()
        {
            Console.WriteLine("Drawing a Rectangle...one moment please...");
        }
    }

    class Spiral : Shape
    {
        public void Draw()
        {
            Console.WriteLine("Drawing a Spiral...one moment please...");
        }
    }


    interface FactoryCreator
    {
        Shape CreateShape(string shapeType);
    }

    class FactoryRounded : FactoryCreator
    {
        public virtual Shape CreateShape(string shapeType)
        {
            if (shapeType == "circle")
                return new Circle();
            else if (shapeType == "oval")
                return new Oval();
            else
                throw new Exception();
        }
    }

    class FactorySpiraled : FactoryRounded
    {
        public override Shape CreateShape(string shapeType)
        {
            if (shapeType == "spiral")
                return new Spiral();

            return base.CreateShape(shapeType);
        }
    }

    class FactoryCornered
    {
        public Shape CreateShape(string shapeType)
        {
            if (shapeType == "square")
                return new Square();
            else if (shapeType == "rectangle")
                return new Rectangle();
            else
                throw new Exception();
        }
    }
}

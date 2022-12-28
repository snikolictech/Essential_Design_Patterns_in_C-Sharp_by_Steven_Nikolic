using System;

namespace Proxy
{
    class Program
    {
        static void Main()
        {
            // Create math proxy
            IMath proxy = new VectorMathProxy();
            Vector2 result = proxy.Add(new Proxy.Vector2(4, 8), new Proxy.Vector2(3, 5));

            // Do the math
            Console.WriteLine(result.X);
            Console.WriteLine(result.Y);
        }
    }

    public interface IMath
    {
        Vector2 Add(Vector2 a, Vector2 b);
    }

    class VectorMathProxy : IMath //interface that conforms this class to the "actual class of interest."
    {
        //This class acts as a proxy to the Vector2 class (the "actual class of interest" through this instance. 
        private Vector2 mathOriginal = new Vector2();

        public Vector2 Add(Vector2 a, Vector2 b)
        {
            return mathOriginal.Add(a, b);
        }
    }

    public struct Vector2 : IMath
    {
        public double X;
        public double Y;

        public Vector2(double x, double y)
        {
            X = x;
            Y = y;
        }

        public static Vector2 operator +(Vector2 a, Vector2 b)
        {
            double x = a.X + b.X;
            double y = a.Y + b.Y;

            return new Vector2(x, y);
        }

        public Vector2 Add(Vector2 a, Vector2 b)
        {
            return a + b;
        }
    }
}
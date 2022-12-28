using System;

/* A Template Method pattern is used to call a sequence of methods common to each derriving version of the class.
 * Where the classes differ are in the particular implementation details of those called methods. In this example,
 * we are running Database connection routines and using a Template "Run" method to call the same process for
 * connecting, selecting, and disconnecting from a database. The only differences are in how the Categories class
 * selects from the database versus how the Products class selects from it.
 */
  
namespace TemplateMethod
{
    class Program
    {
        static void Main()
        {
            AbstractTemp a = new ConcreteTempA();
            a.Sequence();

            Console.WriteLine();

            AbstractTemp b = new ConcreteTempB();
            b.Sequence();
        }
    }

    abstract class AbstractTemp
    {
        //The "Template Method"
        public void Sequence()
        {
            PrimitiveOperation1();
            PrimitiveOperation2();
        }

        public abstract void PrimitiveOperation1();
        public abstract void PrimitiveOperation2();
    }

    class ConcreteTempA : AbstractTemp
    {
        public override void PrimitiveOperation1()
        {
            Console.WriteLine("ConcreteTempA's PrimitiveOperation1 Method");
        }

        public override void PrimitiveOperation2()
        {
            Console.WriteLine("ConcreteTempA's PrimitiveOperation2 Method");
        }
    }

    class ConcreteTempB : AbstractTemp
    {
        public override void PrimitiveOperation1()
        {
            Console.WriteLine("ConcreteTempB's PrimitiveOperation1 Method");
        }

        public override void PrimitiveOperation2()
        {
            Console.WriteLine("ConcreteTempB's PrimitiveOperation2 Method");
        }
    }
}
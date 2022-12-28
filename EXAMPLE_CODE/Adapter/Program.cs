using System;

/* An Adapter is much like a physical adapter used to merge two 'modules' that otherwise don't 'fit' one another.
 * Just as a plug adapter has prongs in a shape that 'conform' to the intended target (outlet, in this case), we wrap
 * the adapter (through inheritence) aroudn a incompatible target class, use it's own method "language" to re-write the functionality
 * we would expect. That language is satisified by a 3rd class "Adaptee" which can be swapped out with a different funcionality, just
 * as you would when swapping a physical adapter.
 */

namespace Adapter
{
    class Program
    {
        static void Main()
        {
            // Create adapter and place a request
            Target target = new Adapter();
            target.Request();
        }
    }

    class Target
    {
        public virtual void Request()
        {
            Console.WriteLine("Called Target Request()");
        }
    }

    class Adapter : Target
    {
        private Adaptee _adaptee = new Adaptee();

        public override void Request()
        {
            // Possibly do some other work
            // and then call SpecificRequest
            _adaptee.SpecificRequest();
        }
    }

    class Adaptee
    {
        public void SpecificRequest()
        {
            Console.WriteLine("Called SpecificRequest()");
        }
    }
}
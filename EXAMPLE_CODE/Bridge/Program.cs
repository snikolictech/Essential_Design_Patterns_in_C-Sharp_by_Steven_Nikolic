using System;

/* The base premise of the Bridge pattern is to keep classes as loosely
 * coupled to eachother as possible by using abstractions of interfaces in dependency situations.
 *  
 * In a Bridge pattern we not only de-couple a client class from the class it holds a composition dependency to
 * by hiding it behind an abstract interface, but we also
 * keep the implementation details  of the client class flexible by having it call
 * the implementation details of its dependency.
 */

namespace Bridge
{
    class Program
    {
        static void Main()
        {
            BaseAbstraction Flexible = new RefinedAbstraction();

            Flexible.Implementation = new ImplementationA();
            Flexible.Operation();

            Flexible.Implementation = new ImplementationB();
            Flexible.Operation();
        }
    }

    abstract class BaseAbstraction
    {
        public AbstractImplementation Implementation;

        public virtual void Operation()
        {
            Implementation.Operation();
        }
    }

    class RefinedAbstraction : BaseAbstraction
    {
        public override void Operation()
        {
            Implementation.Operation();
        }
    }

    interface AbstractImplementation
    {
        void Operation();
    }

    class ImplementationA : AbstractImplementation
    {
        public void Operation()
        {
            Console.WriteLine("ImplementationA Operation");
        }
    }

    class ImplementationB : AbstractImplementation
    {
        public void Operation()
        {
            Console.WriteLine("ImplementationB Operation");
        }
    }
}

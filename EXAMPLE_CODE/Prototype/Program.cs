using System;

/*
 * A Prototype pattern object simply makes a clone of itself upon request.
 * This is a good pattern whenever you need to clone many objects without going though the constructor process.
 */ 

namespace Prototype
{
    class Program
    {
        static void Main()
        {
            AbstractPrototype prototype1 = new ConcretePrototype1("Product A");
            AbstractPrototype clone1 = prototype1.Clone();

            Console.WriteLine(prototype1.Name + " cloned to another " + clone1.Name);

            prototype1.SomeReferenceType.x = 5;
            clone1.SomeReferenceType.x = 9;

            Console.WriteLine(prototype1.SomeReferenceType.x);
        }
    }

    abstract class AbstractPrototype
    {
        public SomeReferenceType SomeReferenceType = new SomeReferenceType();
        public string Name;

        public AbstractPrototype(string Name)
        {
            this.Name = Name;
        }

        public abstract AbstractPrototype Clone();
    }


    class ConcretePrototype1 : AbstractPrototype
    {
        public ConcretePrototype1(string Name) : base(Name) { }

        public override AbstractPrototype Clone()
        {
            AbstractPrototype deepClone = (ConcretePrototype1)this.MemberwiseClone();
            deepClone.SomeReferenceType = new SomeReferenceType();
            return deepClone;
        }
    }

    class SomeReferenceType { public int x; }
}
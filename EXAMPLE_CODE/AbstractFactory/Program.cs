using System;


/*  The Abstract Factory design pattern is a pattern that creates related objects
 *  parallel to one another while abstracting away knowledge of the object's concrete types
 *  in the consuming class.
 */

namespace DesignPatterns
{
    class Program
    {
        public static void Main()
        {
            Client client1 = new Client(new ConcreteFactory1());
            client1.DoInteraction();
        }
    }

    //PRODUCT INTERFACES
    interface IProductA
    {
        void Interact(IProductB productB);
    }

    interface IProductB
    {
        void Interact(IProductA productA);
    }

    //PRODUCTS
    class ProductA1 : IProductA
    {
        public void Interact(IProductB productB)
        {
            Console.WriteLine("Interact " + this.GetType().Name + " with " + productB.GetType().Name);
        }
    }

    class ProductA2 : IProductA
    {
        public void Interact(IProductB productB)
        {
            Console.WriteLine("Interact " + this.GetType().Name + " with " + productB.GetType().Name);
        }
    }

    class ProductB1 : IProductB
    {
        public void Interact(IProductA productA)
        {
            Console.WriteLine("Interact " + this.GetType().Name + " with " + productA.GetType().Name);
        }
    }
    class ProductB2 : IProductB
    {
        public void Interact(IProductA productA)
        {
            Console.WriteLine("Interact " + this.GetType().Name + " with " + productA.GetType().Name);
        }
    }

    //FACTORY INTERFACE
    interface IFactory
    {
        IProductA CreateProductA();
        IProductB CreateProductB();
    }

    //FACTORIES
    class ConcreteFactory1 : IFactory
    {
        public IProductA CreateProductA()
        {
            return new ProductA1();
        }

        public IProductB CreateProductB()
        {
            return new ProductB1();
        }
    }

    class ConcreteFactory2 : IFactory
    {
        public IProductA CreateProductA()
        {
            return new ProductA2();
        }

        public IProductB CreateProductB()
        {
            return new ProductB2();
        }
    }

    //CLIENT CONSUMER CLASS CONTAINER
    class Client
    {
        private IProductA productA;
        private IProductB productB;

        public Client(IFactory factory)
        {
            productA = factory.CreateProductA();
            productB = factory.CreateProductB();
        }

        public void DoInteraction()
        {
            productB.Interact(productA);
        }
    }
}
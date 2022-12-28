using System;

/* A Factory Method delegates creation of particular object "Products" via
 * designated Factory classes. This pattern hides details of object creation - constructors and so forth - from
 * the rest of the system behind a common factory interface of CreateProduct()
 * 
*  The main benefit being: preserving the functionality of the system making use of the "product" objects
 * if object creation specifics were to later change.
 */
namespace FactoryMethod
{
    class Program
    {
        static void Main()
        {
            IFactory FactoryA = new ConcreteFactoryA();
            IFactory FactoryB = new ConcreteFactoryB();

            AbstractProduct ProductA = FactoryA.CreateProduct();
            AbstractProduct ProductB = FactoryB.CreateProduct();
        }
    }

    /* Products */

    abstract class AbstractProduct
    {
        protected AbstractProduct()
        {
            Console.WriteLine(GetType() + " Created!");
        }
    }

    class ConcreteProductA : AbstractProduct { }

    class ConcreteProductB : AbstractProduct { }

    class ConcreteProductBSpecial : AbstractProduct { } //optionaly extending original definition for overrided method below


    /* Factories */

    interface IFactory
    {
        AbstractProduct CreateProduct();
    }

    class ConcreteFactoryA : IFactory
    {
        public AbstractProduct CreateProduct()
        {
            return new ConcreteProductA();
        }
    }

    class ConcreteFactoryB : IFactory
    {
        public virtual AbstractProduct CreateProduct()
        {
            return new ConcreteProductB();
        }
    }

    class ConcreteFactoryBSpecial : ConcreteFactoryB //optionally overriding the other factory
    {
        public override AbstractProduct CreateProduct()
        {
            return new ConcreteProductBSpecial();
        }
    }
}

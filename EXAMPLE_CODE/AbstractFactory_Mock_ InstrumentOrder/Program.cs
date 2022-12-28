using System;

namespace AbstractFactoryInstrumentOrder
{
    //Abstract Factory is similar to Factory method in that it encapsulates object creation behind Factory classes, Interfaces and Creation methods
    //The main difference is Abstract Factory patterns have factories that pump out products meant to "know" about eachother and yet come from different interfaces.
    //Meanwhile, the client then holds references (via composition/aggregation) to the products (without knowing their exact types) as well as the factory used to produced them (again without knowing the exact type)
    //This allows the client to deal with the information in a completely abstract manner

    class Program
    {
        public static void Main()
        {
            Order order1 = new Order(new GuitarSale());
            order1.CompleteOrder("Ibanez");

            Order order2 = new Order(new KeyboardRental());
            order2.CompleteOrder("Roland");
        }
    }

    #region - //PRODUCTSA - InstrumentType1, InstrumentType2

    abstract class AbstractInstrument
    {
        protected string Manufacturer;
        public abstract void SetManufacturer(string manufacturer);
        public abstract string GetManufacturer();
    }

    class Guitar : AbstractInstrument
    {
        public override void SetManufacturer(string manufacturer)
        {
            Manufacturer = manufacturer + " Guitar";
        }

        public override string GetManufacturer()
        {
            return Manufacturer;
        }
    }

    class Keyboard : AbstractInstrument
    {
        public override void SetManufacturer(string manufacturer)
        {
            Manufacturer = manufacturer + " Keyboard";
        }

        public override string GetManufacturer()
        {
            return Manufacturer;
        }
    }
    #endregion

    #region - //PRODUCTSB - OrderType1, OrderType2

    abstract class AbstractOrderForm
    {
        public abstract void Assign(AbstractInstrument instrument, string manufacturer);
    }

    class SaleForm : AbstractOrderForm
    {
        public override void Assign(AbstractInstrument instrument, string manufacturer)
        {
            instrument.SetManufacturer(manufacturer);

            Console.WriteLine(
                String.Format("{0} created for a sold {1} of type {2}", this.GetType().Name, instrument.GetType().Name, instrument.GetManufacturer())
                );
        }
    }
    class RentalForm : AbstractOrderForm
    {
        public override void Assign(AbstractInstrument instrument, string manufacturer)
        {
            instrument.SetManufacturer(manufacturer);

            Console.WriteLine(
                String.Format("{0} created for a rented {1} of type {2}", this.GetType().Name, instrument.GetType().Name, instrument.GetManufacturer())
                );
        }
    }
    #endregion

    #region - //FACTORIES - InstrumentType1 + OrderType1, InstrumentType1 + OrderType2, InstrumentType2 + OrderType1, InstrumentType2 + OrderType2
    interface IFactory
    {
        AbstractInstrument CreateInstrument();
        AbstractOrderForm CreateForm();
    }

    class GuitarSale : IFactory
    {
        public AbstractInstrument CreateInstrument()
        {
            return new Guitar();
        }

        public AbstractOrderForm CreateForm()
        {
            return new SaleForm();
        }
    }

    class GuitarRental : IFactory
    {
        public AbstractInstrument CreateInstrument()
        {
            return new Guitar();
        }

        public AbstractOrderForm CreateForm()
        {
            return new RentalForm();
        }
    }

    class KeyboardSale : IFactory
    {
        public AbstractInstrument CreateInstrument()
        {
            return new Keyboard();
        }

        public AbstractOrderForm CreateForm()
        {
            return new SaleForm();
        }
    }

    class KeyboardRental : IFactory
    {
        public AbstractInstrument CreateInstrument()
        {
            return new Keyboard();
        }

        public AbstractOrderForm CreateForm()
        {
            return new RentalForm();
        }
    }
    #endregion

    #region - //CLIENT - Containing Related "Product" Objects (by composition) and Created By Factories
    class Order
    {
        private AbstractInstrument instrument;
        private AbstractOrderForm orderForm;

        public Order(IFactory factory)
        {
            instrument = factory.CreateInstrument();
            orderForm = factory.CreateForm();
        }

        public void CompleteOrder(string manufacturer)
        {
            orderForm.Assign(instrument, manufacturer);
        }
    }
    #endregion
}

using System;

namespace FacadeOrderingSystem
{
    class Program
    {
        static void Main()
        {
           new FacadeOrder().PlaceOrder();
        }
    }

    //Facade
    class FacadeOrder
    {
        private Inventory inventory = new Inventory();
        private Payment payment = new Payment();
        private Notify notify = new Notify();

        public void PlaceOrder()
        {
            if (inventory.Check() > 0 && payment.Process())
            {
                notify.SendEmail();
                Console.WriteLine("Order successful! Details have been sent by email.");
            }     
            else
                Console.WriteLine("Sorry, your order could not be processed!");
        }
    }

    //SubSystems
    class Inventory
    {
        public int Check()
        {
            Random currentInventory = new Random();
            return currentInventory.Next(4);
        }
    }

    class Payment
    {
        public bool Process()
        {
            Random isSuccessful = new Random();
            if (isSuccessful.Next(2) < 1)
                return false;
            else
                return true;
        }
    }

    class Notify
    {
        public void SendEmail()
        {
            Console.WriteLine("Email Sent!");
        }
    }

}

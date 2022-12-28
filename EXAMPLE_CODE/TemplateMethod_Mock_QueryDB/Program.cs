using System;

/* A Template Method pattern is used to call a sequence of methods common to each derriving version of the class.
 * Where the classes differ are in the particular implementation details of those called methods. In this example,
 * we are running Database connection routines and using a Template "Run" method to call the same process for
 * connecting, selecting, and disconnecting from a database. The only differences are in how the Categories class
 * selects from the database versus how the Products class selects from it.
 */

namespace TemplateMethodQueryDB
{
    class Program
    {
        static void Main()
        {
            /* Gets Brooms in Product Inventory */
            AbstractDb DbQuery1 = new Product();
            DbQuery1.RunSequence("Broom");

            /* Gets Articles on Dust */
            AbstractDb DbQuery2 = new Article();
            DbQuery2.RunSequence("Dust");
        }
    }

    abstract class AbstractDb
    {
        //The "Template method"
        public void RunSequence(string constraint)
        {
            Connect();
            Select(constraint);
            Disconnect();
        }

        public abstract void Select(string constraint);

        public void Connect()
        {
            Console.WriteLine("Connecting To Database");
        }

        public void Disconnect()
        {
            Console.WriteLine("Disconnecting from Database\n");
        }
    }

    class Product : AbstractDb
    {
        public override void Select(string productName)
        {
            Console.WriteLine("SELECT * FROM products WHERE name = " + productName);
        }
    }

    class Article : AbstractDb
    {
        public override void Select(string articleName)
        {
            Console.WriteLine("SELECT * FROM articles WHERE name = " + articleName);
        }
    }
}
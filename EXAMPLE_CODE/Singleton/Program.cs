using System;

/*
 * The point of a Singleton is to limit a class instance to exactly one (hence "Singleton") and give easy access to it from the rest of your code.
 * A good usage example might be something like a class that manages controller input in a single-player game and lots of classes will want to access the state of your controller inputs
 * Or, perhaps you're creating software that has to access a single resource or network connection and you want to avoid somehow accidentally creating multiple instances.
 * This is not only convenient for ensuring global accessibility to a single instance, but also to stringently enforces a rule to future development (or developers) that
 * otherwise would be difficult to effectively communicate - through commenting, for example - and yet is an import background rule in your business logic.
 */

namespace Singleton
{
    class Program
    {
        static void Main()
        {
            SingletonThreadSafe singleton = SingletonThreadSafe.Instance;

            Console.WriteLine(++singleton.Counter); //1
            Console.WriteLine(++singleton.Counter); //2
        }    
    }

    //Typical non-thread safe Singleton version
    class SingletonNonThreadSafe
    {
        public int Counter;

        //Prevent instantiation outside of static Instance
        private SingletonNonThreadSafe() { }

        private static SingletonNonThreadSafe _instance;
        public static SingletonNonThreadSafe Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new SingletonNonThreadSafe();

                return _instance;
            }
        }
    }

    //Fully thread-safe version. Use this when running asynchronous code
    public sealed class SingletonThreadSafe
    {
        public int Counter;

        private SingletonThreadSafe() { }

        private static object syncRoot = new Object();

        private static volatile SingletonThreadSafe _instance;
        public static SingletonThreadSafe Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (syncRoot)
                    {
                        if (_instance == null)
                            _instance = new SingletonThreadSafe();
                    }
                }
                return _instance;
            }
        }
    }
}

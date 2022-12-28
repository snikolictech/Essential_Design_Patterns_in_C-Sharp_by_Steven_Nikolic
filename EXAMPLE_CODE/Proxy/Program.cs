/* A proxy is a class that "wraps around" and controls access to an "actual class" of interest
 * by containing an instance of the "actual class" inside of it and using an
 * interface to conform to the same method names as the "actual class" of interest.
 * These methods then simply call the methods of the same name in the "actual class."
 */ 
 
using System;

namespace ProxyScaffolding
{
    class Program
    {
        static void Main()
        {
            Subject proxy = new Proxy();
            proxy.Request();
        }
    }

    interface Subject
    {
        void Request();
    }

    class RealSubject : Subject
    {
        public void Request()
        {
            Console.WriteLine("RealSubect's Real Request() called");
            //Request's implementation details
        }
    }

    class Proxy : Subject
    {
        private RealSubject realSubject;

        public Proxy()
        {
            realSubject = new RealSubject();
        }

        public void Request()
        {
            realSubject.Request();
        }
    }
}

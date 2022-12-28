/* Simple example of using a wrapper class to encapsulate a different class
* usually used to safely expose core functionality throughout a system, while hiding the class that might change in unpredictable ways (often 3rd party code)
* Below is a scaffold example of how a system can accomodate switching and using different logging frameworks, by using a single interface and polymorphic wrapping classes
*/

using System;

namespace LogWrapper
{
    class Program
    {
        public static void Main()
        {
            ILog logger;
            
            logger = new LogWrapperA();
            logger.Log("Success");

            logger = new LogWrapperB();
            logger.Log("Success");
        }
    }

    interface ILog
    {
        void Log(object message);
    }

    class LogWrapperA : ILog
    {
        private LogFrameworkTypeA externalModule;

        public LogWrapperA()
        {
            externalModule = new LogFrameworkTypeA();
        }

        public void Log(object message)
        {
            string msg = message as string;
            externalModule.Log(msg);
        }
    }

    class LogWrapperB : ILog
    {
        private LogFrameworkTypeB externalModule;

        public LogWrapperB()
        {
            externalModule = new LogFrameworkTypeB();
        }

        public void Log(object message)
        {
            bool error = ((string)message == "Fail") ? true : false;
            externalModule.Log(error);
        }
    }

    class LogFrameworkTypeA
    {
        public void Log(string message)
        {
            Console.WriteLine("Logging Framework #1 Outputs: " + message);
        }
    }

    class LogFrameworkTypeB
    {
        public void Log(bool error)
        {
            Console.WriteLine("Logging Framework #2 Outputs Errors = " + error);
        }
    }
}

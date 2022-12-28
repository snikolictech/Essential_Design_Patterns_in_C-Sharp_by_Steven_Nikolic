using System;

//In this Bridge pattern adaptation of our logging system we are hiding two different logging implementations behind a 
//Shared interface (ILog). This is not a very good pattern when adapting 3rd party libraries or mismatching interfaces.
//To make this pattern fit our example, we had to assume the two logging options have the same interface. In this sense, they can
//Still be swapped out (a great feature of using the Bridge pattern) with high degree of abstraction. However, this pattern is
//Mostly realistic to use when creating the entire code structure and not sure of which implementation to run. A good reason for this is
//To make the code platform independant, running one implementation if one platform is chosen and another if a different one is chosen.
//Therefore, in this example, this would be a pattern one of the logging frameworks would have used when creating the framework.

namespace BridgeLogWrapper
{
    class Program
    {
        public static void Main()
        {
            string platform = "windows";
            ILogAbstraction logger = new LogWrapper();

            switch (platform)
            {
                case "windows":
                    logger.Module = new LogImplementationA();
                    break;
                case "linux":
                    logger.Module = new LogImplementationB();
                    break;
            }

            logger.Log("Success");
        }
    }

    interface ILogAbstraction
    {
        ILogImplementation Module { get; set; }
        void Log(string message);
    }

    class LogWrapper : ILogAbstraction
    {
        public ILogImplementation Module { get; set; }

        public void Log(string message)
        {
            Module.Log(message);
        }
    }

    interface ILogImplementation
    {
        void Log(string message);
    }

    class LogImplementationA : ILogImplementation
    {
        public void Log(string message)
        {
            Console.WriteLine("Logging Framework for Windows Outputs: " + message);
            //Do Windows Specific Logging Here
        }
    }

    class LogImplementationB : ILogImplementation
    {
        public void Log(string message)
        {
            Console.WriteLine("Logging Framework for Linux Outputs: " + message);
            //Do Linux Specific Logging Here
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdapterLoggingExample
{
    class Program
    {
        public static void Main()
        {
            LogTarget logger = new LogAdapter();
            logger.Log("Success");
        }
    }

    class LogTarget
    {
        public virtual void Log(string message)
        {
            Console.WriteLine("LogTarget Log() Called: " + message);
        }
    }

    class LogAdapter : LogTarget
    {
        private LogFrameworkAdaptee externalModule = new LogFrameworkAdaptee();

        public override void Log(string message)
        {
            base.Log(message);
            bool error = (message == "Fail") ? true : false;
            externalModule.Logger(error);
        }
    }

    class LogFrameworkAdaptee
    {
        public void Logger(bool error)
        {
            Console.WriteLine("Logging Framework Outputs Errors = " + error);
        }
    }
}

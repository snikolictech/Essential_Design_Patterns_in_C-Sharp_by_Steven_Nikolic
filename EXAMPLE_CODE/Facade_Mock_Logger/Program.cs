using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacadeLogger
{
    class Program
    {
        public static void Main()
        {
            ILog facadeLogger = new LogFacadeA();
            facadeLogger.Log("Success", "LogTypeB");
        }
    }

    interface ILog
    {
        void Log(object message, string chooseFramework);
    }

    class LogFacadeA : ILog
    {
        private LogTypeA logTypeA;
        private LogTypeB logTypeB;

        public LogFacadeA()
        {
            logTypeA = new LogTypeA();
            logTypeB = new LogTypeB();
        }

        public void Log(object message, string AorB)
        {
            if (AorB == "LogTypeA")
            {
                string msg = message as string;
                logTypeA.Log(msg);
            }
            else if (AorB == "LogTypeB")
            {
                bool error = ((string)message == "Fail") ? true : false;
                logTypeB.Log(error);
            }
        }
    }

    class LogTypeA
    {
        public void Log(string message)
        {
            Console.WriteLine("Logging Framework #1 Outputs: " + message);
        }
    }

    class LogTypeB
    {
        public void Log(bool error)
        {
            Console.WriteLine("Logging Framework #2 Outputs Errors = " + error);
        }
    }

}

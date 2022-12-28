using System;

/* In this representation of the Facade pattern, we "hide" 3 different "modules"
 * behind an internal "facade" representation that then calls methods from the modules.
 */

namespace Facade
{
    class Program
    {
        public static void Main()
        {
            Facade facade = new Facade();
            facade.FacadeMethodA();
            facade.FacadeMethodB();
        }
    }

    //Facade Simplification
    class Facade
    {
        private ModuleA moduleA;
        private ModuleB moduleB;
        private ModuleC moduleC;

        public Facade()
        {
            moduleA = new ModuleA();
            moduleB = new ModuleB();
            moduleC = new ModuleC();
        }

        public void FacadeMethodA()
        {
            Console.WriteLine("FacadeMethodA: ");
            moduleA.OperationX();
            moduleB.OperationY();
        }

        public void FacadeMethodB()
        {
            Console.WriteLine("FacadeMethodB: ");
            moduleC.OperationZ();
        }
    }

    //SubSystem Modules A, B and C
    class ModuleA
    { 
        public void OperationX()
        {
            Console.WriteLine(" ModuleA Method");
        }
    }

    class ModuleB
    {
        public void OperationY()
        {
            Console.WriteLine(" ModuleB Method");
        }
    }

    class ModuleC
    {
        public void OperationZ()
        {
            Console.WriteLine(" ModuleC Method");
        }
    }
}
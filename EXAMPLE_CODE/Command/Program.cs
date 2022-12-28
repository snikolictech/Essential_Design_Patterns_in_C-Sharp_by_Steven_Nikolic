using System;

/* Invoker  ---initiates-->  Command  ---sends-to-->  Receiver
 *	      
 * Values for parameters of the receiver method are stored in the command. 
 * The receiver then does the work. An invoker object knows how to execute a command, and optionally does bookkeeping about the command execution. 
 * The invoker does not know anything about a concrete command, it knows only about command interface. 
 * 
 */

namespace CommandPattern
{ 
    class Program
    {
        static void Main()
        {
            Invoker invoker = new Invoker();
            invoker.SetCommand(new ConcreteCommand(new Receiver()));
            invoker.InitiateCommand();
        }
    }


    // Invoker 

    class Invoker
    {
        private ICommand command;

        public void SetCommand(ICommand command)
        {
            this.command = command;
        }

        public void InitiateCommand()
        {
            command.ExecuteCommand();
        }
    }


    //Command

    interface ICommand
    {
        void ExecuteCommand();
    }

    class ConcreteCommand : ICommand
    {
        Receiver receiver;

        public ConcreteCommand(Receiver receiver)
        {
            this.receiver = receiver;
        }

        public void ExecuteCommand()
        {
            receiver.ActionUponCommand();
        }
    }


    //Receivers

    interface IReceiver
    {
        void ActionUponCommand();
    }

    class Receiver : IReceiver
    {
        public void ActionUponCommand()
        {
            Console.WriteLine(this.GetType() + " ActionUponCommand() called!");
        }
    }
}
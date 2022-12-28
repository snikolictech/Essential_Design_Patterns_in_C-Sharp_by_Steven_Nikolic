using System;
using System.Collections.Generic;

namespace CommandCalculator
{
    class Program
    {
        static void Main()
        {
            Invoker user = new Invoker();

            user.Do(Operation.Add, 4);
            user.Do(Operation.Divide, 5);

            user.Undo();
            user.Undo();
            user.Undo();

            user.Redo();
            user.Redo();
            user.Redo();
        }
    }

    class Invoker
    {
        IReceiver calculator = new Receiver();
        List<ICommand> undoList = new List<ICommand>();
        List<ICommand> redoList = new List<ICommand>();

        public void Do(Operation operation, double n)
        {
            Command command = new Command(operation, n, calculator);
            command.Execute();

            undoList.Add(command);
            redoList = new List<ICommand>();
        }

        public void Undo()
        {
            if (undoList.Count == 0)
            {
                Console.WriteLine("NO OPERATION TO UNDO");
                return;
            }

            ICommand lastCommand = undoList[undoList.Count - 1];
            Console.Write("UNDO back to ");
            lastCommand.ExecuteOpposite();

            redoList.Add(lastCommand);
            undoList.Remove(lastCommand);

        }

        public void Redo()
        {
            if (redoList.Count == 0)
            {
                Console.WriteLine("NO OPERATION TO REDO");
                return;
            }
                
            ICommand lastCommand = redoList[redoList.Count - 1];
            Console.Write("REDO back to ");
            lastCommand.Execute();

            undoList.Add(lastCommand);
            redoList.Remove(lastCommand);
        }
    }

    interface ICommand
    {
        double n { get; set; }
        Operation operation { get; set; }

        void Execute();
        void ExecuteOpposite();
    }

    class Command : ICommand
    {
        public double n { get; set; }
        public Operation operation { get; set; }
        IReceiver receiver;

        public Command(Operation operation, double n, IReceiver receiver)
        {
            this.n = n;
            this.operation = operation;
            this.receiver = receiver;
        }

        public void Execute()
        {
            this.receiver.Calc(this);
        }

        public void ExecuteOpposite()
        {
            Operation opposite;

            switch (this.operation)
            {
                case Operation.Add:
                    opposite = Operation.Subtract;
                    break;
                case Operation.Subtract:
                    opposite = Operation.Add;
                    break;
                case Operation.Multiply:
                    opposite = Operation.Divide;
                    break;
                case Operation.Divide:
                    opposite = Operation.Multiply;
                    break;
                default:
                    opposite = Operation.Add;
                    break;
            }

            this.receiver.Calc(new Command(opposite, this.n, this.receiver));
        }
    }

    interface IReceiver
    {
        void Calc(ICommand command);
    }

    class Receiver : IReceiver
    {
        private double sum;

        public void Calc(ICommand command)
        {

            switch(command.operation)
            {
                case Operation.Add:
                    sum += command.n;
                    break;
                case Operation.Subtract:
                    sum -= command.n;
                    break;
                case Operation.Multiply:
                    sum *= command.n;
                    break;
                case Operation.Divide:
                    sum /= command.n;
                    break;
                default:
                    sum = 0;
                    break;
            }

            Console.WriteLine(sum);
        }
    }

    enum Operation
    {
        Add,
        Subtract,
        Multiply,
        Divide
    }
}

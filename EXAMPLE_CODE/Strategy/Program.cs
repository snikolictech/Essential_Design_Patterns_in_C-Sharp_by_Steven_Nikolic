using System;

/* The Strategy pattern is a way to switch "strategies", swapping functionality when you want
 * to employ a different behaviour. This is similar to the State pattern, however, you might 
 * choose to use the Strategy pattern whenever it doesn't make sense to have an object hold a "state."
 */

namespace Strategy
{
    class Program
    {
        static void Main()
        {
            Subject subject = new Subject(new ConcreteStrategyB());
            subject.CallAlgorithm(); //AlgorithmB
        }
    }


    /* Subject */

    class Subject
    {
        private IStrategy strategy;

        public Subject(IStrategy strategy)
        {
            this.strategy = strategy;
        }

        public void CallAlgorithm()
        {
            strategy.Algorithm();
        }
    }


    /* Strategies */

    interface IStrategy
    {
        void Algorithm();
    }

    class ConcreteStrategyA : IStrategy
    {
        public void Algorithm()
        {
            Console.WriteLine("AlgorithmA");
        }
    }

    class ConcreteStrategyB : IStrategy
    {
        public void Algorithm()
        {
            Console.WriteLine("AlgorithmB");
        }
    }

    class ConcreteStrategyC : IStrategy
    {
        public void Algorithm()
        {
            Console.WriteLine("AlgorithmC");
        }
    }
}

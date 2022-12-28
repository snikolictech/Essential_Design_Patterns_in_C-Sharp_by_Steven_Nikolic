using System;
using System.Collections;

/* The Iterator pattern is a way to separate an object, called the "Aggregate" that holds a iterable collection of items (such as an Array)
 * from iterating functionality, housed in its own Iterator class. The normal usage would be for a client class to create the iterable items
 * in an instance of the aggregate, and then pass that aggregate object into an instance of an iterator. That Iterator can then produce a series
 * of functions common to iteration as well as custom functions such as keeping track of the "item" being iterated on, going to the first, next
 * or last item.
 * 
 * Although modern languages contain built-in iterators such as IEnumerable and List<T>, custom iterators are still useful when having to deal with
 * complex iteration, sometimes involving types and collection sizes that are unknown or otherwise don't share a common iterable structure and can 
 * have different iterator classes handle different ways of iterating.
 */ 

namespace Iterator
{
    class Program
    {
        static void Main()
        {
            IAggregate aggregate = new ConcreteAggregate(
                 new object[] { "Item1", "Item2", "Item3", "Item4" }
                );

            // Create Iterator via aggregate
            IIterator iterator = aggregate.CreateIterator();
            
            //iterator.ForEach(a =>  Console.WriteLine(a.CurrentItem().ToString().EndsWith("C")));
            iterator.ForEach(a =>
            {
                if (a.CurrentItem().ToString().EndsWith("3"))
                    Console.WriteLine(a.CurrentItem());
            });
        }
    }

    interface IAggregate
    {
        IIterator CreateIterator();
    }

    class ConcreteAggregate : IAggregate
    {
        public ConcreteAggregate(object[] items)
        {
            this.items = items;
        }

        private object[] items;

        public object this[int index]
        {
            get { return items[index]; }
            set { items[index] = value; }
        }

        public int Count
        {
            get { return items.Length; }
        }

        public IIterator CreateIterator()
        {
            return new ConcreteIterator(this);
        }
    }

    interface IIterator
    {
        object First();
        object Next();
        bool IsDone();
        object CurrentItem();
        void ForEach(Action<ConcreteIterator> action);
    }

    class ConcreteIterator : IIterator
    {
        private ConcreteAggregate aggregate;
        private int current = 0;

        public ConcreteIterator(ConcreteAggregate aggregate)
        {
            this.aggregate = aggregate;
        }

        //Return first item in aggregate
        public object First()
        {
            return aggregate[0];
        }

        //Return next item in aggregate
        public object Next()
        {
            return (current < aggregate.Count - 1) ? aggregate[current++] : null;
        }

        //Return current item in aggregate
        public object CurrentItem()
        {
            return aggregate[current];
        }

        //Returns true when last item in aggregate is reached
        public bool IsDone()
        {
            return current >= aggregate.Count - 1;
        }


        //Default foreach type loop with custom Action<> behavior
        public void ForEach(Action<ConcreteIterator> action)
        {
            while (true)
            {
                action(this);

                if (IsDone())
                {
                    current = 0;
                    return;
                }

                Next();
            }
        }
    }
}
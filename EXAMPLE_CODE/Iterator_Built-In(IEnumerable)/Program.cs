using System;
using System.Collections;
using System.Collections.Generic;

namespace IteratorBuiltIn
{
    class Program
    {
        static void Main()
        {
            //Built In Iterator (IEnumerator) using Lists/ArrayLists/Arrays (IEnumerable)
            IEnumerable enumerable = new List<int>() { 6, 12, 7, 9, 4 };
            IEnumerator enumerator = enumerable.GetEnumerator();

            while (enumerator.MoveNext())
                Console.WriteLine(enumerator.Current);


            //Custom IEnumerable/IEnumerator with Aggregate Array
            IEnumerable aggregate = new Aggregate(new HockeyPlayer[3] {
                new HockeyPlayer() { Name = "McDavid", Goals = 30, Assists = 70 },
                new HockeyPlayer() { Name = "Crosby", Goals = 44, Assists = 45 },
                new HockeyPlayer() { Name = "Kane", Goals = 34, Assists = 55 }
            });

            IEnumerator iterator = aggregate.GetEnumerator();


            //IEnumerable Means an Aggregate Can Be Natively Iterated w/o Using Iterator
            foreach (object item in aggregate)
                Console.WriteLine(item);


            //ACTION LAMBDA- Custom ForEach
            Action CustomForeach = () =>
            {
                Console.WriteLine("Custom Foreach");

                while (iterator.MoveNext())
                    Console.WriteLine(((HockeyPlayer)iterator.Current).Name);

                iterator.Reset();
                Console.WriteLine();
            };

            CustomForeach();


            //ACTION WITHIN ACTION - Custom Foreach w/ Custom Filter
            Action<string, Action<HockeyPlayer>> CustomFilter = (msg, act) =>
            {
                Console.WriteLine("Custom Filter by " + msg);

                while (iterator.MoveNext())
                    act(iterator.Current as HockeyPlayer);

                iterator.Reset();
                Console.WriteLine();
            };

            CustomFilter("Goals Over 30", hp => 
            {
                if (hp.Goals > 30)
                    Console.WriteLine(hp.Name);
            });

            CustomFilter("Assists Over 50", hp =>
            {
                if (hp.Assists > 50)
                    Console.WriteLine(hp.Name);
            });
        }
    }

    class Aggregate : IEnumerable
    {
        private object[] items;

        public object this[int index]
        {
            get { return items[index]; }
            set { items[index] = value; }
        }

        public Aggregate(object[] items)
        {
            this.items = items;
        }

        public int Count
        {
            get { return items.Length; }
        }

        public IEnumerator GetEnumerator()
        {
            return new Iterator(this);
        }
    }

    class Iterator : IEnumerator
    {
        private Aggregate items;

        public Iterator(Aggregate items)
        {
            this.items = items;
        }

        private int _current = -1;
        public object Current
        {
            get { return items[_current]; }
        }

        public bool MoveNext()
        {
            if (_current < items.Count - 1)
            {
                _current++;
                return true;
            }
            else
                return false;
        }

        public void Reset()
        {
            _current = -1;
        }
    }

    public class HockeyPlayer 
    {
        public string Name;
        public int Goals;
        public int Assists;
    }
}

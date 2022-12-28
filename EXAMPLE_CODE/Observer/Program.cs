/* A simple example of an Observer pattern in C# without using built-in features such as events */

using System;
using System.Collections.Generic;

namespace ObserverPrimitive
{
    class Program
    {
        static void Main()
        {
            Subject subject = new Subject("The Subject");

            AbstractObserver observerA = new ObserverA();
            AbstractObserver observerB = new ObserverB();

            subject.AddObserver(observerA);
            subject.AddObserver(observerB);

            subject.Notify();
        }
    }

    /* SUBJECT */
    class Subject
    {
        private List<AbstractObserver> observers;
        public string Name;

        public Subject (string Name)
        {
            this.Name = Name;
            observers = new List<AbstractObserver>();
        }

        public void Notify()
        {
            if (observers != null)
                foreach (AbstractObserver o in observers)
                    o.Notify(this);
        }

        public void AddObserver(AbstractObserver observer)
        {
            observers.Add(observer);
        }

        public void RemoveObserver(AbstractObserver observer)
        {
            observers.Remove(observer);
        }
    }

    /* OBSERVERS */
    abstract class AbstractObserver
    {
        public virtual void Notify(Subject sender)
        {
            Console.WriteLine(this.GetType().Name + " received notification from " + sender.Name);
        }
    }

    class ObserverA : AbstractObserver { }

    class ObserverB : AbstractObserver { }
}

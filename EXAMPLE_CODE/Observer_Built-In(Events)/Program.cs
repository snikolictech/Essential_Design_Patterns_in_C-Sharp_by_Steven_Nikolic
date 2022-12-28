/* C# has built-in functionality for handling the Observer pattern by using events.
* this is a simple example of how a classic Observer functions, while utlizing events to simplify some of the internal operation
*/

using System;

namespace ObserverPattern
{
    class Program
    {
        static void Main()
        {
            Subject subject = new Subject("The Subject");

            AbstractObserver observerA = new ObserverA();
            AbstractObserver observerB = new ObserverB();

            subject.Handler += observerA.Notify;
            subject.Handler += observerB.Notify;

            subject.Notify();
        }
    }

    /* SUBJECT */
    class Subject
    {
        public string Name;
        public event EventHandler Handler;

        public Subject(string Name)
        {
            this.Name = Name;
        }

        public void Notify()
        {
            if (Handler != null)
                Handler(this, new MyEventArgs());
        }
    }

    /* OBSERVERS */
    abstract class AbstractObserver
    {
        public virtual void Notify(object sender, EventArgs e)
        {
            Subject s = sender as Subject;
            MyEventArgs args = e as MyEventArgs;

            Console.WriteLine(this.GetType().Name +
                 " received notification from " + s.Name + " at time: " + args.TimeStamp
            );
        }
    }

    class ObserverA : AbstractObserver { }

    class ObserverB : AbstractObserver { }


    class MyEventArgs : EventArgs
    {
        public DateTime TimeStamp = DateTime.Now;
    }
}
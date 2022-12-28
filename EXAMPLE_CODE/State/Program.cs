using System;

/* A State design pattern has a material object (or "subject" or "context") that has to change in basic functionality
 * due to any kind of trigger to set that state. This functionality is handled by a State field that can take on
 * a number of possible derrived states.
 */

namespace StateScaffold
{
    class Program
    {
        static void Main()
        {
            Subject subject = new Subject(new ConcreteStateA());

            subject.StateChange(); //ConcreteStateB
            subject.StateChange(); //ConcreteStateA
            subject.StateChange(); //ConcreteStateB
            subject.StateChange(); //ConcreteStateA
        }
    }

    /* Subject */
    class Subject
    {
        public IState State;

        public Subject(IState state)
        {
            State = state;
        }

        public void StateChange()
        {
            State.Switch(this);
        }
    }

    /* States */
    interface IState
    {
        void Switch(Subject subject);
    }

    class ConcreteStateA : IState
    {
        public void Switch(Subject subject)
        {
            subject.State = new ConcreteStateB();
            Console.WriteLine(subject.State.GetType().Name);
        }
    }

    class ConcreteStateB : IState
    {
        public void Switch(Subject subject)
        {
            subject.State = new ConcreteStateA();
            Console.WriteLine(subject.State.GetType().Name);
        }
    }
}

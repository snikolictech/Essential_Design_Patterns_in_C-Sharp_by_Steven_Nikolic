using System;

/* A State design pattern has a material object (or "subject" or "context") that has to change in basic functionality
 * due to any kind of trigger to set that state. This functionality is handled by a State field that can take on
 * a number of possible derrived states.
 */
  
namespace State
{
    class Program
    {
        static void Main()
        {
            Material material = new Material(new Solid());

            material.StateChange(); //"Material - StateChange: Liquid"
            material.StateChange(); //"Material - StateChange: Solid"
            material.StateChange(); //"Material - StateChange: Liquid"
            material.StateChange(); //"Material - StateChange: Solid"
        }
    }

    /* State Types */
    abstract class State
    {
        public abstract void Switch(Material material);
    }

    class Liquid : State
    {
        public override void Switch(Material material)
        {
            material.State = new Solid();
        }
    }

    class Solid : State
    {
        public override void Switch(Material material)
        {
            material.State = new Liquid();
        }
    }


    /* Subject */
    class Material
    {
        public Material(State state)
        {
            this.State = state;
        }

        private State _state;
        public State State
        {
            set
            {
                _state = value;
                PostState();
            }
        }

        public void StateChange()
        {
            _state.Switch(this);
        }

        private void PostState()
        {
            Console.WriteLine(GetType().Name + " - StateChange: " + _state.GetType().Name);
        }
    }
}
using System;
using System.Collections.Generic;

namespace CompositeGameEngine
{
    class Program
    {
        static void Main()
        {
            //--------------
            GameObject Go1 = new GameObject("Container");
            Component T1 = new Transform("ContainerTransform");
            Component S1 = new Script("ContainerScript");
            Go1.Add(T1);
            Go1.Add(S1);
            //--------------


            //--------------
            GameObject Go2 = new GameObject("CarBody");
            Component T2 = new Transform("BodyTransform");
            Component R1 = new Renderer("BodyRenderer");
            Go2.Add(T2);
            Go2.Add(R1);
            //--------------


            //--------------
            GameObject Go3 = new GameObject("CarWheels");
            Component T3 = new Transform("WheelsTransform");
            Component R2 = new Renderer("WheelsRenderer");
            Component A1 = new Animator("WheelsAnimator");
            Go3.Add(T3);
            Go3.Add(R2);
            Go3.Add(A1);
            //--------------


            //--------------
            Go1.Add(Go2);
            Go1.Add(Go3);
            //--------------


            //Trace Forward/Backward
            //Go1.TraceFwd();
            R1.TraceBack();
        }
    }

    abstract class Component
    {
        protected string name;
        public GameObject Parent;

        public Component(string name)
        {
            this.name = name;
        }

        public abstract void Add(Component component);
        public abstract void Remove(Component component);

        public virtual void TraceFwd()
        {
            Console.WriteLine("\n" + name + " (Composite) has Connected to it:");

            GameObject g = this as GameObject;

            foreach (Component c in g.subComps)
            {
                c.TraceFwd();
            }
        }

        public virtual void TraceBack()
        {
            Console.Write(this.name);
            if (Parent != null)
            {
                Console.Write(" Traces Back to ");
                Parent.TraceBack();
            }

            Console.WriteLine();
        }
    }


    //Composite
    class GameObject : Component
    {
        public GameObject(string name) : base(name) { }

        public List<Component> subComps = new List<Component>();

        public override void Add(Component component)
        {
            component.Parent = this;
            subComps.Add(component);
        }

        public override void Remove(Component component)
        {
            subComps.Remove(component);
        }
    }


    //Leaf
    abstract class Leaf : Component
    {
        public Leaf(string name) : base(name) { }

        public override void Add(Component component)
        {
            throw new Exception(name + " is a Leaf. Cannot Add Component.");
        }

        public override void Remove(Component component)
        {
            throw new Exception(name + " is a Leaf. Cannot Remove Component.");
        }

        public override void TraceFwd()
        {
            Console.WriteLine(name + " (Leaf)");
        }
    }

    class Transform : Leaf
    {
        public Transform(string name) : base(name) { }
    }

    class Renderer : Leaf
    {
        public Renderer(string name) : base(name) { }
    }

    class Animator : Leaf
    {
        public Animator(string name) : base(name) { }
    }

    class Script : Leaf
    {
        public Script(string name) : base(name) { }

        public override void TraceFwd()
        {
            base.TraceFwd();
            Update();
        }

        private void Update()
        {
            Console.WriteLine(" [ Update Loop Running ] ");
        }
    }
}
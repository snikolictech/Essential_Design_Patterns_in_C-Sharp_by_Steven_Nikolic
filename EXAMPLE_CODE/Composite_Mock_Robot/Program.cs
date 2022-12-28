using System;
using System.Collections.Generic;

/* The Composite pattern is very similar in appearance to the Decorator pattern. The main similarity is in
 * the the way that object's are built up from simpler components, in a tree-like fashion. One of the main differences
 * between this pattern and the Decorator pattern is in the style of how the objects are built. A Decorator utilizes more of an
 * aggregation approach: IE, Component E contains Component D which contains Component C which contains Component B, etc...
 * Meanwhile, the Composite approach contains each component in a single Composition root. This is typically withing a single
 * array or List<> structure.
 */

namespace CompositeRobot
{
    class Program
    {
        static void Main()
        {
            //Right Parts of Robot
            Component handR = new Composite("Right Hand");
            for (int i=1; i <= 5; i++)
                handR.Add(new Leaf("Finger" + i));

            Component armR = new Composite("Right Arm");
            armR.Add(handR);

            Component shoulderR = new Composite("Right Shoulder");
            shoulderR.Add(armR);

            //Left Parts of Robot
            Component handL = new Composite("Left Hand");
            for (int i = 1; i <= 5; i++)
                handL.Add(new Leaf("Finger" + i));

            Component armL = new Composite("Left Arm");
            armL.Add(handR);

            Component shoulderL = new Composite("Left Shoulder");
            shoulderL.Add(armL);

            //Attach Left/Right Parts to Body
            Component body = new Composite("Body");
            body.Add(shoulderR);
            body.Add(shoulderL);

            Component Base = new Leaf("Base");
            body.Add(Base);

            //Wire Up to View Connections
            body.WireUp(1, "=*=");

            //Can't Add/Remove To Leaf
            //Base.Add(new Composite("Right Leg"));
        }
    }

    abstract class Component
    {
        protected string PartName;

        public Component(string partName)
        {
            PartName = partName;
        }

        public abstract void Add(Component component);
        public abstract void Remove(Component component);
        public virtual void WireUp(int length, string gauge)
        {
            string wire = "";

            for (int i = 1; i < length; i++)
                wire += " ";

            wire += gauge;

            Console.WriteLine(wire + PartName);
        }
    }

    class Composite : Component
    {
        private List<Component> subComps = new List<Component>();
        
        public Composite(string partName) : base(partName) { }

        public override void Add(Component component)
        {
            subComps.Add(component);
        }

        public override void Remove(Component component)
        {
            subComps.Remove(component);
        }

        public override void WireUp(int length, string gauge)
        {
            base.WireUp(length, gauge);

            foreach (Component component in subComps)
                component.WireUp(length + 1, gauge);
        }
    }

    class Leaf : Component
    {
        public Leaf(string partName) : base(partName) { }

        public override void Add(Component component)
        {
            throw new Exception("Attaching Component to Leaf Not Allowed!");
        }

        public override void Remove(Component component)
        {
            throw new Exception("Removing Component from Leaf Not Allowed!");
        }

        public override void WireUp(int length, string gauge)
        {
            base.WireUp(length, gauge);
        }
    }
}

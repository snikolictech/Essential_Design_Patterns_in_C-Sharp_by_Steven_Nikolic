using System;
using System.Collections.Generic;

/* The Composite pattern is very similar in appearance to the Decorator pattern. The main similarity is in
 * the the way that object's are built up from simpler components, in a tree-like fashion. One of the main differences
 * between this pattern and the Decorator pattern is in the style of how the objects are built. A Decorator utilizes more of an
 * aggregation approach: IE, Component E contains Component D which contains Component C which contains Component B, etc...
 * Meanwhile, the Composite approach contains each component in a single Composition root. This is typically withing a single
 * array or List<> structure.
 */

namespace Composite
{
    class Program
    {
        static void Main()
        {
            // Create a tree structure
            Composite composite1 = new Composite("Main Composition X");
            composite1.Add(new Leaf("Leaf XA"));
            composite1.Add(new Leaf("Leaf XB"));

            Composite composite2 = new Composite("Sub Composition Y");
            composite2.Add(new Leaf("Leaf YA"));
            composite2.Add(new Leaf("Leaf YB"));

            composite1.Add(composite2);
            composite1.Add(new Leaf("Leaf XC"));

            // Add and remove a leaf
            Leaf leaf = new Leaf("Leaf XD");
            composite1.Add(leaf);
            composite1.Remove(leaf);

            // Recursively display tree
            composite1.Display(1, '=');
        }
    }

    abstract class Component
    {
        protected string name;

        public Component(string name)
        {
            this.name = name;
        }

        public abstract void Add(Component component);

        public abstract void Remove(Component component);

        public abstract void Display(int depth, char separator);
    }

    class Composite : Component
    {
        private List<Component> children = new List<Component>();

        public Composite(string name) : base(name) { }


        public override void Add(Component component)
        {
            children.Add(component);
        }

        public override void Remove(Component component)
        {
            children.Remove(component);
        }

        public override void Display(int depth, char separator)
        {
            Console.WriteLine(
                new String(separator, depth) + name
            );

            foreach (Component component in children)
            {
                component.Display(depth + 1, separator);
            }
        }
    }

    class Leaf : Component
    {
        public Leaf(string name) : base(name) { }


        public override void Add(Component component)
        {
            Console.WriteLine("Cannot add to a leaf");
        }

        public override void Remove(Component component)
        {
            Console.WriteLine("Cannot remove from a leaf");
        }

        public override void Display(int depth, char separator)
        {
            Console.WriteLine(
                new String(separator, depth) + name
            );
        }
    }
}
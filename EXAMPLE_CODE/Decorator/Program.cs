using System;

/* A Decorator pattern basically creates a base Component class that itself can contain a Component.
 * You can then use these components to build-up complex objects, and mix-&-match bit-by-bit. Pay close attention
 * to the way that derrived Operation() methods place calls to inherited base Operation() which, in turn, references the attached component.
 * This has the effect of constructing a tree of objects that can behave as one.
 */
namespace Decorator
{
    class Program
    {
        static void Main()
        {
            BaseComponent basicComp = new BaseComponent();

            Decorator firstDecoration = new DecoratorA();

            //Extend functionality of BasicComponent by adding it to a Decorator
            firstDecoration.AttachComponent(basicComp);

            Decorator secondDecoration = new DecoratorB();

            //Extend functionality of BasicComponent and DecoratorA by adding it to another Decorator
            secondDecoration.AttachComponent(firstDecoration);

            //Do Operations for all Decorators/Components
            secondDecoration.Operation();
        }
    }

    //Basic interface for all Components
    interface Component
    {
        void Operation();
    }

    //Base Component - Doesn't hold a component reference
    class BaseComponent : Component
    {
        public void Operation()
        {
            Console.WriteLine("BaseComponent Operation()");
        }
    }

    //Base Decorator - Can hold a component reference
    abstract class Decorator : Component
    {
        protected Component component;

        public void AttachComponent(Component component)
        {
            this.component = component;
        }

        public virtual void Operation()
        {
            if (component != null)
                component.Operation();
        }
    }

    //Concrete Decorators - Can be added onto any other Decorator
    class DecoratorA : Decorator
    {
        public override void Operation()
        {
            base.Operation();
            Console.WriteLine("DecoratorA Operation()");
        }
    }

    class DecoratorB : Decorator
    {
        public override void Operation()
        {
            base.Operation();
            Console.WriteLine("DecoratorB Operation()");
        }
    }
}

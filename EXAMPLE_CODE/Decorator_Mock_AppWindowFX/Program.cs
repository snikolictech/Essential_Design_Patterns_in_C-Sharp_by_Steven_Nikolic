using System;

namespace DecoratorWindow
{
    class Program
    {
        static void Main()
        {
            Component window = new Window();

            Decorator border = new Border();
            Decorator shadow = new Shadow();
            Decorator glow = new Glow();

            border.AttachComponent(window);
            shadow.AttachComponent(border);

            shadow.Draw(); //draws window with border, then shadow
        }
    }

    
    interface Component
    {
        void Draw();
    }

    //Base Component
    class Window : Component
    {
        public void Draw()
        {
            Console.WriteLine("Drew a Window");
        }
    }

    //Base Decorator
    abstract class Decorator : Component
    {
        protected Component component;

        public void AttachComponent(Component component)
        {
            this.component = component;
        }

        public virtual void Draw()
        {
            if (component != null)
                component.Draw();
        }
    }

    //Concrete Style Decorators (Border, Shadow, Glow)
    class Border : Decorator
    {
        public override void Draw()
        {
            base.Draw();
            Console.WriteLine("Drew a Border Around the Window");
        }
    }

    class Shadow : Decorator
    {
        public override void Draw()
        {
            base.Draw();
            Console.WriteLine("Drew a Shadow Around the Window");
        }
    }

    class Glow : Decorator
    {
        public override void Draw()
        {
            base.Draw();
            Console.WriteLine("Drew a Glow Around the Window");
        }
    }
}

using System;

// This is a non-thread-safe (for simplicity), mock example of how a singleton might be used in a real-word example. 
// For this example, we're working within a game engine that can have a single playable character with multiple states.

// The problem this pattern is solving:

// We know ahead of time that we can only have one player, which can hold different forms or "state" types (Wizard, Knight, Whatever)
// It will be convenient to provide a globally accessible object to other classes that need access to this player.
// Because we're using a singleton and not simply a static class to provide this, we can use Polymorphism and keep different
// implementations for each state type. We know absolutely that each state type is singular 
// (only one version of each state type is necessary) and using singletons for those state types helps solve the problem of providing
// global accessibilty to a singular object that can nevertheless come in different forms/states.

 

namespace MockGameEngine
{
    class Program
    {
        static void Main()
        {
            AbstractPlayer player1;

            player1 = PlayerForm1.Instance;
            player1.Attack();

            player1 = PlayerForm2.Instance;
            player1.Attack();
        }
    }

    public abstract class AbstractPlayer
    {
        public abstract string Name { get; set; }

        public virtual void Attack()
        {
            Console.WriteLine(Name + " - Attacked!");
        }
    }

    //Singleton for PlayerForm1 "Knight"
    public class PlayerForm1 : AbstractPlayer
    {
        private PlayerForm1() { }

        public override string Name { get; set; } = "Player - Knight";

        private static PlayerForm1 _instance;
        public static PlayerForm1 Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new PlayerForm1();

                return _instance;
            }
        }
    }

    //Singleton for PlayerForm2 "Wizard"
    public class PlayerForm2 : AbstractPlayer
    {
        private PlayerForm2() { }

        public override string Name { get; set; } = "Player - Wizard";

        private static PlayerForm2 _instance;
        public static PlayerForm2 Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new PlayerForm2();

                return _instance;
            }
        }
    }
}

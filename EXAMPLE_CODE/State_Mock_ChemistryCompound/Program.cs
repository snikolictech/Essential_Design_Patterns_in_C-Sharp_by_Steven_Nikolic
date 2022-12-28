using System;


namespace StateCompound
{
    class Program
    {
        static void Main()
        {
            ICompound water = new Water(new Liquid(), 100);
            water.Temp = -1;
            water.Draw();
        }
    }

    /* State Types */
    interface IState
    {
        void StateCheck(ICompound material);
        void Draw(ICompound material);
    }

    class Liquid : IState
    {
        public void StateCheck(ICompound material)
        {
            if (material.Temp <= 0)
                material.State = new Solid();
            else if (material.Temp >= 100)
                material.State = new Gas();
        }

        public void Draw(ICompound material)
        {
            Console.WriteLine("/|/|/|/|/|/|/|/|");
        }
    }

    class Solid : IState
    {
        public void StateCheck(ICompound material)
        {
            if (material.Temp >= 100)
                material.State = new Gas();
            else if (material.Temp > 0)
                material.State = new Liquid();
        }

        public void Draw(ICompound material)
        {
            Console.WriteLine("[][][][][][][][]");
        }
    }

    class Gas : IState
    {
        public void StateCheck(ICompound material)
        {
            if (material.Temp <= 0)
                material.State = new Solid();
            else if (material.Temp < 100)
                material.State = new Liquid();
        }

        public void Draw(ICompound material)
        {
            Console.WriteLine("* * * * *\n  * * * \n    *");
        }
    }


    /* Subject Types */
    interface ICompound
    {
        int Temp { get; set; }
        IState State { get; set; }
        void Draw();
    }

    class Water : ICompound
    {
        public Water(IState state, int temp)
        {
            this.State = state;
            this.Temp = temp;
        }

        public IState State { get; set; }

        private int _temp;
        public int Temp
        {
            get
            {
                return _temp;
            }
            set
            {
                _temp = value;
                StateCheck();
            }
        }

        private void StateCheck()
        {
            State.StateCheck(this);
        }

        public void Draw()
        {
            State.Draw(this);
        }
    }
}
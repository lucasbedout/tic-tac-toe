using System;
using Extensions;

namespace Game
{
    public class Player
    {
        private string _name { get; set; }
        private int score { get; set; }

        public Player(string name)
        {
            _name = name;
            score = 0;
        }

        public void Play(Table tab)
        {
            Console.WriteLine(_name + "'s turn");
            Console.WriteLine("Please enter coordinates of the cell you want to check");
            string input;
            int x, y;

            do
            {
                Console.Write("\nFirst height : ");
                input = Console.ReadLine();
            } while (input == null || !input.ToString().IsInt());

            x = Int32.Parse(input);

            do
            {
                Console.Write("\nThen width : ");
                input = Console.ReadLine();
            } while (input == null || !input.ToString().IsInt());

            y = Int32.Parse(input);

            tab.GameTab[x, y] = 1;

            tab.Print();
        }


    }
}

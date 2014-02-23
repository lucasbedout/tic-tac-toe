using System;
using Game;

namespace MorpionIA
{
    class Program
    {
        static void Main(string[] args)
        {
            var gameTab = new Table(3, 3);
            Player player = new Player("Lucas");
            Computer computer = new Computer();

            gameTab.Print();
            Console.ReadKey();
            var random = new Random();
            int starter = 1;

            for (int i = 0; i < 9; i++)
            {
                if (starter == 0)
                {
                    Console.WriteLine("\nComputer's turn\n");
                    computer.Play(gameTab, i);
                    gameTab.Print();
                    player.Play(gameTab);
                }
                else
                {
                    player.Play(gameTab);
                    Console.WriteLine("\nComputer's turn\n");
                    computer.Play(gameTab, i);
                    gameTab.Print();
                }
            }
        }
    }
}

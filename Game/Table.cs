using System;

namespace Game
{
    public class Table
    {
        private int _height { get; set; }
        private int _width { get; set; }

        public int[,] GameTab;

        public Table(int height, int width)
        {
            _height = height;
            _width = width;
            GameTab = new int[_height, _width];

            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    GameTab[i,j] = 0;
                }
            }
        }

        public void Print()
        {
            for (int i = 0; i < _height; i++)
            {
                Console.Write("|");
                for (int j = 0; j < _width; j++)
                {
                    if (GameTab[i, j] == 0)
                    {
                        Console.Write(" ");
                    }
                    else if (GameTab[i, j] == 1)
                    {
                        Console.Write("x");
                    }
                    else
                    {
                        Console.Write("o");
                    }
                    Console.Write("|");
                }
                Console.WriteLine("\n");
            }
        }
    }
}

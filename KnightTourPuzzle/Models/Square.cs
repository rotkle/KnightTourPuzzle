using System;
namespace KnightTourPuzzle.Models
{
    public class Square
    {
        public int PossitionX { get; set; }
        public int PossitionY { get; set; }

        public Square(int x, int y)
        {
            PossitionX = x;
            PossitionY = y;
        }

        public Square()
        {
        }
    }
}


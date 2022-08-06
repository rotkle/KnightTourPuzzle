using System;
using System.Collections.Generic;
using KnightTourPuzzle.Constants;
using KnightTourPuzzle.KnightTourSolutions;
using KnightTourPuzzle.Utilities;

namespace KnightTourPuzzle
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("The position of a Square on the board contained X (Vertical) value and Y (Horizontal) value");
            Console.Write("Initial X (Vertical) value: ");
            int initialX = int.Parse(Console.ReadLine());
            Console.Write("Initial Y (Horizontal) value: ");
            int initialY = int.Parse(Console.ReadLine());

            if (initialX >= BoardConstants.BOARD_SIZE || initialY >= BoardConstants.BOARD_SIZE)
            {
                Console.WriteLine("X or Y value must be between 0 and 7 (0 <= X,Y <= 7)");
                return;
            }

            List<List<int>> board = Helper.InitialBoardWithStartingPosition(initialX, initialY);

            var sol = new WarnsdorffRuleSolution();

            if (sol.CalculateKnightMoves(initialX, initialY, board))
            {
                Helper.PrintBoard(board);
            }
            else
            {
                Console.WriteLine("Can't found Knight tour solution with initial square ({0}, {1})", initialX, initialY);
            }
        }
    }
}


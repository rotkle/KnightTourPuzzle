using System;
using System.Collections.Generic;
using KnightTourPuzzle.Constants;
using KnightTourPuzzle.Models;

namespace KnightTourPuzzle.Utilities
{
    public static class Helper
    {
        public static List<Square> CalculateNextPossibleMoves(int curX, int curY, List<List<int>> board, int boardSize)
        {
            List<Square> result = new List<Square>();

            /*
             * A Knight can only have up to 8 possible squares to move with any position on the board.
             * We will loop through every move and choose squares base on condition: 
             * - Square must be on the board and Knight never move to that square before
             */

            for (int i = 0; i < BoardConstants.MAXIMUM_POSSIBLE_MOVES_OF_KNIGHT; i++)
            {
                int nextMoveX = 0;
                int nextMoveY = 0;

                // upper left
                if (i < 2)
                {
                    nextMoveX = curX - (i + 1);
                    nextMoveY = curY + (i - 2);
                }
                // upper right
                else if (i >= 2 && i < 4)
                {
                    nextMoveX = curX - (4 - i);
                    nextMoveY = curY + (i - 1);
                }
                // lower right
                else if (i >= 4 && i < 6)
                {
                    nextMoveX = curX + (i - 3);
                    nextMoveY = curY + (6 - i);
                }
                // lower left
                else
                {
                    nextMoveX = curX + (8 - i);
                    nextMoveY = curY - (i - 5);
                }

                // apply condition to choose candidate squares
                if (nextMoveX >= 0 && nextMoveX < boardSize &&
                    nextMoveY >= 0 && nextMoveY < boardSize &&
                    board[nextMoveX][nextMoveY] == -1)
                {
                    result.Add(new Square
                    {
                        PossitionX = nextMoveX,
                        PossitionY = nextMoveY
                    });
                }
            }

            return result;
        }

        public static List<List<int>> InitialBoardWithStartingPosition(int initialX, int initialY)
        {
            List<List<int>> board = new List<List<int>>();

            for (int i = 0; i < BoardConstants.BOARD_SIZE; i++)
            {
                List<int> temp = new List<int>();
                for (int j = 0; j < BoardConstants.BOARD_SIZE; j++)
                {
                    temp.Add(-1);
                }
                board.Add(temp);
            }

            board[initialX][initialY] = 0;

            return board;
        }

        public static void PrintBoard(List<List<int>> board)
        {
            Console.WriteLine("Knight tour solution found with complete board of moves:");

            for (int i = 0; i < BoardConstants.BOARD_SIZE; i++)
            {
                for (int j = 0; j < BoardConstants.BOARD_SIZE; j++)
                {
                    if (j == (BoardConstants.BOARD_SIZE-1))
                    {
                        Console.Write(board[i][j] + "\n");
                    }
                    else
                    {
                        Console.Write(board[i][j] + "\t");
                    }
                }
            }
        }
    }
}


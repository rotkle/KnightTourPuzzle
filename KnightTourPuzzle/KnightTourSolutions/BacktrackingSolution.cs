using System;
using System.Collections.Generic;
using KnightTourPuzzle.Constants;
using KnightTourPuzzle.Models;
using KnightTourPuzzle.Utilities;

namespace KnightTourPuzzle.KnightTourSolutions
{
    public class BacktrackingSolution
    {
        public BacktrackingSolution()
        {
        }

        /// <summary>
        /// This function calculate the Knight Tour using back-tracking algorithm
        /// </summary>
        /// <param name="curX">Current position X (Vertical) of Knight on board</param>
        /// <param name="curY">Current position Y (Horizontal) of Knight on board</param>
        /// <param name="board">Board where Knight make a move on. Default size is 8x8</param>
        /// <param name="moveNumber">Move number at the current position</param>
        /// <returns>A bool indicate whether the Knight tour solution is found or not</returns>
        public bool CalculateKnightMoves(int curX, int curY, List<List<int>> board, int moveNumber)
        {
            // Calculate next possible moves of Knight base on it's current position
            List<Square> possibleSquares = Helper.CalculateNextPossibleMoves(curX, curY, board, board.Count);

            // Solution found -> return result
            if (moveNumber == BoardConstants.TOTAL_SQUARE_OF_BOARD)
            {
                return true;
            }

            // Calculate the board with every next possible moves
            for (int i = 0; i < possibleSquares.Count; i++)
            {
                board[possibleSquares[i].PossitionX][possibleSquares[i].PossitionY] = moveNumber;

                if (CalculateKnightMoves(possibleSquares[i].PossitionX, possibleSquares[i].PossitionY, board, moveNumber + 1))
                {
                    // Solution found in next move -> return true
                    return true;
                }
                else
                {
                    board[possibleSquares[i].PossitionX][possibleSquares[i].PossitionY] = -1;
                }
            }

            // No solution found -> return false
            return false;
        }
    }
}


using System;
using System.Collections.Generic;
using KnightTourPuzzle.Constants;
using KnightTourPuzzle.Models;
using KnightTourPuzzle.Utilities;

namespace KnightTourPuzzle.KnightTourSolutions
{
    public class WarnsdorffRuleSolution
    {
        /// <summary>
        /// This function calculate the Knight Tour using Warnsdorff Rule approach
        /// </summary>
        /// <param name="board">Board where Knight make a move on. Default size is 8x8</param>
        /// <param name="initX">Current position X (Vertical) of Knight on board</param>
        /// <param name="initY">Current position Y (Horizontal) of Knight on board</param>
        /// <returns>A bool indicate whether the Knight tour solution is found or not</returns>
        public bool CalculateKnightMoves(int initX, int initY, List<List<int>> board)
        {
            Square curSquare = new Square(initX, initY);
            Square nextSquare = new Square();

            // Calculate next 63 moves of the Knight
            for (int i = 1; i < (BoardConstants.BOARD_SIZE*BoardConstants.BOARD_SIZE); i++)
            {
                nextSquare = CalculateNextSquare(board, curSquare);

                // No next move found -> return false
                if (nextSquare.PossitionX == -1 || nextSquare.PossitionY == -1)
                {
                    return false;
                }

                board[nextSquare.PossitionX][nextSquare.PossitionY] = i;
                curSquare = nextSquare;
            }

            // Found solution -> return true
            return true;
        }

        private Square CalculateNextSquare(List<List<int>> board, Square curSquare)
        {
            Square result = new Square(-1, -1);
            int fewestOnwardMoves = 7;

            // Get total moves from current square
            var totalMovesOfCurrentSquare = Helper.CalculateNextPossibleMoves(curSquare.PossitionX, curSquare.PossitionY, board);

            // Calculate total On Ward moves of each possible moves
            for (int i = 0; i < totalMovesOfCurrentSquare.Count; i++)
            {
                int tX = totalMovesOfCurrentSquare[i].PossitionX;
                int tY = totalMovesOfCurrentSquare[i].PossitionY;

                int totalMovesOfCurrentCandidate = Helper.CalculateNextPossibleMoves(tX, tY, board).Count;

                // Find the fewest On Ward moves
                if (totalMovesOfCurrentCandidate < fewestOnwardMoves)
                {
                    fewestOnwardMoves = totalMovesOfCurrentCandidate;
                    result.PossitionX = tX;
                    result.PossitionY = tY;
                }
            }

            return result;
        }
    }
}


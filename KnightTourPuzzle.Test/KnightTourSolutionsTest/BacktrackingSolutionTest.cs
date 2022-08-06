using System;
using System.Collections.Generic;
using KnightTourPuzzle.KnightTourSolutions;
using KnightTourPuzzle.Utilities;
using Xunit;

namespace KnightTourPuzzle.Test.KnightTourSolutionsTest
{
    public class BacktrackingSolutionTest
    {
        public BacktrackingSolutionTest()
        {
        }

        public class CalculateKnightMovesTest : BacktrackingSolutionTest
        {
            [Fact]
            public void ShouldReturnTrue_WhenMovesHitMaximumNumberOfSquareOnBoard()
            {
                // Arrage
                int moveNumber = 64;
                var board = Helper.InitialBoardWithStartingPosition(0, 0);
                int initX = 0;
                int initY = 0;

                // Act
                var sol = new BacktrackingSolution();
                var result = sol.CalculateKnightMoves(initX, initY, board, moveNumber);

                // Assert
                Assert.True(result);
            }

            [Fact]
            public void ShouldReturnFalse_WhenNoSolutionFound()
            {
                // Arrage
                int moveNumber = 1;
                var board = new List<List<int>>
                {
                    new List<int>
                    {
                        -1,-1,-1
                    },
                    new List<int>
                    {
                        -1,-1,-1
                    },
                    new List<int>
                    {
                        -1,0,-1
                    }
                };
                int initX = 2;
                int initY = 1;

                // Act
                var sol = new BacktrackingSolution();
                var result = sol.CalculateKnightMoves(initX, initY, board, moveNumber);

                // Assert
                Assert.False(result);
            }

            [Fact]
            public void ShouldReturnTrue_WhenSolutionFound()
            {
                // Arrage
                int moveNumber = 1;
                int initX = 0;
                int initY = 0;
                var board = Helper.InitialBoardWithStartingPosition(initX,initY);

                // Act
                var sol = new BacktrackingSolution();
                var result = sol.CalculateKnightMoves(initX, initY, board, moveNumber);

                // Assert
                Assert.True(result);
            }
        }
    }
}


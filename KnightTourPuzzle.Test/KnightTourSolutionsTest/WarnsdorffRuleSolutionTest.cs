using System;
using System.Collections.Generic;
using KnightTourPuzzle.KnightTourSolutions;
using KnightTourPuzzle.Utilities;
using Xunit;

namespace KnightTourPuzzle.Test.KnightTourSolutionsTest
{
    public class WarnsdorffRuleSolutionTest
    {
        public WarnsdorffRuleSolutionTest()
        {
        }

        public class CalculateKnightMovesTest : WarnsdorffRuleSolutionTest
        {
            [Fact]
            public void ShouldReturnTrue_WhenSolutionFound()
            {
                // Arrange
                int initX = 4;
                int initY = 5;
                var board = Helper.InitialBoardWithStartingPosition(initX, initY);

                // Act
                var sol = new WarnsdorffRuleSolution();
                var result = sol.CalculateKnightMoves(initX, initY, board);

                // Assert
                Assert.True(result);
            }

            [Fact]
            public void ShouldReturnFalse_WhenNoSolutionFound()
            {
                // Arrange
                int initX = 0;
                int initY = 0;
                var board = new List<List<int>>
                {
                    new List<int>
                    {
                        0,-1,-1
                    },
                    new List<int>
                    {
                        -1,-1,-1
                    },
                    new List<int>
                    {
                        -1,-1,-1
                    }
                };

                // Act
                var sol = new WarnsdorffRuleSolution();
                var result = sol.CalculateKnightMoves(initX, initY, board);

                // Assert
                Assert.False(result);
            }
        }
    }
}


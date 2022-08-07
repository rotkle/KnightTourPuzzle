using System;
using System.Collections.Generic;
using KnightTourPuzzle.Constants;
using KnightTourPuzzle.Utilities;
using Xunit;

namespace KnightTourPuzzle.Test.UtilitiesTest
{
    public class HelperTest
    {
        public HelperTest()
        {
        }

        public List<List<int>> InitialBoard()
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

            return board;
        }

        public class CalculateNextPossibleMovesTest : HelperTest
        {
            [Fact]
            public void ShouldReturnUpperLeft()
            {
                // Arrange
                int initX = 4;
                int initY = 1;

                var board = InitialBoard();
                board[2][2] = 0;
                board[3][3] = 0;
                board[5][3] = 0;
                board[6][2] = 0;
                board[6][0] = 0;

                // Act
                var result = Helper.CalculateNextPossibleMoves(initX, initY, board);

                // Assert
                Assert.Single(result);
                Assert.Equal(2, result[0].PossitionX);
                Assert.Equal(0, result[0].PossitionY);
            }

            [Fact]
            public void ShouldReturnUpperRight()
            {
                // Arrange
                int initX = 4;
                int initY = 1;

                var board = InitialBoard();
                board[2][0] = 0;
                board[5][3] = 0;
                board[6][2] = 0;
                board[6][0] = 0;

                // Act
                var result = Helper.CalculateNextPossibleMoves(initX, initY, board);

                // Assert
                Assert.Equal(2, result.Count);
                Assert.Equal(2, result[0].PossitionX);
                Assert.Equal(2, result[0].PossitionY);
                Assert.Equal(3, result[1].PossitionX);
                Assert.Equal(3, result[1].PossitionY);
            }

            [Fact]
            public void ShouldReturnLowerRight()
            {
                // Arrange
                int initX = 4;
                int initY = 1;

                var board = InitialBoard();
                board[2][0] = 0;
                board[2][2] = 0;
                board[3][3] = 0;
                board[6][0] = 0;

                // Act
                var result = Helper.CalculateNextPossibleMoves(initX, initY, board);

                // Assert
                Assert.Equal(2, result.Count);
                Assert.Equal(5, result[0].PossitionX);
                Assert.Equal(3, result[0].PossitionY);
                Assert.Equal(6, result[1].PossitionX);
                Assert.Equal(2, result[1].PossitionY);
            }

            [Fact]
            public void ShouldReturnLowerLeft()
            {
                // Arrange
                int initX = 4;
                int initY = 1;

                var board = InitialBoard();
                board[2][0] = 0;
                board[2][2] = 0;
                board[3][3] = 0;
                board[5][3] = 0;
                board[6][2] = 0;

                // Act
                var result = Helper.CalculateNextPossibleMoves(initX, initY, board);

                // Assert
                Assert.Single(result);
                Assert.Equal(6, result[0].PossitionX);
                Assert.Equal(0, result[0].PossitionY);
            }

            [Fact]
            public void ShouldReturnAllMovesOnBoard()
            {
                // Arrange
                int initX = 4;
                int initY = 1;

                var board = InitialBoard();

                // Act
                var result = Helper.CalculateNextPossibleMoves(initX, initY, board);

                // Assert
                Assert.Equal(6, result.Count);
            }
        }

        public class InitialBoardWithStartingPositionTest : HelperTest
        {
            [Fact]
            public void ShouldReturnBoard_WithInitialSquareSetTo0()
            {
                // Arrange
                int initX = 4;
                int initY = 1;

                // Act
                var result = Helper.InitialBoardWithStartingPosition(initX, initY);

                // Assert
                Assert.Equal(0, result[4][1]);
            }
        }
    }
}


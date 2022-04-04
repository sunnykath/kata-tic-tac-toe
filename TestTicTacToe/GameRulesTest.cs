using System;
using System.Collections.Generic;
using TicTacToe;
using Xunit;

namespace TestTicTacToe
{
    public class GameRulesTest
    {

        public static IEnumerable<object[]> GetInProgressBoards()
        {
            yield return new object[]
            {
                new[,]
                {
                    {1, 2, 1},
                    {0, 0, 0},
                    {0, 0, 0}
                }
            };
            yield return new object[]
            {
                new[,]
                {
                    {0, 1, 0},
                    {0, 1, 0},
                    {0, 2, 0}
                }
            };
            yield return new object[]
            {
                new[,]
                {
                    {2, 0, 0},
                    {0, 1, 0},
                    {0, 0, 1}
                }
            };
            yield return new object[]
            {
                new[,]
                {
                    {0, 0, 1},
                    {0, 2, 0},
                    {1, 0, 0}
                }
            };
        }

        [Theory]
        [MemberData(nameof(GetInProgressBoards))]
        public void Should_Return_False_When_Player_Has_Not_Won_The_Game(int[,] gameInProgressBoard)
        {
            // Act
            var hasWonGame = GameRulesHandler.HasWon(gameInProgressBoard);
        
            // Assert
            Assert.False(hasWonGame);
        }
        
        
        public static IEnumerable<object[]> GetWinningBoards()
        {
            yield return new object[]
            {
                new[,]
                {
                    {1, 1, 1},
                    {0, 0, 0},
                    {0, 0, 0}
                }
            };
            yield return new object[]
            {
                new[,]
                {
                    {0, 1, 0},
                    {0, 1, 0},
                    {0, 1, 0}
                }
            };
            yield return new object[]
            {
                new[,]
                {
                    {1, 0, 0},
                    {0, 1, 0},
                    {0, 0, 1}
                }
            };
            yield return new object[]
            {
                new[,]
                {
                    {0, 0, 1},
                    {0, 1, 0},
                    {1, 0, 0}
                }
            };
        }

        [Theory]
        [MemberData(nameof(GetWinningBoards))]
        public void Should_Return_True_When_Player_Has_Won_The_Game(int[,] gameWonBoard)
        {
            // Act
            var hasWonGame = GameRulesHandler.HasWon(gameWonBoard);
        
            // Assert
            Assert.True(hasWonGame);
        }

        [Fact]
        public void Should_Return_False_When_Checking_For_Draw_With_Empty_Cells()
        {
            // Arrange 
            var gameInProgressBoard = new[,]
            {
                {0, 2, 1},
                {0, 2, 0},
                {1, 1, 0}
            };
        
            // Act
            var hasDrawnGame = GameRulesHandler.HasDrawn(gameInProgressBoard);
        
            // Assert
            Assert.False(hasDrawnGame);
        }

        [Fact]
        public void Should_Return_True_When_Checking_For_Draw_With_No_Empty_Cells()
        {
            // Arrange 
            var gameDrawnBoard = new[,]
            {
                {1, 2, 1},
                {2, 2, 1},
                {1, 1, 2}
            };
        
            // Act
            var hasDrawnGame = GameRulesHandler.HasDrawn(gameDrawnBoard);
        
            // Assert
            Assert.True(hasDrawnGame);
        }


        [Fact]
        public void Should_Return_True_When_A_Duplicate_Move_Is_Made()
        {
            // Arrange 
            var gameBoard = new[,]
            {
                {1, 0, 0},
                {0, 0, 0},
                {0, 0, 0}
            };
            var duplicateMove = new Move(0, 0);
        
            // Act
            var isDuplicateMove = GameRulesHandler.IsADuplicateMove(gameBoard, duplicateMove);
        
            // Assert
            Assert.True(isDuplicateMove);
        }
        
        

    }
}
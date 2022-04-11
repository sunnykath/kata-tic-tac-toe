using System.Collections.Generic;
using TicTacToe;
using TicTacToe.Rules;
using Xunit;

namespace TestTicTacToe
{
    public class GameRulesTest
    {
        private readonly IRules _rules;
        public GameRulesTest()
        {
            _rules = new GameRulesHandler();
        }
        
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
            var isWonGame = _rules.HasWon(gameInProgressBoard);
        
            // Assert
            Assert.False(isWonGame);
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
            var isWonGame = _rules.HasWon(gameWonBoard);
        
            // Assert
            Assert.True(isWonGame);
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
            var hasDrawnGame = _rules.HasDrawn(gameInProgressBoard);
        
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
            var hasDrawnGame = _rules.HasDrawn(gameDrawnBoard);
        
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
            var isDuplicateMove = _rules.IsADuplicateMove(gameBoard, duplicateMove);
        
            // Assert
            Assert.True(isDuplicateMove);
        }
        
        

    }
}
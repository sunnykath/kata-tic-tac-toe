using TicTacToe;
using Xunit;

namespace TestTicTacToe
{
    public class GameRulesTest
    {

        [Fact]
        public void Should_Return_False_When_3_In_A_Row_Horizontally_Of_Different_Players_Marks()
        {
            // Arrange
            var gameLosingBoard = new int[3,3]
            {
                {1, 2, 1},
                {0, 0, 0},
                {0, 0, 0}
            };
        
            // Act
            var hasWonGame = GameRulesHandler.HasWon(gameLosingBoard);
        
            // Assert
            Assert.False(hasWonGame);
        }
        
        
        [Fact]
        public void Should_Return_False_When_3_In_A_Row_Vertically_Of_Different_Players_Marks()
        {
            // Arrange 
            var gameLosingBoard = new int[3,3]
            {
                {0, 1, 0},
                {0, 1, 0},
                {0, 2, 0}
            };       
        
            // Act
            var hasWonGame = GameRulesHandler.HasWon(gameLosingBoard);
        
            // Assert
            Assert.False(hasWonGame);
        }

        
        [Fact]
        public void Should_Return_Won_When_GameStatus_Is_Checked_If_3_In_A_Row_Horizontally()
        {
            // Arrange
            var gameWinningBoard = new int[3,3]
            {
                {1, 1, 1},
                {0, 0, 0},
                {0, 0, 0}
            };
        
            // Act
            var hasWonGame = GameRulesHandler.HasWon(gameWinningBoard);
        
            // Assert
            Assert.True(hasWonGame);
        }
        
        [Fact]
        public void Should_Return_Won_When_GameStatus_Is_Checked_If_3_In_A_Row_Vertically()
        {
            // Arrange 
            var gameWinningBoard = new int[3,3]
            {
                {0, 1, 0},
                {0, 1, 0},
                {0, 1, 0}
            };       
        
            // Act
            var hasWonGame = GameRulesHandler.HasWon(gameWinningBoard);
        
            // Assert
            Assert.True(hasWonGame); 

            
        }
        
        [Fact]
        public void Should_Return_Won_When_GameStatus_Is_Checked_If_3_In_A_Row_Diagonally_As_Forward_Slash()
        {
            // Arrange 
            var gameWinningBoard = new int[3,3]
            {
                {1, 0, 0},
                {0, 1, 0},
                {0, 0, 1}
            };
        
        
            // Act
            var hasWonGame = GameRulesHandler.HasWon(gameWinningBoard);
        
            // Assert
            Assert.True(hasWonGame);
        }
        
        [Fact]
        public void Should_Return_Won_When_GameStatus_Is_Checked_If_3_In_A_Row_Diagonally_As_Backward_Slash()
        {
            // Arrange 
            var gameWinningBoard = new int[3,3]
            {
                {0, 0, 1},
                {0, 1, 0},
                {1, 0, 0}
            };
        
            // Act
            var hasWonGame = GameRulesHandler.HasWon(gameWinningBoard);
        
            // Assert
            Assert.True(hasWonGame);
        }

    }
}
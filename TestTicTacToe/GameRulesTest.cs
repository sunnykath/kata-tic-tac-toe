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
            var gameLosingBoard = new[,]
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
            var gameLosingBoard = new[,]
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
        public void Should_Return_False_When_3_In_A_Row_Diagonally_As_Forward_Slash_Of_Different_Players_Marks()
        {
            // Arrange 
            var gameLosingBoard = new[,]
            {
                {2, 0, 0},
                {0, 1, 0},
                {0, 0, 1}
            };
        
        
            // Act
            var hasWonGame = GameRulesHandler.HasWon(gameLosingBoard);
        
            // Assert
            Assert.False(hasWonGame);
        }
        
        [Fact]
        public void Should_Return_False_When_3_In_A_Row_Diagonally_As_Backward_Slash_Of_Different_Players_Marks()
        {
            // Arrange 
            var gameLosingBoard = new[,]
            {
                {0, 0, 1},
                {0, 2, 0},
                {1, 0, 0}
            };
        
        
            // Act
            var hasWonGame = GameRulesHandler.HasWon(gameLosingBoard);
        
            // Assert
            Assert.False(hasWonGame);
        }
        
        
        [Fact]
        public void Should_Return_True_When_GameStatus_Is_Checked_If_3_In_A_Row_Horizontally()
        {
            // Arrange
            var gameWinningBoard = new[,]
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
        public void Should_Return_True_When_GameStatus_Is_Checked_If_3_In_A_Row_Vertically()
        {
            // Arrange 
            var gameWinningBoard = new[,]
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
        public void Should_Return_True_When_GameStatus_Is_Checked_If_3_In_A_Row_Diagonally_As_Forward_Slash()
        {
            // Arrange 
            var gameWinningBoard = new[,]
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
        public void Should_Return_True_When_GameStatus_Is_Checked_If_3_In_A_Row_Diagonally_As_Backward_Slash()
        {
            // Arrange 
            var gameWinningBoard = new[,]
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
            var gameDrawnBoard = new[,]
            {
                {1, 0, 0},
                {0, 0, 0},
                {0, 0, 0}
            };
            var duplicateMove = new Move(0, 0);
        
            // Act
            var isDuplicateMove = GameRulesHandler.IsADuplicateMove(gameDrawnBoard, duplicateMove);
        
            // Assert
            Assert.True(isDuplicateMove);
        }
        
        

    }
}
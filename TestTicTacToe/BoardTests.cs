using TicTacToe;
using Xunit;

namespace TestTicTacToe
{
    public class BoardTests
    {
        [Fact]
        public void Should_Return_An_Empty_Board_When_A_New_Board_Is_Instantiated()
        {
            // Arrange
            var board = new Board();
            
            var expectedBoard = new[,]
            {
                {0, 0, 0},
                {0, 0, 0},
                {0, 0, 0}
            };
        
            // Act
            var actualBoard = board.GetBoard();
        
            // Assert
            Assert.Equal(expectedBoard, actualBoard);
        }
        
        [Fact]
        public void Should_Place_Marker_In_The_Correct_Position()
        {
            // Arrange 
            var board = new Board();
            var move = new Move(1 - Constants.IndexingAdjustment, 1 - Constants.IndexingAdjustment);
            
            var expectedBoard = new[,]
            {
                {1, 0, 0},
                {0, 0, 0},
                {0, 0, 0}
            };
        
            // Act
            board.PlaceMarker(move, 1);
            var actualBoard = board.GetBoard();
        
            // Assert
            Assert.Equal(expectedBoard, actualBoard);
        }

        [Fact]
        public void Should_Reset_The_Board_Back_To_Its_Initial_State()
        {
            // Arrange 
            var board = new Board();
            var firstMove = new Move(1 - Constants.IndexingAdjustment, 1 - Constants.IndexingAdjustment);
            var secondMove = new Move(1 - Constants.IndexingAdjustment, 2 - Constants.IndexingAdjustment);
            
            var expectedBoardBeforeReset = new[,]
            {
                {1, 2, 0},
                {0, 0, 0},
                {0, 0, 0}
            };
            
            var expectedBoardAfterReset = new[,]
            {
                {0, 0, 0},
                {0, 0, 0},
                {0, 0, 0}
            };

            // Act
            board.PlaceMarker(firstMove, 1);    
            board.PlaceMarker(secondMove, 2);    
            var actualBoardBeforeReset = board.GetBoard();
            board.ResetBoard();
            var actualBoardAfterReset = board.GetBoard();
        
            // Assert
            Assert.Equal(expectedBoardBeforeReset, actualBoardBeforeReset);
            Assert.Equal(expectedBoardAfterReset, actualBoardAfterReset);
        }
        
    }
}
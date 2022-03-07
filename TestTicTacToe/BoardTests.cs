using TicTacToe;
using Xunit;

namespace TestTicTacToe
{
    public class BoardTests
    {
        [Fact]
        public void Should_Place_Marker_In_The_Correct_Position_If_Empty_Cell()
        {
            // Arrange 
            var board = new Board();
            var move = new Move(1, 1, 1);
            
            var expectedBoard = new int[3,3]
            {
                {1, 0, 0},
                {0, 0, 0},
                {0, 0, 0}
            };

            // Act
            var success = board.PlaceMarker(move);
            var actualBoard = board.GetBoard();
        
            // Assert
            Assert.True(success);
            Assert.Equal(expectedBoard, actualBoard);
        }
        
        
        [Fact]
        public void Should_Not_Place_Marker_In_The_Position_If_Cell_Not_Empty()
        {
            // Arrange 
            var board = new Board();
            var firstMove = new Move(1, 1, 1);
            var secondMove = new Move(1, 1, 2);
            
            var expectedBoard = new int[3,3]
            {
                {1, 0, 0},
                {0, 0, 0},
                {0, 0, 0}
            };

            // Act
            board.PlaceMarker(firstMove);    
            var success = board.PlaceMarker(secondMove);    
            var actualBoard = board.GetBoard();
        
            // Assert
            Assert.False(success);
            Assert.Equal(expectedBoard, actualBoard);
        }
        
        
        [Fact]
        public void Should_Reset_The_Board_Back_To_Its_Initial_State()
        {
            // Arrange 
            var board = new Board();
            var firstMove = new Move(1, 1, 1);
            var secondMove = new Move(1, 2, 2);
            
            var expectedBoardBeforeReset = new int[3,3]
            {
                {1, 2, 0},
                {0, 0, 0},
                {0, 0, 0}
            };
            
            var expectedBoardAfterReset = new int[3,3]
            {
                {0, 0, 0},
                {0, 0, 0},
                {0, 0, 0}
            };

            // Act
            var firstMoveSuccess = board.PlaceMarker(firstMove);    
            var secondMoveSuccess = board.PlaceMarker(secondMove);    
            var actualBoardBeforeReset = board.GetBoard();
            board.ResetBoard();
            var actualBoardAfterReset = board.GetBoard();
        
            // Assert
            Assert.True(firstMoveSuccess);
            Assert.True(secondMoveSuccess);
            Assert.Equal(expectedBoardBeforeReset, actualBoardBeforeReset);
            Assert.Equal(expectedBoardAfterReset, actualBoardAfterReset);
        }
    }
}
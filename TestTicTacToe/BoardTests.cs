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
            var move = new Move(1, 1);
            
            var expectedBoard = new int[3,3]
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
            var firstMove = new Move(1, 1);
            var secondMove = new Move(1, 2);
            
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
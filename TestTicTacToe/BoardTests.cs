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
    }
}
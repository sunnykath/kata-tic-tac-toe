using TicTacToe;
using Xunit;

namespace TestTicTacToe
{
    public class GamePlayTests
    {

        [Fact]
        public void Should_Change_Player_When_SwapPlayer_Is_Called()
        {
            // Arrange 
            var game = new GameLoop();
            
            // Act
            var initialPlayer = game.GetPlayer();
            game.SwapPlayer();
            var swappedPlayer = game.GetPlayer();

            // Assert 
            Assert.NotEqual(initialPlayer, swappedPlayer);

        }

        [Fact]
        public void Should_Change_Player_To_The_Initial_Player_When_SwapPlayer_Is_Called_Twice()
        {
            // Arrange 
            var game = new GameLoop();
            
            // Act
            var initialPlayer = game.GetPlayer();
            game.SwapPlayer();
            game.SwapPlayer();
            var swappedPlayer = game.GetPlayer();

            // Assert 
            Assert.Equal(initialPlayer, swappedPlayer);

        }

        
        
        
        
    }
}
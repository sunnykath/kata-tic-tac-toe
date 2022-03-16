using TicTacToe;
using Xunit;

namespace TestTicTacToe
{
    public class GamePlayTests
    {


        [Fact]
        public void Should_Change_Player_When_SwapPlayer_IS_Called()
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
        
        
        
        
        
    }
}
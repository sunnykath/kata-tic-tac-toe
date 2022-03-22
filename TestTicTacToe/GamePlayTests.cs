using System;
using System.IO;
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
            var game = new GamePlay();
            
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
            var game = new GamePlay();
            
            // Act
            var initialPlayer = game.GetPlayer();
            game.SwapPlayer();
            game.SwapPlayer();
            var swappedPlayer = game.GetPlayer();

            // Assert 
            Assert.Equal(initialPlayer, swappedPlayer);

        }

        
        [Fact]
        public void Should_End_Game_When_PLayer_Inputs_Quit_Command()
        {
            // Arrange
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);
            
            var stringReader = new StringReader("q");
            Console.SetIn(stringReader);

            var game = new GamePlay();
            
            // Act
            game.Play();
            var actualString = stringWriter.ToString();
            
            // Assert
            Assert.True(actualString.Contains(Constants.GameQuitMessage));
        }

    }
}
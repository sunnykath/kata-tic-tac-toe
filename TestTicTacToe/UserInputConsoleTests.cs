using System;
using System.IO;
using TicTacToe;
using Xunit;

namespace TestTicTacToe
{
    public class UserInputConsoleTests
    {

        [Fact]
        public void Should_Ask_For_Input_Again_When_Invalid_Input_Is_Given_For_The_Players_Move()
        {
            // Arrange
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            var stringReader = new StringReader("1 1\n1,1");
            Console.SetIn(stringReader);
            
            var uiConsole = new UserInputConsole();
            var player = Constants.PlayerO;
            
            // Act
            uiConsole.UpdatePlayerInput(player);
            var actualString = stringWriter.ToString();
            
            // Assert
            Assert.True(actualString.Contains(Constants.InvalidInputErrorMessage));
            
        }
        
        [Fact]
        public void Should_Return_The_Move_When_Valid_Move_Input_Is_Given()
        {
            
            // Arrange
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);
            
            var stringReader = new StringReader("1,2");
            Console.SetIn(stringReader);

            var expectedMove = new Move(1, 2);
            
            var uiConsole = new UserInputConsole();

            var player = Constants.PlayerO;
            
            // Act
            uiConsole.UpdatePlayerInput(player);
            var actualMove = uiConsole.GetPlayerMove();
            var actualString = stringWriter.ToString();
            
            // Assert
            Assert.True(actualString.Contains(Constants.MoveAcceptedMessage));
            Assert.Equal(expectedMove, actualMove);
            
        }
        
        [Fact]
        public void Should_Return_True_For_Given_Up_When_Player_Inputs_Q()
        {
            // Arrange
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);
            
            var stringReader = new StringReader("q");
            Console.SetIn(stringReader);

            var uiConsole = new UserInputConsole();

            var player = Constants.PlayerO;
            
            // Act
            uiConsole.UpdatePlayerInput(player);
            var hasGivenUp = uiConsole.PlayerHasGivenUp();
            var actualString = stringWriter.ToString();
            
            // Assert
            Assert.True(actualString.Contains(Constants.GameQuitMessage));
            Assert.True(hasGivenUp);
            
        }

        [Fact]
        public void Should_Accept_The_Quit_Command_After_An_Invalid_Move()
        {
            // Arrange
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);
            
            var stringReader = new StringReader("1 1\nq");
            Console.SetIn(stringReader);

            var uiConsole = new UserInputConsole();

            var player = Constants.PlayerO;
            
            // Act
            uiConsole.UpdatePlayerInput(player);
            var hasGivenUp = uiConsole.PlayerHasGivenUp();
            var actualString = stringWriter.ToString();
            
            // Assert
            Assert.True(actualString.Contains(Constants.GameQuitMessage));
            Assert.True(hasGivenUp);
        }
    }
}
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

            const string expectedStringContains = "Invalid Input, please try again: ";
            
            var stringReader = new StringReader("1 1\n1,1");
            Console.SetIn(stringReader);
            
            var uiConsole = new UserInputConsole();
            
            // Act
            uiConsole.GetPlayerMove(1);
            var actualString = stringWriter.ToString();
            
            // Assert
            Assert.True(actualString.Contains(expectedStringContains));
            
        }
        
        [Fact]
        public void Should_Return_The_Move_When_Valid_Move_Input_Is_Given()
        {
            
            // Arrange
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            var expectedStringContains = "Move accepted";
            
            var stringReader = new StringReader("1,2");
            Console.SetIn(stringReader);

            var expectedMove = new Move(1, 2);
            
            var uiConsole = new UserInputConsole();
            
            // Act
            var actualMove = uiConsole.GetPlayerMove(1);
            var actualString = stringWriter.ToString();
            
            // Assert
            Assert.True(actualString.Contains(expectedStringContains));
            Assert.Equal(expectedMove, actualMove);
            
        }
        
        
    }
}
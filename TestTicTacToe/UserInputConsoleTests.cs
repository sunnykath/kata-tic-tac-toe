using System;
using System.IO;
using TicTacToe;
using TicTacToe.UserInput;
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
            uiConsole.UpdatePlayerInput(player.value);
            var actualString = stringWriter.ToString();
            
            // Assert
            Assert.Contains(Constants.InvalidInputErrorMessage, actualString);
            
        }
        
        [Fact]
        public void Should_Return_The_Move_When_Valid_Move_Input_Is_Given()
        {
            
            // Arrange
            var stringReader = new StringReader("1,2");
            Console.SetIn(stringReader);

            var expectedMove = new Move(1 - Constants.IndexingAdjustment, 2 - Constants.IndexingAdjustment);
            
            var uiConsole = new UserInputConsole();

            var player = Constants.PlayerO;
            
            // Act
            uiConsole.UpdatePlayerInput(player.value);
            var actualMove = uiConsole.GetPlayerMove();
            
            // Assert
            Assert.Equal(expectedMove, actualMove);
            
        }
        
        [Fact]
        public void Should_Return_True_For_Given_Up_When_Player_Inputs_Q()
        {
            // Arrange
            var stringReader = new StringReader("q");
            Console.SetIn(stringReader);

            var uiConsole = new UserInputConsole();

            var player = Constants.PlayerO;
            
            // Act
            uiConsole.UpdatePlayerInput(player.value);
            var hasGivenUp = uiConsole.PlayerHasGivenUp();
            
            // Assert
            Assert.True(hasGivenUp);
            
        }

        [Fact]
        public void Should_Accept_The_Quit_Command_After_An_Invalid_Move()
        {
            // Arrange
            var stringReader = new StringReader("1 1\nq");
            Console.SetIn(stringReader);

            var uiConsole = new UserInputConsole();

            var player = Constants.PlayerO;
            
            // Act
            uiConsole.UpdatePlayerInput(player.value);
            var hasGivenUp = uiConsole.PlayerHasGivenUp();
            
            // Assert
            Assert.True(hasGivenUp);
        }

        [Fact]
        public void Should_Print_An_Empty_Board_With_Dots_Representing_Empty_Cells_And_Board_Printing_Message_When_OutputBoard_Is_called()
        {
            // Arrange
            // Arrange
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            var emptyBoard = new int[3,3]
            {
                {0, 0, 0},
                {0, 0, 0},
                {0, 0, 0}
            };

            const string expectedBoardOutput = ". . . \n. . . \n. . . \n";
    
            var uiConsole = new UserInputConsole();

            // Act
            uiConsole.OutputBoard(emptyBoard);
            var actualBoardOutput = stringWriter.ToString();
    
            // Assert
            Assert.Contains(Constants.BoardPrintedMessage, actualBoardOutput);
            Assert.Contains(expectedBoardOutput, actualBoardOutput);
        }
        
        [Fact]
        public void Should_Print_The_Board_With_Player_Marks_And_Board_Printing_Message_When_OutputBoard_Is_called()
        {
            // Arrange
            // Arrange
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            var emptyBoard = new int[3,3]
            {
                {1, 0, 0},
                {0, 0, 2},
                {1, 0, 2}
            };

            const string expectedBoardOutput = "X . . \n. . O \nX . O \n";
    
            var uiConsole = new UserInputConsole();

            // Act
            uiConsole.OutputBoard(emptyBoard);
            var actualBoardOutput = stringWriter.ToString();
    
            // Assert
            Assert.Contains(Constants.BoardPrintedMessage, actualBoardOutput);
            Assert.Contains(expectedBoardOutput, actualBoardOutput);
        }
    }
}
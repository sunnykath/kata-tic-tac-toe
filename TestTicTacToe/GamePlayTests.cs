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
            var expectedGameStatus = GameStatus.Quit;
            
            // Act
            game.Play();
            var actualString = stringWriter.ToString();
            var actualGameStatus = game.GetCurrentStatus();
            
            // Assert
            Assert.True(actualString.Contains(Constants.GameQuitMessage));
            Assert.Equal(expectedGameStatus, actualGameStatus);
        }
        
        [Fact]
        public void Should_Update_The_Board_With_The_Player_Move_Input_And_Output_A_Move_Accepted_Message()
        {
            // Arrange
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);
            
            var stringReader = new StringReader("1,1\nq");
            Console.SetIn(stringReader);

            var game = new GamePlay();
            var player = game.GetPlayer();
            var expectedBoard = new int[3,3]
            {
                {player, 0, 0},
                {0, 0, 0},
                {0, 0, 0}
            };
            
            // Act
            game.Play();
            var actualString = stringWriter.ToString();
            var actualBoard = game.GetBoard();
            
            // Assert
            Assert.True(actualString.Contains(Constants.MoveAcceptedMessage));
            Assert.Equal(expectedBoard, actualBoard);
        }
        
        [Fact]
        public void Should_Update_The_Board_With_Two_Player_Move_Inputs_And_Swap_Players_In_Between_Moves()
        {
            // Arrange
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);
            
            var stringReader = new StringReader("1,1\n1,2\nq");
            Console.SetIn(stringReader);

            var game = new GamePlay();
            var player = game.GetPlayer();
            var otherPlayer = player == Constants.PlayerO ? Constants.PlayerX : Constants.PlayerO;
            var expectedBoard = new int[3,3]
            {
                {player, otherPlayer, 0},
                {0, 0, 0},
                {0, 0, 0}
            };
            
            // Act
            game.Play();
            var actualString = stringWriter.ToString();
            var actualBoard = game.GetBoard();
            
            // Assert
            Assert.Equal(expectedBoard, actualBoard);
        }

        [Fact]
        public void Should_Not_Update_The_Board_With_The_Player_Move_Input_If_A_Duplicate_Move_Is_Entered_And_Output_A_Duplicate_Move_Message()
        {
            // Arrange
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);
    
            var stringReader = new StringReader("1,1\n1,1\nq");
            Console.SetIn(stringReader);

            var game = new GamePlay();
            var player = game.GetPlayer();
            var expectedBoard = new int[3,3]
            {
                {player, 0, 0},
                {0, 0, 0},
                {0, 0, 0}
            };
    
            // Act
            game.Play();
            var actualString = stringWriter.ToString();
            var actualBoard = game.GetBoard();
    
            // Assert
            Assert.True(actualString.Contains(Constants.DuplicateMoveMessage));
            Assert.Equal(expectedBoard, actualBoard);
        }
        
        [Fact]
        public void Should_Change_GameStatus_To_Won_When_3_In_A_Row_For_A_Player()
        {
            // Arrange
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);
    
            var stringReader = new StringReader("1,1\n1,2\n2,1\n2,2\n3,1\nq");
            Console.SetIn(stringReader);

            var game = new GamePlay();
            var player = game.GetPlayer();
            var otherPlayer = player == Constants.PlayerO ? Constants.PlayerX : Constants.PlayerO;
            
            var expectedBoard = new int[3,3]
            {
                {player, otherPlayer, 0},
                {player, otherPlayer, 0},
                {player, 0, 0}
            };
            
            var expectedGameStatus = GameStatus.Won;
    
            // Act
            game.Play();
            var actualString = stringWriter.ToString();
            var actualBoard = game.GetBoard();
            var actualGameStatus = game.GetCurrentStatus();
    
            // Assert
            Assert.True(actualString.Contains(Constants.GameWonMessage));
            Assert.Equal(expectedGameStatus, actualGameStatus);
            Assert.Equal(expectedBoard, actualBoard);
        }
    }
}
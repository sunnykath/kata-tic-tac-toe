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
            Assert.Contains(Constants.GameQuitMessage, actualString);
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
            var expectedBoard = new [,]
            {
                {player, 0, 0},
                {0, 0, 0},
                {0, 0, 0}
            };
            
            // Act
            game.Play();
            var actualString = stringWriter.ToString();
            var actualBoard = game.GetBoardArray();
            
            // Assert
            Assert.Contains(Constants.MoveAcceptedMessage, actualString);
            Assert.Equal(expectedBoard, actualBoard);
        }
        
        [Fact]
        public void Should_Update_The_Board_With_Two_Player_Move_Inputs_And_Swap_Players_In_Between_Moves()
        {
            // Arrange
            var stringReader = new StringReader("1,1\n1,2\nq");
            Console.SetIn(stringReader);

            var game = new GamePlay();
            var player = game.GetPlayer();
            var otherPlayer = player == Constants.PlayerOValue ? Constants.PlayerXValue : Constants.PlayerOValue;
            var expectedBoard = new[,]
            {
                {player, otherPlayer, 0},
                {0, 0, 0},
                {0, 0, 0}
            };
            
            // Act
            game.Play();
            var actualBoard = game.GetBoardArray();
            
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
            var expectedBoard = new[,]
            {
                {player, 0, 0},
                {0, 0, 0},
                {0, 0, 0}
            };
    
            // Act
            game.Play();
            var actualString = stringWriter.ToString();
            var actualBoard = game.GetBoardArray();
    
            // Assert
            Assert.Contains(Constants.DuplicateMoveMessage, actualString);
            Assert.Equal(expectedBoard, actualBoard);
        }
        
        [Fact]
        public void Should_Change_GameStatus_To_Won_When_3_In_A_Row_For_A_Player_And_Output_The_Winning_Message()
        {
            // Arrange
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);
    
            var stringReader = new StringReader("1,1\n1,2\n2,1\n2,2\n3,1\n");
            Console.SetIn(stringReader);

            var game = new GamePlay();
            var player = game.GetPlayer();
            var otherPlayer = player == Constants.PlayerOValue ? Constants.PlayerXValue : Constants.PlayerOValue;
            
            var expectedBoard = new [,]
            {
                {player, otherPlayer, 0},
                {player, otherPlayer, 0},
                {player, 0, 0}
            };
            
            var expectedGameStatus = GameStatus.Won;
    
            // Act
            game.Play();
            var actualString = stringWriter.ToString();
            var actualBoard = game.GetBoardArray();
            var actualGameStatus = game.GetCurrentStatus();
    
            // Assert
            Assert.Contains(Constants.GameWonMessage, actualString);
            Assert.Equal(expectedBoard, actualBoard);
            Assert.Equal(expectedGameStatus, actualGameStatus);
        }
        
        [Fact]
        public void Should_Change_GameStatus_To_Draw_When_No_More_Empty_Cells_And_Output_The_Game_Drawn_Message()
        {
            // Arrange
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);
    
            var stringReader = new StringReader("1,1\n1,2\n1,3\n2,1\n2,3\n2,2\n3,1\n3,3\n3,2\n");
            Console.SetIn(stringReader);

            var game = new GamePlay();
            var player = game.GetPlayer();
            var otherPlayer = player == Constants.PlayerOValue ? Constants.PlayerXValue : Constants.PlayerOValue;
            
            var expectedBoard = new [,]
            {
                {player,        otherPlayer,    player},
                {otherPlayer,   otherPlayer,    player},
                {player,        player,         otherPlayer}
            };
            
            var expectedGameStatus = GameStatus.Draw;
    
            // Act
            game.Play();
            var actualString = stringWriter.ToString();
            var actualBoard = game.GetBoardArray();
            var actualGameStatus = game.GetCurrentStatus();
    
            // Assert
            Assert.Contains(Constants.GameDrawnMessage, actualString);
            Assert.Equal(expectedBoard, actualBoard);
            Assert.Equal(expectedGameStatus, actualGameStatus);
        }
        
        [Fact]
        public void Should_Print_The_Updated_Board_While_The_Player_Is_Inputting_Moves()
        {
            // Arrange
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);
            
            var stringReader = new StringReader("1,1\n1,2\nq");
            Console.SetIn(stringReader);

            var game = new GamePlay();
            var player = game.GetPlayer();
            var otherPlayer = player == Constants.PlayerOValue ? Constants.PlayerXValue : Constants.PlayerOValue;
            var expectedBoard = new[,]
            {
                {player, otherPlayer, 0},
                {0, 0, 0},
                {0, 0, 0}
            };
            
            const string expectedBoardOutputBeforeFirstMove = ". . . \n. . . \n. . . \n";
            const string expectedBoardOutputAfterFirstMove = "X . . \n. . . \n. . . \n";
            const string expectedBoardOutputAfterSecondMove = "X O . \n. . . \n. . . \n";
            
            // Act
            game.Play();
            var actualBoard = game.GetBoardArray();
            var actualBoardOutputs = stringWriter.ToString();

            // Assert
            Assert.Equal(expectedBoard, actualBoard);
            Assert.Contains(expectedBoardOutputBeforeFirstMove, actualBoardOutputs);
            Assert.Contains(expectedBoardOutputAfterFirstMove, actualBoardOutputs);
            Assert.Contains(expectedBoardOutputAfterSecondMove, actualBoardOutputs);
        }
        
        [Fact]
        public void Should_Print_The_Final_Board_After_The_Game_Ends()
        {
            // Arrange
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);
            
            var stringReader = new StringReader("1,1\n1,2\n2,1\n2,2\n3,1\n");
            Console.SetIn(stringReader);

            var game = new GamePlay();
            var player = game.GetPlayer();
            var otherPlayer = player == Constants.PlayerOValue ? Constants.PlayerXValue : Constants.PlayerOValue;
            var expectedBoard = new [,]
            {
                {player, otherPlayer, 0},
                {player, otherPlayer, 0},
                {player, 0, 0}
            };

            const string expectedBoardOutputAfterWinning = "X O . \nX O . \nX . . \n";
            
            // Act
            game.Play();
            var actualBoard = game.GetBoardArray();
            var actualBoardOutputs = stringWriter.ToString();

            // Assert
            Assert.Equal(expectedBoard, actualBoard);
            Assert.Contains(expectedBoardOutputAfterWinning, actualBoardOutputs);
        }
    }
}
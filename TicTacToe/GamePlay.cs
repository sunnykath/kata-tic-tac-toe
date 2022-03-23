using System;
using TicTacToe.UserInput;

namespace TicTacToe
{
    public class GamePlay
    {
        private int _player;
        private GameStatus _gameStatus;
        private Board _board;
        
        public GamePlay()
        {
            _board = new Board();
            _player = RandomlyPickPlayerForFirst();
        }

        public void Play()
        {
            var uiConsole = new UserInputConsole();
            // Get Player Input
            uiConsole.UpdatePlayerInput(_player);

            // Check if quit
            _gameStatus = uiConsole.PlayerHasGivenUp() ? GameStatus.Quit : CheckGameStatus();

            // Output some message feedback
            if (_gameStatus == GameStatus.Quit)
            {
                uiConsole.OutputMessage(Constants.GameQuitMessage);
            }
        }
        
        public int GetPlayer()
        {
            return _player;
        }
        
        private static int RandomlyPickPlayerForFirst()
        {
            var rand = new Random();
            return rand.Next(Constants.PlayerX, Constants.PlayerO);
        }
        public void SwapPlayer()
        {
            _player = _player == Constants.PlayerX ? Constants.PlayerO : Constants.PlayerX;
        }

        private void Completed()
        {
            
        }

        private void GiveUp()
        {
            
        }

        private void Reset()
        {
            
        }

        private void End()
        {
            
        }


        private GameStatus CheckGameStatus()   
        {
            var boardArray = _board.GetBoard();
            _gameStatus = GameRulesHandler.HasWon(boardArray) ? GameStatus.Won : (GameRulesHandler.HasDrawn(boardArray) ? GameStatus.Draw : GameStatus.Playing);
            
            return _gameStatus;
        }


        public GameStatus GetCurrentStatus()
        {
            return _gameStatus;
        }
    }
}
using System;
using TicTacToe.UserInput;

namespace TicTacToe
{
    public class GamePlay
    {
        private int _player;
        private GameStatus _gameStatus;
        private Board _board;
        private int[,] _boardArray;
        
        public GamePlay()
        {
            _board = new Board();
            _boardArray = _board.GetBoard();
            _player = RandomlyPickPlayerForFirst();
        }

        public void Play()
        {
            var uiConsole = new UserInputConsole();

            while (_gameStatus != GameStatus.Quit)
            {
                // Get Player Input
                uiConsole.UpdatePlayerInput(_player);

                // Check if quit
                _gameStatus = uiConsole.PlayerHasGivenUp() ? GameStatus.Quit : CheckGameStatus();
            
                if (_gameStatus == GameStatus.Quit)
                {
                    uiConsole.OutputMessage(Constants.GameQuitMessage);
                }
                else
                {
                    var inputMove = uiConsole.GetPlayerMove();
                    if (GameRulesHandler.IsADuplicateMove(_boardArray, inputMove))
                    {
                        uiConsole.OutputMessage(Constants.DuplicateMoveMessage);
                    }
                    else
                    {
                        _board.PlaceMarker(inputMove, _player);
                        uiConsole.OutputMessage(Constants.MoveAcceptedMessage);   
                    }
                }
                SwapPlayer();
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
            _gameStatus = GameRulesHandler.HasWon(_boardArray) ? GameStatus.Won : (GameRulesHandler.HasDrawn(_boardArray) ? GameStatus.Draw : GameStatus.Playing);
            
            return _gameStatus;
        }


        public GameStatus GetCurrentStatus()
        {
            return _gameStatus;
        }

        public int[,] GetBoard()
        {
            return _boardArray;
        }
    }
}
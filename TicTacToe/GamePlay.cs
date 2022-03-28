using System;

namespace TicTacToe
{
    public class GamePlay
    {
        private int _player;
        private GameStatus _gameStatus;
        private readonly Board _board;
        private readonly int[,] _boardArray;
        private bool _givenUp;
        
        public GamePlay()
        {
            _board = new Board();
            _boardArray = _board.GetBoard();
            _player = RandomlyPickPlayerForFirst();
            _givenUp = false;
            _gameStatus = GameStatus.Playing;
        }

        public void Play()
        {
            var uiConsole = new UserInputConsole();
            while (_gameStatus is GameStatus.Playing)
            {
                uiConsole.OutputBoard(_boardArray);
                uiConsole.UpdatePlayerInput(_player);
                if (uiConsole.PlayerHasGivenUp())
                {
                    _givenUp = true;
                }
                else
                {
                    var inputMove = uiConsole.GetPlayerMove();
                    string outputMessage = HandleMoveInput(inputMove);
                    uiConsole.OutputMessage(outputMessage);
                }
                UpdateGameStatus();
            }
            var finalMessage = HandleEndOfGame();
            uiConsole.OutputMessage(finalMessage);
            uiConsole.OutputBoard(_boardArray);
        }
        
        public int GetPlayer()
        {
            return _player;
        }
        
        public void SwapPlayer()
        {
            _player = _player == Constants.PlayerXValue ? Constants.PlayerOValue : Constants.PlayerXValue;
        }
        
        public GameStatus GetCurrentStatus()
        {
            return _gameStatus;
        }

        public int[,] GetBoardArray()
        {
            return _boardArray;
        }
        
        private string HandleEndOfGame()
        {
            var message = _gameStatus switch
            {
                GameStatus.Quit => (Constants.GameQuitMessage),
                GameStatus.Won => (Constants.GameWonMessage),
                GameStatus.Draw => (Constants.GameDrawnMessage),
                _ => throw new ArgumentOutOfRangeException()
            };
            return message;
        }

        private string HandleMoveInput(Move inputMove)
        {
            if (GameRulesHandler.IsADuplicateMove(_boardArray, inputMove))
            {
                return Constants.DuplicateMoveMessage;
            }
            _board.PlaceMarker(inputMove, _player);
            SwapPlayer();
            return Constants.MoveAcceptedMessage;
        }
        
        private static int RandomlyPickPlayerForFirst()
        {
            var rand = new Random();
            return rand.Next(Constants.PlayerXValue, Constants.PlayerOValue);
        }
        
        private void UpdateGameStatus()   
        {
            _gameStatus = GameRulesHandler.HasWon(_boardArray) ? GameStatus.Won : (GameRulesHandler.HasDrawn(_boardArray) ? GameStatus.Draw : (_givenUp ? GameStatus.Quit : GameStatus.Playing));
        }
    }
}
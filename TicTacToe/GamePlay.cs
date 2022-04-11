using System;
using TicTacToe.Rules;

namespace TicTacToe
{
    public class GamePlay
    {
        private int _player;
        private GameStatus _gameStatus;
        private readonly Board _board;
        private readonly int[,] _boardArray;
        private bool _givenUp;
        private readonly UserInputConsole _uiConsole;
        private readonly IRules _rules;
        
        public GamePlay(UserInputConsole uiConsole, IRules rules)
        {
            _board = new Board();
            _boardArray = _board.GetBoard();
            _player = Constants.PlayerXValue;
            _givenUp = false;
            _gameStatus = GameStatus.Playing;
            _uiConsole = uiConsole;
            _rules = rules;
        }

        //@Improvement: Simplify this function by moving most of the logic to the rules handler 
        public void Play()
        {
            while (_gameStatus is GameStatus.Playing)
            {
                _uiConsole.OutputBoard(_boardArray);
                _uiConsole.UpdatePlayerInput(_player);
                if (_uiConsole.PlayerHasGivenUp())
                {
                    _givenUp = true;
                }
                else
                {
                    var inputMove = _uiConsole.GetPlayerMove();
                    string outputMessage = HandleMoveInput(inputMove);
                    _uiConsole.OutputMessage(outputMessage);
                }
                UpdateGameStatus();
            }
            var finalMessage = HandleEndOfGame();
            _uiConsole.OutputMessage(finalMessage);
            _uiConsole.OutputBoard(_boardArray);
        }
        
        public int GetCurrentPlayer()
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
            if (_rules.IsADuplicateMove(_boardArray, inputMove))
            {
                return Constants.DuplicateMoveMessage;
            }
            _board.PlaceMarker(inputMove, _player);
            SwapPlayer();
            return Constants.MoveAcceptedMessage;
        }
        
        private void UpdateGameStatus()   
        {
            _gameStatus = _rules.HasWon(_boardArray) ? GameStatus.Won : (_rules.HasDrawn(_boardArray) ? GameStatus.Draw : (_givenUp ? GameStatus.Quit : GameStatus.Playing));
        }
    }
}
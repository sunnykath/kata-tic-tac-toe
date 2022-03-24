using System;
using TicTacToe.UserInput;

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

            switch (_gameStatus)
            {
                case GameStatus.Quit:
                    uiConsole.OutputMessage(Constants.GameQuitMessage);
                    break;
                case GameStatus.Won:
                    uiConsole.OutputMessage(Constants.GameWonMessage);
                    break;
                case GameStatus.Draw:
                    uiConsole.OutputMessage(Constants.GameDrawnMessage);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            uiConsole.OutputBoard(_boardArray);

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
        
        public int GetPlayer()
        {
            return _player;
        }
        
        private static int RandomlyPickPlayerForFirst()
        {
            var rand = new Random();
            return rand.Next(Constants.PlayerX.value, Constants.PlayerO.value);
        }
        public void SwapPlayer()
        {
            _player = _player == Constants.PlayerX.value ? Constants.PlayerO.value : Constants.PlayerX.value;
        }
        
        private void UpdateGameStatus()   
        {
            _gameStatus = GameRulesHandler.HasWon(_boardArray) ? GameStatus.Won : (GameRulesHandler.HasDrawn(_boardArray) ? GameStatus.Draw : (_givenUp ? GameStatus.Quit : GameStatus.Playing));
            
        }
        
        public GameStatus GetCurrentStatus()
        {
            return _gameStatus;
        }

        public int[,] GetBoardArray()
        {
            return _boardArray;
        }
    }
}
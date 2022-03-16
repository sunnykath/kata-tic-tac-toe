using System;

namespace TicTacToe
{
    public class GameLoop
    {
        private int _playerTurn;
        private GameStatus _gameStatus;
        private Board _board;
        
        public GameLoop()
        {
            _board = new Board();
            _playerTurn = RandomlyPickPlayerForFirst();
        }


        public void Play()
        {
            
        }
        
        public int GetPlayer()
        {
            return _playerTurn;
        }
        
        private static int RandomlyPickPlayerForFirst()
        {
            var rand = new Random();
            return rand.Next((1)) + 1;
        }
        public void SwapPlayer()   // rule
        {
            _playerTurn = _playerTurn == 1 ? 2 : 1;
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
        
        
        public GameStatus CheckGameStatus()   
        {
            var boardArray = _board.GetBoard();
            _gameStatus = GameRulesHandler.HasWon(boardArray) ? GameStatus.Won : (GameRulesHandler.HasDrawn(boardArray) ? GameStatus.Draw : GameStatus.Playing);
            
            return _gameStatus;
        }

        
        
    }
}
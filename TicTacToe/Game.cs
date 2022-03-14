namespace TicTacToe
{
    public class Game
    {
        private int _playerTurn;
        private GameStatus _gameStatus;
        private Board _board;
        
        public Game()
        {
            _playerTurn = 1;
        }


        public void Play()
        {
            
        }
        
        private (int, int) GetMove()
        {
            return (0, 0);
        }

        private void SwapPlayer()
        {
            
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
        
        
        public GameStatus CheckGameStatus(Board board)
        {
            _gameStatus = HasWon() ? GameStatus.Won : (HasDrawn() ? GameStatus.Draw : GameStatus.Playing);
            
            return _gameStatus;
        }

        private bool HasDrawn()
        {
            
        }
        
        private bool HasWon()
        {
            var boardArray = _board.GetBoard();
            return IsARowWin(boardArray) || IsAColumnWin(boardArray) || IsADiagonalWin(boardArray);
        }
        private static bool IsARowWin(int[,] boardArray)
        {
            for (var i = 0; i < boardArray.GetLength(0); i++)
            {
                if (CheckEquivalence(boardArray[i, 0], boardArray[i, 1], boardArray[i, 2]))
                {
                    return true;
                }
            }
            return false;
        }
        private static bool IsAColumnWin(int[,] boardArray)
        {
            for (var i = 0; i < boardArray.GetLength(1); i++)
            {
                if (CheckEquivalence(boardArray[0,i], boardArray[1,i], boardArray[2,i]))
                {
                    return true;
                }
            }
            return false;
        }
        private static bool IsADiagonalWin(int[,] boardArray)
        {
            return CheckEquivalence(boardArray[1, 1], boardArray[2, 2],boardArray[0, 0]) 
                   || CheckEquivalence(boardArray[1, 1], boardArray[2, 0], boardArray[0, 2]);
        }

        private static bool CheckEquivalence(int a, int b, int c)
        {
            return (a == b) && (b == c);
        }
        
        
        
    }
}
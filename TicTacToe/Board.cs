namespace TicTacToe
{
    public class Board
    {
        private int[,] _boardArray;
        private GameStatus _gameStatus;
        
        public Board()
        {
            _gameStatus = GameStatus.Playing;
            _boardArray = new int[3, 3]
            {
                {0, 0, 0},
                {0, 0, 0},
                {0, 0, 0}
            };
        }

        public int[,] GetBoard()
        {
            return _boardArray;
        }

        public bool PlaceMarker(Move move)
        {
            var (coordX, coordY) = move.GetCoord();

            if ( _boardArray[coordX - 1, coordY - 1] == 0)
            {
                _boardArray[coordX - 1, coordY - 1] = move.GetPlayer();;
            }
            else
            {
                return false;
            }
            
            return true;
        }

        public GameStatus CheckGameStatus()
        {
            _gameStatus = CheckWon() ? GameStatus.Won : (CheckDraw() ? GameStatus.Draw : GameStatus.Playing);
            
            return _gameStatus;
        }

        private bool CheckWon()
        {
            for (var i = 0; i < _boardArray.GetLength(0); i++)
            {
                if (_boardArray[i,0] == _boardArray[i,1] && _boardArray[i,1] == _boardArray[i,2])
                {
                    return true;
                }
            }
            for (var i = 0; i < _boardArray.GetLength(1); i++)
            {
                if (_boardArray[0,i] == _boardArray[1,i] && _boardArray[1,i] == _boardArray[2,i])
                {
                    return true;
                }
            }

            return false;
        }
        private bool CheckDraw()
        {
            

            return false;
        }

        public void ResetBoard()
        {
            _boardArray = new int[3, 3]
            {
                {0, 0, 0},
                {0, 0, 0},
                {0, 0, 0}
            };
        }
        
    }
}
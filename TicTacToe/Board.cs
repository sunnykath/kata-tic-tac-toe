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
            return GameStatus.Playing;
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
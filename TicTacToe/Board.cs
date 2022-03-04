namespace TicTacToe
{
    public class Board
    {
        private int[,] _board = new int[3,3];
        private GameStatus _gameStatus;
        

        
        public Board()
        {
            _gameStatus = GameStatus.Playing;
        }


        public bool PlaceMarker()
        {
            return false;
        }

        public GameStatus CheckGameStatus()
        {
            return GameStatus.Playing;
        }

        public void PrintBoard()
        {
            
        }

        public void ResetBoard()
        {
            
        }
        
    }
}
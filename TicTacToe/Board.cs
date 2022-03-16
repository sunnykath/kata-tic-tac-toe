namespace TicTacToe
{
    public class Board
    {
        private int[,] _boardArray;
        
        public Board()
        {
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

        public void PlaceMarker(Move move, int player)
        {
            var (coordX, coordY) = move.GetCoord();
            _boardArray[coordX - 1, coordY - 1] = player;
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
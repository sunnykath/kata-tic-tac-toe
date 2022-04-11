namespace TicTacToe
{
    public class Board
    {
        private int[,] _boardArray;
        
        
        // @Improvement: This board could be of type string as integers are not needed for any real reason
        public Board()
        {
            _boardArray = new[,]
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
            _boardArray[coordX, coordY] = player;
        }

        public void ResetBoard()
        {
            _boardArray = new[,]
            {
                {0, 0, 0},
                {0, 0, 0},
                {0, 0, 0}
            };
        }
        
    }
}
namespace TicTacToe
{
    public class Move
    {
        private readonly int _coordX;
        private readonly int _coordY;
        private readonly int _player;

        public Move(int coordX, int coordY, int player)
        {
            this._coordX = coordX;
            this._coordY = coordY;
            this._player = player;
        }

        public (int, int) GetCoord()
        {
            return (_coordX, _coordY);
        }

        public int GetPlayer()
        {
            return _player;
        }
    }
}
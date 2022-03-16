namespace TicTacToe
{
    public class Move
    {
        private readonly int _coordX;
        private readonly int _coordY;

        public Move(int coordX, int coordY)
        {
            this._coordX = coordX;
            this._coordY = coordY;
        }

        public (int, int) GetCoord()
        {
            return (_coordX, _coordY);
        }

        public override bool Equals(object? obj)
        {
            var otherMoveObject = (Move) obj;
            
            return otherMoveObject._coordX == _coordX && otherMoveObject._coordY == _coordY;
        }
    }
}
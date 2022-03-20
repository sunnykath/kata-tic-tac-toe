namespace TicTacToe
{
    public interface IUserInput
    {
        public void GetPlayerInput(int player);
        public bool PlayerHasGivenUp();
        public Move GetPlayerMove();
        public void OutputBoard();
    }
}
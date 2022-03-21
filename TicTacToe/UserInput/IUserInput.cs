namespace TicTacToe
{
    public interface IUserInput
    {
        public void UpdatePlayerInput(int player);
        public bool PlayerHasGivenUp();
        public Move GetPlayerMove();
        public void OutputBoard();
    }
}
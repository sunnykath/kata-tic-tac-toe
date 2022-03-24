namespace TicTacToe.UserInput
{
    public interface IUserInput
    {
        public void UpdatePlayerInput(int player);
        public bool PlayerHasGivenUp();
        public Move GetPlayerMove();
        public void OutputBoard(int[,] board);
        public void OutputMessage(string message);
    }
}
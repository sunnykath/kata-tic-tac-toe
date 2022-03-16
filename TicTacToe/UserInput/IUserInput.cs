namespace TicTacToe
{
    public interface IUserInput
    {
        public Move GetPlayerMove(int player);
        public void OutputBoard();
    }
}
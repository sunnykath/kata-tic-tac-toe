namespace TicTacToe.Rules
{
    public interface IRules
    {
        bool IsADuplicateMove(int[,] boardArray, Move inputMove);
        bool HasWon(int[,] boardArray);
        bool HasDrawn(int[,] boardArray);
    }
}
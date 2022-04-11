
namespace TicTacToe
{
    public static class Constants
    {
        public const int EmptyCellValue = 0;
        public const string EmptyCellMark = ".";
        
        public const int PlayerXValue = 1;
        public const string PlayerXMark = "X";
        public const int PlayerOValue = 2;
        public const string PlayerOMark = "O";

        public const int IndexingAdjustment = 1;

        public const string ValidMoveRegularExpression = "^[1-3],[1-3]$";

        public const string QuitCommand = "q";

        public const string InvalidInputErrorMessage = "Invalid Input, please try again: ";
        public const string MoveAcceptedMessage = "Move Accepted.";
        public const string GameQuitMessage = "You have given up.";
        public const string DuplicateMoveMessage = "Oh no, a piece is already at this place! Try again...";
        public const string GameWonMessage = "Well done you've won the game!";
        public const string GameDrawnMessage = "The Game has ended in a draw!";
        public const string BoardPrintedMessage = "Here's the board:";
    }
}
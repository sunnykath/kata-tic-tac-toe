namespace TicTacToe
{
    public static class Constants
    {
        public const int PlayerX = 1;
        public const int PlayerO = 2;

        public const int IndexingAdjustment = 1;

        public const string ValidMoveRegularExpression = "^[1-3],[1-3]$";

        public const string InvalidInputErrorMessage = "Invalid Input, please try again: ";
        public const string MoveAcceptedMessage = "Move Accepted.";
        public const string GameQuitMessage = "You have given up.\n";
        public const string DuplicateMoveMessage = "Oh no, a piece is already at this place! Try again...";

        public const string QuitCommand = "q";
    }
}
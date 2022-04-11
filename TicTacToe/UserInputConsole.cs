using System;
using System.Linq;

namespace TicTacToe
{
    public class UserInputConsole
    {
        private Move _moveInputCoords = new Move(-1,-1);
        private bool _hasGivenUp;

        public void UpdatePlayerInput(int player)
        {
            Console.Write($"Player {player} enter a coord x,y to place your {GetPlayerMark(player)} or enter 'q' to give up: ");

            var playerInput = GetValidatedInput();

            if (IsInputAQuitCommand(playerInput))
            {
                HandleQuitCommand();
            }
            else
            {
                HandleMoveInput(playerInput);
            }
        }

        public bool PlayerHasGivenUp()
        {
            return _hasGivenUp;
        }
        
        public Move GetPlayerMove()
        {
            return _moveInputCoords;
        }

        public void OutputBoard(int[,] board)
        {
            Console.WriteLine(Constants.BoardPrintedMessage);
            
            for (var row = 0; row < board.GetLength(0); row++)
            {
                var printedRow = "";
                for (var col = 0; col < board.GetLength(1); col++)
                {
                    var cell = board[row, col];
                    printedRow += GetPlayerMark(cell);
                    printedRow += " ";
                }
                Console.Write($"{printedRow}\n");
            }
        }

        public void OutputMessage(string message)
        {
            Console.WriteLine(message);
        }
        
        private string GetValidatedInput()
        {
            var isAValidMoveInput = true;
            string input;
            do
            {
                if(!isAValidMoveInput) Console.Write(Constants.InvalidInputErrorMessage);
                input = Console.ReadLine();
                isAValidMoveInput = IsInputAQuitCommand(input) || InputValidator.CheckInput(Constants.ValidMoveRegularExpression, input);
            } while (!isAValidMoveInput);

            return input;
        }
        
        private bool IsInputAQuitCommand(string playerInput)
        {
            return playerInput == Constants.QuitCommand;
        }

        private void HandleQuitCommand()
        {
            _hasGivenUp = true;
        }

        private void HandleMoveInput(string playerInput)
        {
            var inputStrings = playerInput.Split(',');
            var moveCoords = inputStrings.Select(int.Parse).ToList();

            _moveInputCoords = new Move(moveCoords[0] - Constants.IndexingAdjustment, moveCoords[1] - Constants.IndexingAdjustment);
        }
        
        private static string GetPlayerMark(int player)
        {
            var mark = player switch
            {
                Constants.PlayerOValue => Constants.PlayerOMark,
                Constants.PlayerXValue => Constants.PlayerXMark,
                _ => Constants.EmptyCellMark
            };
            return mark;
        }
    }
}
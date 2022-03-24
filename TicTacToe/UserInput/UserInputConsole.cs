using System;
using System.Linq;

namespace TicTacToe.UserInput
{
    public class UserInputConsole : IUserInput
    {
        private Move _moveInput = new Move(-1,-1);
        private bool _hasGivenUp;

        public void UpdatePlayerInput(int player)
        {
            Console.Write($"Player {player} enter a coord x,y to place your X or enter 'q' to give up: ");

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

            _moveInput = new Move(moveCoords[0] - Constants.IndexingAdjustment, moveCoords[1] - Constants.IndexingAdjustment);
        }
        
        public bool PlayerHasGivenUp()
        {
            return _hasGivenUp;
        }
        
        public Move GetPlayerMove()
        {
            return _moveInput;
        }

        public void OutputBoard()
        {
            throw new NotImplementedException();
        }

        public void OutputMessage(string message)
        {
            Console.WriteLine(message);
        }
    }
}
using System;
using System.Linq;

namespace TicTacToe
{
    public class UserInputConsole : IUserInput
    {
        private Move _moveInput = new Move(-1,-1);
        private bool _hasGivenUp;

        public void UpdatePlayerInput(int player)
        {
            Console.Write($"Player {player} enter a coord x,y to place your X or enter 'q' to give up: ");

            var playerInput = GetValidatedInput();

            if (IsInputACommand(playerInput))
            {
                HandleCommandInput(playerInput);
            }
            else
            {
                HandleMoveInput(playerInput);
            }

        }

        private string GetValidatedInput()
        {
            var isAValidMoveInput = true;
            var input = "";
            do
            {
                if(!isAValidMoveInput) Console.Write(Constants.InvalidInputErrorMessage);
                input = Console.ReadLine();
                isAValidMoveInput = IsInputACommand(input) || InputValidator.CheckInput(Constants.ValidMoveRegularExpression, input);
            } while (!isAValidMoveInput);

            return input;
        }
        
        private bool IsInputACommand(string playerInput)
        {
            return playerInput == Constants.QuitCommand;
        }

        private void HandleCommandInput(string playerInput)
        {
            if (playerInput == Constants.QuitCommand)
            {
                _hasGivenUp = true;
                Console.Write(Constants.GameQuitMessage);
            }
        }

        private void HandleMoveInput(string playerInput)
        {
            var inputStrings = playerInput.Split(',');
            var moveCoords = inputStrings.Select(int.Parse).ToList();

            _moveInput = new Move(moveCoords[0], moveCoords[1]);
            Console.Write(Constants.MoveAcceptedMessage);
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
            throw new System.NotImplementedException();
        }
    }
}
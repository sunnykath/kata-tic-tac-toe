using System;
using System.Linq;

namespace TicTacToe
{
    public class UserInputConsole : IUserInput
    {
        private readonly string _moveRegex = "^[1-3],[1-3]$";
        private Move moveInput;
        private bool hasGivenUp;

        public void GetPlayerInput(int player)
        {
            Console.Write($"Player {player} enter a coord x,y to place your X or enter 'q' to give up: ");

            var input = Console.ReadLine();

            if (input == "q")
            {
                hasGivenUp = true;
                Console.Write($"Player {player} has given up.");
            }
            else
            {

                var isValidInput = InputValidator.CheckInput(_moveRegex, input);
                while (!isValidInput)
                {
                    Console.Write("Invalid Input, please try again: ");
                    input = Console.ReadLine();
                    isValidInput = InputValidator.CheckInput(_moveRegex, input);
                }

                Console.Write("Move accepted, ");

                var inputStrings = input.Split(',');
                var moveCoords = inputStrings.Select(int.Parse).ToList();

                moveInput = new Move(moveCoords[0], moveCoords[1]);
            }
        }

        public bool PlayerHasGivenUp()
        {
            return hasGivenUp;
        }
        
        public Move GetPlayerMove()
        {
            return moveInput;
        }

        public void OutputBoard()
        {
            throw new System.NotImplementedException();
        }
    }
}
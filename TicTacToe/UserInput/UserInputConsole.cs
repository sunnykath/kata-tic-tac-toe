using System;
using System.Linq;

namespace TicTacToe
{
    public class UserInputConsole : IUserInput
    {
        private readonly string _moveRegex = "^[1-3],[1-3]$";
        public Move GetPlayerMove(int player)
        {
            Console.Write($"Player {player} enter a coord x,y to place your X or enter 'q' to give up: ");

            var input = Console.ReadLine();
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
            
            var inputMove = new Move(moveCoords[0], moveCoords[1]);
            
            return inputMove;
        }

        public void OutputBoard()
        {
            throw new System.NotImplementedException();
        }
    }
}
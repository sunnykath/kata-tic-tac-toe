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
            var success = InputValidator.CheckInput(_moveRegex, input);
            while (!success)
            {
                Console.Write("Invalid Input, please try again: ");
                input = Console.ReadLine();
                success = InputValidator.CheckInput(_moveRegex, input);
            }
            
            Console.Write("Move accepted, ");

            var inputsStrings = input.Split(',');
            var inputCoords = inputsStrings.Select(int.Parse).ToList();
            
            var inputMove = new Move(inputCoords[0], inputCoords[1]);
            
            return inputMove;
        }

        public void OutputBoard()
        {
            throw new System.NotImplementedException();
        }
    }
}
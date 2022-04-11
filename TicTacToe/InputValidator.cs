using System.Text.RegularExpressions;

namespace TicTacToe
{
    public static class InputValidator
    {
        public static bool CheckInput(string regexInput, string input)
        {
            var validRegex = new Regex(regexInput);
            return validRegex.IsMatch(input);
        }
    }
}
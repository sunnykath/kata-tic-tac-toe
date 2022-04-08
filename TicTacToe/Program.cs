using TicTacToe.Rules;

namespace TicTacToe
{
    public static class Program
    {
        static void Main()
        {
            var rules = new GameRulesHandler();
            var userInput = new UserInputConsole();
            
            var game = new GamePlay(userInput, rules);
            game.Play();
        }
        
    }
}
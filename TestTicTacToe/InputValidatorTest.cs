using TicTacToe;
using Xunit;

namespace TestTicTacToe
{

    public class InputValidatorTest
    {
        [Theory]
        [InlineData("3,3", "[1-3],[1-3]")]
        [InlineData("1,1", "[1-3],[1-3]")]
        [InlineData("2,2", "[1-3],[1-3]")]
        [InlineData("1,3", "[1-3],[1-3]")]
        public void Test_Should_Equal_True_If_Input_Is_Valid(string input, string regex)
        {
            // Act
            var result = InputValidator.CheckInput(regex, input);
            //Assert
            Assert.True(result);
        }

        [Theory]
        [InlineData("3,4", "[1-3],[1-3]")]
        [InlineData("5,5", "[1-3],[1-3]")]
        [InlineData("3,4", "[1-3] [1-3]")]
        // [InlineData("", "^[1-3],[1-3]$")]
        // [InlineData(",", "^[1-3],[1-3]$")]
        [InlineData("1,a", "[1-3],[1-3]")]
        [InlineData("sun", "[1-3],[1-3]")]
        public void Test_Should_Equal_False_If_Input_Is_Invalid(string input, string regex)
        {
            // Act
            var result = InputValidator.CheckInput(input, regex);
            //Assert
            Assert.False(result);
        }
    }
}
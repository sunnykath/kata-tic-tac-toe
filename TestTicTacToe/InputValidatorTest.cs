using TicTacToe;
using Xunit;

namespace TestTicTacToe
{

    public class InputValidatorTest
    {
        [Theory]
        [InlineData("3,3")]
        [InlineData("1,1")]
        [InlineData("2,2")]
        [InlineData("1,3")]
        public void Should_Equal_True_If_Input_Is_Valid(string input)
        {
            // Act
            var result = InputValidator.CheckInput(Constants.ValidMoveRegularExpression, input);
            //Assert
            Assert.True(result);
        }

        [Theory]
        [InlineData("3,4")]
        [InlineData("5,5")]
        [InlineData("")]
        [InlineData(",")]
        [InlineData("1,a")]
        [InlineData("sun")]
        public void Should_Equal_False_If_Input_Is_Invalid(string input)
        {
            // Act
            var result = InputValidator.CheckInput(Constants.ValidMoveRegularExpression, input);
            //Assert
            Assert.False(result);
        }
    }
}
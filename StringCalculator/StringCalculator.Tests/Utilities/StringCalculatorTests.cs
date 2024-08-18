using Xunit;

namespace StringCalculator.Tests.Utilities
{
    public class StringCalculatorTests
    {
        [Fact]
        public void Add_EmptyString_ReturnsZero()
        {
            var calculator = new App.Utilities.StringCalculator();
            Assert.Equal(0, calculator.Add(""));
        }

        [Fact]
        public void Add_SingleNumber_ReturnsThatNumber()
        {
            var calculator = new App.Utilities.StringCalculator();
            Assert.Equal(1, calculator.Add("1"));
        }

        [Fact]
        public void Add_TwoNumbers_ReturnsSum()
        {
            var calculator = new App.Utilities.StringCalculator();
            Assert.Equal(3, calculator.Add("1,2"));
        }

        [Fact]
        public void Add_MultipleNumbers_ReturnsSum()
        {
            var calculator = new App.Utilities.StringCalculator();
            Assert.Equal(15, calculator.Add("1,2,3,4,5"));
        }

        [Fact]
        public void Add_NumbersWithNewline_ReturnsSum()
        {
            var calculator = new App.Utilities.StringCalculator();
            Assert.Equal(6, calculator.Add("1\n2,3"));
        }

        [Fact]
        public void Add_CustomDelimiter_ReturnsSum()
        {
            var calculator = new App.Utilities.StringCalculator();
            Assert.Equal(3, calculator.Add("//;\n1;2"));
        }

        [Fact]
        public void Add_NegativeNumbers_ThrowsException()
        {
            var calculator = new App.Utilities.StringCalculator();
            var exception = Assert.Throws<ArgumentException>(() => calculator.Add("1,-2,-3"));
            Assert.Equal("Negatives not allowed: -2,-3", exception.Message);
        }

        [Fact]
        public void Add_NumbersGreaterThan1000_IgnoredInSum()
        {
            var calculator = new App.Utilities.StringCalculator();
            Assert.Equal(3, calculator.Add("3,1001"));
        }

        [Fact]
        public void Add_CustomDelimiterOfAnyLength_ReturnsSum()
        {
            var calculator = new App.Utilities.StringCalculator();
            Assert.Equal(6, calculator.Add("//[***]\n1***2***3"));
        }
    }
}
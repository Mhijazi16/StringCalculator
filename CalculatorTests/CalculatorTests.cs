namespace Calculator.Core;
using Xunit; 
using FluentAssertions;
public class CalculatorTests 
{
    private readonly Calculator _calculator;
    private int Result(string values) => _calculator.Add(values);
    public CalculatorTests()
    {
        _calculator = new Calculator(); 
    }
    
    [Fact]
    public void EmptyStringOrNull_Should_ReturnZero()
    {
        Result("").Should().Be(0); 
    }

    [Theory]
    [InlineData("1,2", 3)]
    public void ShouldAddDifferentNumbbers(string values, int expected)
    {
        Result(values).Should().Be(expected);
    }

    [Theory]
    [InlineData("[!\"#$%&'()*+\\./:;<=>?@[\\]^_`{|}~]",0)]
    [InlineData("[!\"#3,$%&'()*+\\./:;<=>?@[\\]^_`{|}~]1,2",6)]
    [InlineData("100,*30,25%^&*()",155)]
    public void Should_ParseOutSymbols(string values, int expected)
    {
        Result(values).Should().Be(expected);
    }
    
    [Theory]
    [InlineData("1,2,3,4,5",15)]
    public void Should_HandleUnknowAmountOfNumbers(string values, int expected)
    {
        Result(values).Should().Be(expected);
    }

    [Theory]
    [InlineData("1\n2,3",6)]
    public void Should_HandleNewLineBetweenNumbers(string values, int expected)
    {
        Result(values).Should().Be(expected);
    }

    [Fact]
    public void Should_ThrowFormatException()
    {
        Action action = () => Result("1,\n");
        action.Should().Throw<FormatException>("This isn't allowed");
    }
    
    [Theory]
    [InlineData("//;\n1;1",2)]
    [InlineData("//&\n2&3", 5)]
    public void Should_ParseAndReplaceDelimiter(string values, int expected)
    {
        Result(values).Should().Be(expected);
    }

    [Fact]
    public void Should_ThrowExceptionForNegative()
    {
        Action action = () => Result("1,-2,-1");
        action.Should().Throw<ArgumentOutOfRangeException>();
    }

}
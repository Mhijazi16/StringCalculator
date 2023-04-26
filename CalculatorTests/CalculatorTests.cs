namespace Calculator.Core;
using Xunit; 
using FluentAssertions;
public class CalculatorTests 
{
    private readonly Calculator _calculator;
    public CalculatorTests()
    {
        _calculator = new Calculator(); 
    }
    
    [Fact]
    public void EmptyStringOrNull_Should_ReturnZero()
    {
        int result = _calculator.Add("");
        result.Should().Be(0); 
    }

    [Theory]
    [InlineData("1,2", 3)]
    [InlineData("1,-2,5", 4)]
    public void ShouldAddDifferentNumbbers(string values, int expected)
    {
        int result = _calculator.Add(values);
        result.Should().Be(expected);
    }

    [Theory]
    [InlineData("[!\"#$%&'()*+\\./:;<=>?@[\\]^_`{|}~]",0)]
    [InlineData("[!\"#3,$%&'()*+\\./:;<=>?@[\\]^_`{|}~]1,2",6)]
    public void Should_ParseOutSymbols(string values, int expected)
    {
        int result = _calculator.Add(values);
        result.Should().Be(expected);
    }
}
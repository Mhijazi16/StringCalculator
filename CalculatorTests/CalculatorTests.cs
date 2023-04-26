using System.Runtime.InteropServices;

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
    [InlineData("100,*30,25%^&*()",155)]
    public void Should_ParseOutSymbols(string values, int expected)
    {
        int result = _calculator.Add(values);
        result.Should().Be(expected);
    }
    [Theory]
    [InlineData("1,2,3,4,5",15)]
    [InlineData("-100,-200,-300",-600)]
    public void Should_HandleUnknowAmountOfNumbers(string values, int expected)
    {
        int result = _calculator.Add(values);
        result.Should().Be(expected);
    }
}
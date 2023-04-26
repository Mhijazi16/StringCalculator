using System.Runtime.InteropServices;

namespace Calculator.Core;
using Xunit; 

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
        Assert.Equal(0,result);
    }

    [Theory]
    [InlineData("1,2", 3)]
    [InlineData("1,-2,5", 4)]
    public void ShouldAddDifferentNumbbers(string values, int expected)
    {
        int result = _calculator.Add(values); 
        Assert.Equal(expected,result);
    }

    [Theory]
    [InlineData("[!\"#$%&'()*+\\./:;<=>?@[\\]^_`{|}~]",0)]
    [InlineData("[!\"#3,$%&'()*+\\./:;<=>?@[\\]^_`{|}~]1,2",6)]
    public void Should_ParseOutSymbols(string values, int expected)
    {
        int result = _calculator.Add(values); 
        Assert.Equal(expected,result); 
    }
}
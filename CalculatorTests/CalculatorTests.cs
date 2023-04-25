namespace Calculator;
using Xunit; 

public class CalculatorTests 
{
    private readonly Calculator _calculator;
    CalculatorTests()
    {
        _calculator = new Calculator(); 
    }
    
    [Fact]
    public void EmptyString_Should_ReturnZero()
    {
        //Act 
        int result = _calculator.Add("");
        //Assert
        Assert.Equal(0,result);
    }
}
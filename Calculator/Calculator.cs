namespace Calculator;
using System.Linq; 
public class Calculator 
{
    public int Add(string values)
    {
        if (String.IsNullOrEmpty(values))
            return 0;
        
        int sum = values
            .Split(",")
            .Select(x => int.Parse(x))
            .Sum();

        return sum;
    }
}

using System.Text.RegularExpressions;

namespace Calculator;
using System.Linq; 
public class Calculator 
{
    public int Add(string values)
    {
        ApplyRegex(ref values);
        
        if (String.IsNullOrEmpty(values))
            return 0;
        
        return SumUpValues(values);
    }

    private static int SumUpValues(string values)
    {
        int sum = values
            .Split(",")
            .Select(x => int.Parse(x))
            .Sum();
        return sum;
    }
    private void ApplyRegex(ref string values)
    {
        values = Regex.Replace(values, @"\n", ",");
        values = Regex.Replace(values, "[^0-9,-]", ""); 
    }
}

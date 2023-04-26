using System.Text.RegularExpressions;

namespace Calculator;
using System.Linq; 
public class Calculator 
{
    public int Add(string values)
    {
        values = Regex.Replace(values, @"\n", ",");
        values = Regex.Replace(values, "[^0-9,-]", ""); 
         
        if (String.IsNullOrEmpty(values))
            return 0;
        
        int sum = values
            .Split(",")
            .Select(x => int.Parse(x))
            .Sum();

        return sum;
    }
}

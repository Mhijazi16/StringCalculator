using System.Text.RegularExpressions;
namespace Calculator.Core;
using System.Linq; 
public class Calculator
{
    private char delimiter = ','; 
    public int Add(string values)
    {
        ApplyRegex(ref values);
        
        if (String.IsNullOrEmpty(values))
            return 0;
        
        return SumUpValues(values);
    }
    private int SumUpValues(string values)
    {
        int sum = values
            .Split(delimiter)
            .Select(x => int.Parse(x))
            .Sum();
        return sum;
    }
    private void ApplyRegex(ref string values)
    {
        SetUpDelimiter(ref values);
        string d = "";
        d += delimiter;
        string pattern = $"[^0-9-{delimiter}]";
        values = Regex.Replace(values, @"\n", d);
        values = Regex.Replace(values,pattern, ""); 
    }
    private void SetUpDelimiter(ref string values)
    {
        if (values.Length < 4)
            return;  
        
        string start = values.Substring(0, 2);
        char end = values[3];
        if (start == "//" && end == '\n')
        {
            delimiter = values[2];
            values = values.Substring(4, values.Length -4 );
        }
    }
}

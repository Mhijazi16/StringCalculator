using System.Text.RegularExpressions;
namespace Calculator.Core;
using System.Linq; 
public class Calculator
{
    private char _delimiter = ',';
    private string _values; 
    public int Add(string values)
    {
        _values = values;
        SetUpDelimiter();
        SetUpRegex();
        
        if (String.IsNullOrEmpty(values))
            return 0;
        return SumUpValues();
    }
    private int SumUpValues()
    {
        int sum = _values
            .Split(_delimiter)
            .Select(x => int.Parse(x))
            .Sum();
        return sum;
    }
    private void SetUpRegex()
    {
        string pattern = $"[^0-9-{_delimiter}]";
        
        _values = Regex.Replace(_values, @"\n", _delimiter.ToString());
        _values = Regex.Replace(_values,pattern, ""); 
    }
    private void SetUpDelimiter()
    {
        if (_values.Length < 4)
            return;  
        
        string start = _values.Substring(0, 2);
        if (start == "//" && _values[3] == '\n')
        {
            _delimiter = _values[2];
            _values = _values.Substring(4, _values.Length -4 );
        }
    }
}

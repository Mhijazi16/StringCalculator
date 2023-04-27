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
        
        if (String.IsNullOrEmpty(_values))
            return 0;
        return SumUpValues();
    }
    private int SumUpValues()
    {
        var elements = _values
            .Split(_delimiter)
            .Select(x => int.Parse(x))
            .Where(x => x <= 1000)
            .ToList();

        var negatives = elements.Where(x => x < 0).ToList();
        
        if (negatives.Any())
        {
            var message= "Negative aren't Allowed : " + string.Join(", ", negatives);
            throw new ArgumentOutOfRangeException(message);
        }
        
        int sum = elements.Sum();
        return sum > 1000 ? 1000 : sum; 
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

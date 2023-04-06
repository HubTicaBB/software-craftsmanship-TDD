namespace Kata2;

public class StringCalculator
{
    public static readonly string[] defaultDelimiters = { ",", "\n" };

    public int Add(string numbers)
    {
        var values = ParseNumbers(numbers);

        return values.Sum();
    }

    private int[] ParseNumbers(string numbers)
    {
        return Array.ConvertAll(Split(numbers), GetCustomConverter());
    }

    private Converter<string, int> GetCustomConverter()
    {
        return number => int.TryParse(number, out var parsedNumber) 
            ? parsedNumber
            : 0;
    }

    private string[] Split(string numbers)
    {
        var customDelimiter = "";
        var delimiterStartTag = "//";
        var delimiterEndTag = "\n";

        if (numbers.StartsWith(delimiterStartTag))
        {
            var from = numbers.IndexOf(delimiterStartTag) + delimiterStartTag.Length;
            var to = numbers.IndexOf(delimiterEndTag);
            customDelimiter = numbers[from..to];
            numbers = numbers[to..];
        }

        string[] delimiters = customDelimiter != string.Empty
            ? new string[] { customDelimiter }
            : defaultDelimiters;

        return numbers.Split(delimiters, StringSplitOptions.None);
    }
}

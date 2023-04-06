namespace Kata2;

public class StringCalculator
{
    public static readonly string[] defaultDelimiters = { ",", "\n" };
    public static readonly string delimiterStartTag = "//";
    public static readonly string delimiterEndTag = "\n";

    public int Add(string numbers)
    {
        var values = ParseNumbers(numbers);

        if (ContainsNegativeNumbers(values))
        {
            throw new Exception($"Negatives not allowed: {FindNegativeNumbers(values)}");
        }

        return values.Sum();
    }

    private string FindNegativeNumbers(int[] values)
    {
        var negativeNumbers = Array.FindAll(values, number => number < 0);
        return string.Join(", ", negativeNumbers);
    }

    private bool ContainsNegativeNumbers(int[] values)
    {
        return values.Any(number => number < 0);
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
        string[] delimiters = GetDelimiters(numbers);

        return numbers.Split(delimiters, StringSplitOptions.None);
    }

    private string[] GetDelimiters(string numbers)
    {
        var customDelimiter = "";

        if (numbers.StartsWith(delimiterStartTag))
        {
            var from = numbers.IndexOf(delimiterStartTag) + delimiterStartTag.Length;
            var to = numbers.IndexOf(delimiterEndTag);
            customDelimiter = numbers[from..to];
        }

        return customDelimiter != string.Empty
            ? new string[] { customDelimiter }
            : defaultDelimiters;
    }
}

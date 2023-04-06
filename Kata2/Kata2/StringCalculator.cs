namespace Kata2;

public class StringCalculator
{
    public static readonly string[] delimiters = { ",", "\n" };

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
        return numbers.Split(delimiters, StringSplitOptions.None);
    }
}

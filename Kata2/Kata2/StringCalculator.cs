namespace Kata2;

public class StringCalculator
{
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
        var delimiters = new string[] { ",", "\n" };
        return numbers.Split(delimiters, StringSplitOptions.None);
    }
}

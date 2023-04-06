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
        return Array.ConvertAll(Split(numbers), s =>
            int.TryParse(s, out var i) ? i : 0);
    }

    private string[] Split(string numbers)
    {
        return numbers.Split(",");
    }
}

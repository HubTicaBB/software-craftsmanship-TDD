namespace Kata2;

public class StringCalculator
{
    public int Add(string numbers)
    {
        if (numbers == string.Empty)
        {
            return 0;
        };

        int.TryParse(numbers, out int value);
        
        return value;
    }
}

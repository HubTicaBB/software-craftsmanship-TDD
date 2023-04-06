﻿namespace Kata2;

public class StringCalculator
{
    public static readonly string[] defaultDelimiters = { ",", "\n" };
    public static readonly string delimiterStartTag = "//";
    public static readonly string delimiterEndTag = "\n";

    public int Add(string numbers)
    {
        var values = ParseNumbers(numbers);

        if (values.Any(number => number < 0))
        {
            var negativeNumber = Array.Find(values, number => number < 0);
            throw new Exception($"Negatives not allowed: {negativeNumber}");
        }

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

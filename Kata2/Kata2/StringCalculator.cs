﻿namespace Kata2;

public class StringCalculator
{
    public static readonly string[] defaultDelimiters = { ",", "\n" };
    public static readonly string delimiterStartTag = "//";
    public static readonly string delimiterEndTag = "\n";
    public static readonly int maxValidNumber = 1000;

    public int calledCount = 0;

    public int Add(string numbers)
    {
        calledCount++;

        var values = ParseNumbers(numbers);

        if (ContainsNegativeNumbers(values))
        {
            throw new Exception($"Negatives not allowed: {FindNegativeNumbers(values)}");
        }

        return values.Sum();
    }

    public int GetCalledCount()
    {
        return calledCount;
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
        return Array.ConvertAll(Split(numbers), GetValidNumbersConverter());
    }

    private Converter<string, int> GetValidNumbersConverter()
    {
        return number => int.TryParse(number, out var parsedNumber) && parsedNumber <= maxValidNumber
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

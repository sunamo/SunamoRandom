namespace SunamoRandom;

/// <summary>
/// Provides methods for generating lists of random numbers.
/// </summary>
public class RandomHelperList
{
    /// <summary>
    /// Generates a list of random numbers with the specified digit length.
    /// </summary>
    /// <param name="length">Number of digits for each generated number.</param>
    /// <param name="count">Number of random numbers to generate.</param>
    /// <returns>A list of random integers with the specified digit length.</returns>
    public static List<int> GenerateNumbers(int length, int count)
    {
        List<int> result = new(count);
        var random = new Random();
        for (var i = 0; i < count; i++)
            result.Add(random.Next(int.Parse("1".PadRight(length, '0')), int.Parse("9".PadRight(length, '9'))));

        return result;
    }
}

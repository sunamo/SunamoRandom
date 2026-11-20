namespace SunamoRandom;

/// <summary>
/// Represents the random helper list type.
/// </summary>
public class RandomHelperList
{
    /// <summary>
    /// Generate numbers.
    /// </summary>
    /// <param name="length">The length.</param>
    /// <param name="count">The count.</param>
    /// <returns>The generate numbers result.</returns>
    public static List<int> GenerateNumbers(int length, int count)
    {
        List<int> result = new(count);
        var random = new Random();
        for (var i = 0; i < count; i++)
            result.Add(random.Next(int.Parse("1".PadRight(length, '0')), int.Parse("9".PadRight(length, '9'))));

        return result;
    }
}

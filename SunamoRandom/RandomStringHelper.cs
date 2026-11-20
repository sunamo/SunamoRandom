namespace SunamoRandom;

/// <summary>
/// Represents the random string helper type.
/// </summary>
public class RandomStringHelper
{
    private static readonly Random random = new();
    private static readonly string alphanumericChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";

    private static char[]? stringChars;

    /// <summary>
    /// Random string.
    /// </summary>
    /// <param name="length">The length.</param>
    /// <param name="numberOfNonAlphanumericCharacters">The number of non alphanumeric characters.</param>
    /// <returns>The random string result.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string RandomString(int length, int numberOfNonAlphanumericCharacters)
    {
        SpecialCharsService specialCharsService = new();

        stringChars = new char[length];

        var i = 0;

        for (; i < numberOfNonAlphanumericCharacters; i++)
            stringChars[i] = specialCharsService.SpecialCharsAll[random.Next(specialCharsService.SpecialCharsAll.Count)];

        for (; i < length; i++) stringChars[i] = alphanumericChars[random.Next(alphanumericChars.Length)];

        return new string(stringChars);
    }
}

namespace SunamoRandom;

/// <summary>
/// Provides easy-to-use random string generation for scenarios where other methods
/// (like System.Web.Security.Membership.GeneratePassword) are not available.
/// </summary>
public class RandomStringHelper
{
    private static readonly Random random = new();
    private static readonly string alphanumericChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";

    private static char[]? stringChars;

    /// <summary>
    /// Generates a random string of the specified length with a given number of non-alphanumeric (special) characters.
    /// </summary>
    /// <param name="length">Total length of the generated string.</param>
    /// <param name="numberOfNonAlphanumericCharacters">Number of special characters to include.</param>
    /// <returns>A random string containing both alphanumeric and special characters.</returns>
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

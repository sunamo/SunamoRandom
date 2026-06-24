namespace SunamoRandom;

public class RandomStringHelper
{
    private static readonly Random random = new();
    private static readonly string alphanumericChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";

    private static char[]? stringChars;

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

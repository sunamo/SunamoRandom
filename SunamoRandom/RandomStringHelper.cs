namespace SunamoRandom;


/// <summary>
///     For easy copy where is needed generate random sting and is not availbale other methods (like
///     System.Web.Security.Membership.GeneratePassword etc.)
/// </summary>
public class RandomStringHelper
{
    private static readonly Random random = new();
    private static readonly string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";

    private static char[] stringChars;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string RandomString(int v, int numberOfNonAlphanumericCharacters)
    {
        SpecialCharsService specialChars = new();

        var nonAlphaNumeric = v - numberOfNonAlphanumericCharacters;
        stringChars = new char[v];

        var i = 0;

        for (; i < numberOfNonAlphanumericCharacters; i++)
            stringChars[i] = specialChars.specialCharsAll[random.Next(specialChars.specialCharsAll.Count)];

        for (; i < v; i++) stringChars[i] = chars[random.Next(chars.Length)];

        return new string(stringChars);
    }
}
namespace SunamoRandom._sunamo;

/// <summary>
/// Provides collections of letter and digit characters for random generation.
/// </summary>
internal class LetterAndDigitCharService
{
    /// <summary>
    /// All letter and digit characters without special characters.
    /// </summary>
    internal readonly List<char> AllCharsWithoutSpecial;

    /// <summary>
    /// All letter, digit, and special characters combined.
    /// </summary>
    internal readonly List<char> AllChars;

    /// <summary>
    /// Numeric digit characters 0-9.
    /// </summary>
    internal readonly List<char> NumericChars =
        new(new[] { '1', '2', '3', '4', '5', '6', '7', '8', '9', '0' });

    /// <summary>
    /// Lowercase letter characters a-z.
    /// </summary>
    internal readonly List<char> LowerChars = new(new[]
    {
        'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v',
        'w', 'x', 'y', 'z'
    });

    /// <summary>
    /// Uppercase letter characters A-Z.
    /// </summary>
    internal readonly List<char> UpperChars = new(new[]
    {
        'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V',
        'W', 'X', 'Y', 'Z'
    });

    /// <summary>
    /// Initializes character collections by combining letter, digit, and special character lists.
    /// </summary>
    internal LetterAndDigitCharService()
    {
        AllCharsWithoutSpecial = new List<char>();
        AllCharsWithoutSpecial.AddRange(LowerChars);
        AllCharsWithoutSpecial.AddRange(UpperChars);
        AllCharsWithoutSpecial.AddRange(NumericChars);

        AllChars = new List<char>(AllCharsWithoutSpecial);
        var specialCharsService = new SpecialCharsService();
        AllChars.AddRange(specialCharsService.SpecialChars);
    }
}

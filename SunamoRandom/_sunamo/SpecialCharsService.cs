namespace SunamoRandom._sunamo;

/// <summary>
/// Provides collections of special characters for random string generation.
/// </summary>
internal class SpecialCharsService
{
    /// <summary>
    /// Primary special characters used in random generation.
    /// </summary>
    internal readonly List<char> SpecialChars = new(new[]
        { excl, commat, num, dollar, percnt, hat, amp, ast, quest, lowbar, tilda });

    /// <summary>
    /// Secondary special characters including punctuation and brackets.
    /// </summary>
    internal readonly List<char> SpecialChars2 = new(new[]
    {
        lq, rq, dash, la, ra,
        comma, period, colon, apos, rpar, sol, lt, gt, lcub, rcub, lsqb, verbar, semi, plus, rsqb,
        ndash, slash
    });

    /// <summary>
    /// All special characters combined, used in enigma and password generation.
    /// </summary>
    internal readonly List<char> SpecialCharsAll;

    /// <summary>
    /// Whitespace special characters.
    /// </summary>
    internal readonly List<char> SpecialCharsWhite = new(new[] { space });

    /// <summary>
    /// Non-enigma special characters.
    /// </summary>
    internal readonly List<char> SpecialCharsNotEnigma = new(new[] { space160, copy });

    private const char la = '\u2018';
    private const char ra = '\u2019';
    private const char comma = ',';
    private const char space = ' ';
    private static readonly char space160 = (char)160;
    private const char dollar = '$';
    private const char hat = '^';
    private const char ast = '*';
    private const char quest = '?';
    private const char tilda = '~';
    private const char period = '.';
    private const char colon = ':';
    private const char excl = '!';
    private const char apos = '\'';
    private const char rpar = ')';
    private const char sol = '/';
    private const char lowbar = '_';
    private const char lt = '<';
    private const char gt = '>';
    private const char amp = '&';
    private const char lcub = '{';
    private const char rcub = '}';
    private const char lsqb = '[';
    private const char verbar = '|';
    private const char semi = ';';
    private const char commat = '@';
    private const char plus = '+';
    private const char rsqb = ']';
    private const char num = '#';
    private const char percnt = '%';
    private const char ndash = '\u2013';
    private const char copy = '\u00A9';
    private const char lq = '\u201C';
    private const char rq = '\u201D';
    private const char dash = '-';
    private const char slash = '/';

    /// <summary>
    /// Initializes all special character collections by combining primary, secondary, whitespace and non-enigma lists.
    /// </summary>
    internal SpecialCharsService()
    {
        SpecialCharsAll = new List<char>();
        SpecialCharsAll.AddRange(SpecialChars);
        SpecialCharsAll.AddRange(SpecialChars2);
        SpecialCharsAll.AddRange(SpecialCharsWhite);
        SpecialCharsAll.AddRange(SpecialCharsNotEnigma);
    }
}

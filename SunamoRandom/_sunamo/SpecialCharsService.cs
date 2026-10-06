namespace SunamoRandom._sunamo;

internal class SpecialCharsService
{
    internal readonly List<char> SpecialChars = new(new[]
        { excl, commat, num, dollar, percnt, hat, amp, ast, quest, lowbar, tilda });

    internal readonly List<char> SpecialChars2 = new(new[]
    {
        lq, rq, dash, la, ra,
        comma, period, colon, apos, rpar, sol, lt, gt, lcub, rcub, lsqb, verbar, semi, plus, rsqb,
        ndash, slash
    });

    internal readonly List<char> SpecialCharsAll;

    internal readonly List<char> SpecialCharsWhite = new(new[] { space });

    internal readonly List<char> SpecialCharsNotEnigma = new(new[] { space160, copy });

    private const char la = '‘';
    private const char ra = '’';
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
    private const char ndash = '–';
    private const char copy = '©';
    private const char lq = '“';
    private const char rq = '”';
    private const char dash = '-';
    private const char slash = '/';

    internal SpecialCharsService()
    {
        SpecialCharsAll = new List<char>();
        SpecialCharsAll.AddRange(SpecialChars);
        SpecialCharsAll.AddRange(SpecialChars2);
        SpecialCharsAll.AddRange(SpecialCharsWhite);
        SpecialCharsAll.AddRange(SpecialCharsNotEnigma);
    }
}

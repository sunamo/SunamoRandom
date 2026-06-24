namespace SunamoRandom;

public static partial class RandomHelper
{
    private static readonly Random random = new();
    private static readonly float lightColorBase = 256 - 229;

    public static Type Type { get; set; } = typeof(RandomHelper);

    // Highly random generator. The seed is always different because the seed is also randomly generated.
    private static readonly Random randomGenerator = new(Guid.NewGuid().GetHashCode());

    public static float RandomFloat(int decimalDigits, float maxValue, int maxIntegerDigits)
    {
        if (decimalDigits > 7) decimalDigits = 7;
        string integerPart;
        if (maxIntegerDigits > 8)
            integerPart = RandomNumberString(decimalDigits);
        else
            integerPart = RandomInt(maxIntegerDigits + 1).ToString();

        var decimalLength = 7 - decimalDigits;
        float result;
        if (decimalLength != 0)
        {
            var decimalPart = RandomNumberString(decimalLength);
            result = float.Parse(integerPart + "." + decimalPart);
        }
        else
        {
            result = float.Parse(integerPart);
        }

        if (result > maxValue) return maxValue;
        return result;
    }

    private static char RandomNumberChar()
    {
        LetterAndDigitCharService letterAndDigitChar = new LetterAndDigitCharService();
        return RandomElementOfCollection(letterAndDigitChar.AllChars)[0];
    }

    private static string RandomNumberString(int length)
    {
        length--;
        var stringBuilder = new StringBuilder();
        for (var i = 0; i != length; i++) stringBuilder.Append(RandomNumberChar());
        return stringBuilder.ToString();
    }

    public static byte RandomColorPart(bool isLight, float add)
    {
        if (isLight)
        {
            var result = RandomFloatBetween0And1();
            result *= lightColorBase;
            return (byte)(result + add);
        }

        return RandomByte(0, 255);
    }

    public static byte RandomByte(int from, int toInclusive)
    {
        return (byte)randomGenerator.Next(from, toInclusive + 1);
    }

    public static byte RandomColorPart(bool isLight)
    {
        return RandomColorPart(isLight, 127f);
    }

    private static float RandomFloatBetween0And1()
    {
        return RandomFloat(1, 1, 0);
    }

    [return: MaybeNull]
    public static T RandomElementOfCollectionT<T>(IList<T> list)
    {
        if (list.Count == 0) return default!;
        var index = RandomInt(list.Count);
        return list[index];
    }

    public static T RandomEnum<T>()
        where T : struct, Enum
    {
        var values = ((T[])Enum.GetValues(typeof(T)));
        var result = RandomElementOfCollectionT(values);
        return result;
    }

    public static string RandomElementOfCollection(Array array)
    {
        var index = RandomInt(array.Length);
        return array.GetValue(index)?.ToString() ?? string.Empty;
    }

    // Generates a random string without special characters containing only lowercase/uppercase letters and digits.
    // Call ToLower when saving to DB. Newly calls ToLower automatically.
    public static string RandomStringWithoutSpecial(int length, bool isAlsoUpper = false)
    {
        length--;
        var stringBuilder = new StringBuilder();
        for (var i = 0; i != length; i++) stringBuilder.Append(RandomCharWithoutSpecial());
        var result = stringBuilder.ToString();
        if (!isAlsoUpper) return result.ToLower();
        return result;
    }

    public static byte RandomByte2(int from, int to)
    {
        return (byte)randomGenerator.Next(from, to);
    }

    // Returns a random character from uppercase, lowercase letters and digits.
    // Call ToLower when saving to DB.
    public static char RandomCharWithoutSpecial()
    {
        LetterAndDigitCharService letterAndDigitChar = new LetterAndDigitCharService();
        return RandomElementOfCollection(letterAndDigitChar.AllCharsWithoutSpecial)[0];
    }

    public static string RandomString(int length, bool isUpper, bool isLower, bool isNumeric, bool isSpecial)
    {
        LetterAndDigitCharService letterAndDigitChar = new();
        SpecialCharsService specialCharsService = new();

        var characters = new List<char>();
        if (isLower) characters.AddRange(letterAndDigitChar.LowerChars);
        if (isNumeric) characters.AddRange(letterAndDigitChar.NumericChars);
        if (isSpecial) characters.AddRange(specialCharsService.SpecialChars);
        if (isUpper) characters.AddRange(letterAndDigitChar.UpperChars);

        length--;
        var stringBuilder = new StringBuilder();
        for (var i = 0; i != length; i++) stringBuilder.Append(RandomElementOfCollection(characters));
        return stringBuilder.ToString();
    }

    public static string RandomString()
    {
        var stringBuilder = new StringBuilder();
        for (var i = 0; i < 7; i++) stringBuilder.Append(RandomChar());
        return stringBuilder.ToString();
    }

    public static byte[] RandomBytes(int count)
    {
        var buffer = new byte[count];
        for (var i = 0; i < count; i++) buffer[i] = (byte)randomGenerator.Next(0, byte.MaxValue);
        return buffer;
    }

    public static short RandomShort(short to)
    {
        return (short)randomGenerator.Next(0, to);
    }

    public static short RandomShort(short from, short to)
    {
        return (short)randomGenerator.Next(from, to + 1);
    }

    public static short RandomShort()
    {
        return (short)randomGenerator.Next(0, short.MaxValue);
    }

    public static bool RandomBool()
    {
        var index = RandomInt(2);
        string boolText;
        if (index == 0)
            boolText = bool.FalseString;
        else
            boolText = bool.TrueString;
        return bool.Parse(boolText);
    }

    public static DateTime RandomDateTime(int yearTo)
    {
        DateTime result = new(1900, 1, 1);
        result = result.AddDays(RandomDouble(1, 28));
        result = result.AddMonths(random.Next(1, 12));
        var adjustedYear = yearTo - DTConstants.YearStartUnixDate;
        result = result.AddYears(random.Next(1, adjustedYear) + 70);

        result = result.AddHours(RandomDouble(1, 24));
        result = result.AddMinutes(RandomDouble(1, 60));
        result = result.AddSeconds(RandomDouble(1, 60));

        return result;
    }

    private static double RandomDouble(int minimum, int maximum)
    {
        return RandomInt(minimum, maximum);
    }

    public static string RandomString(int length)
    {
        length--;
        var stringBuilder = new StringBuilder();
        for (var i = 0; i != length; i++) stringBuilder.Append(RandomChar());
        return stringBuilder.ToString();
    }

    public static char RandomChar()
    {
        LetterAndDigitCharService letterAndDigitChar = new();
        return RandomElementOfCollection(letterAndDigitChar.AllChars)[0];
    }

    public static string RandomElementOfCollection(IList list)
    {
        var index = RandomInt(list.Count);
        return list[index]?.ToString() ?? string.Empty;
    }

    public static int RandomInt(int to)
    {
        return randomGenerator.Next(0, to);
    }
}

namespace SunamoRandom;

/// <summary>
/// Provides methods for generating random values of various types including numbers, strings, bytes, and colors.
/// </summary>
public static partial class RandomHelper
{
    private static readonly Random random = new();
    private static readonly float lightColorBase = 256 - 229;

    /// <summary>
    /// The type of the RandomHelper class.
    /// </summary>
    public static Type Type { get; set; } = typeof(RandomHelper);

    /// <summary>
    /// Highly random generator. The seed is always different because the seed is also randomly generated.
    /// </summary>
    private static readonly Random randomGenerator = new(Guid.NewGuid().GetHashCode());

    /// <summary>
    /// Generates a random float value with the specified number of integer and decimal digits.
    /// </summary>
    /// <param name="decimalDigits">Number of decimal digits (max 7).</param>
    /// <param name="maxValue">Maximum allowed float value.</param>
    /// <param name="maxIntegerDigits">Maximum number of integer digits.</param>
    /// <returns>A random float value not exceeding <paramref name="maxValue"/>.</returns>
    public static float RandomFloat(int decimalDigits, float maxValue, int maxIntegerDigits)
    {
        if (decimalDigits > 7) decimalDigits = 7;
        var integerPart = "";
        if (maxIntegerDigits > 8)
            integerPart = RandomNumberString(decimalDigits);
        else
            integerPart = RandomInt(maxIntegerDigits + 1).ToString();

        var decimalLength = 7 - decimalDigits;
        float result = 0;
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

    /// <summary>
    /// Generates a random color component byte value.
    /// </summary>
    /// <param name="isLight">Whether to generate a light color value.</param>
    /// <param name="add">Value to add to the light color base.</param>
    /// <returns>A random byte representing a color component.</returns>
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

    /// <summary>
    /// Generates a random byte between <paramref name="from"/> and <paramref name="toInclusive"/> inclusive.
    /// </summary>
    /// <param name="from">Minimum value (inclusive).</param>
    /// <param name="toInclusive">Maximum value (inclusive).</param>
    /// <returns>A random byte.</returns>
    public static byte RandomByte(int from, int toInclusive)
    {
        return (byte)randomGenerator.Next(from, toInclusive + 1);
    }

    /// <summary>
    /// Generates a random color component byte value with default add value of 127.
    /// </summary>
    /// <param name="isLight">Whether to generate a light color value.</param>
    /// <returns>A random byte representing a color component.</returns>
    public static byte RandomColorPart(bool isLight)
    {
        return RandomColorPart(isLight, 127f);
    }

    private static float RandomFloatBetween0And1()
    {
        return RandomFloat(1, 1, 0);
    }

    /// <summary>
    /// Returns a random element from a generic typed list.
    /// </summary>
    /// <typeparam name="T">The type of elements in the list.</typeparam>
    /// <param name="list">The list to pick a random element from.</param>
    /// <returns>A random element from the list, or default if empty.</returns>
    [return: MaybeNull]
    public static T RandomElementOfCollectionT<T>(IList<T> list)
    {
        if (list.Count == 0) return default!;
        var index = RandomInt(list.Count);
        return list[index];
    }

    /// <summary>
    /// Returns a random value from the specified enum type.
    /// </summary>
    /// <typeparam name="T">The enum type.</typeparam>
    /// <returns>A random enum value.</returns>
    public static T RandomEnum<T>()
        where T : struct, Enum
    {
        var values = Enum.GetValues<T>();
        var result = RandomElementOfCollectionT(values);
        return result;
    }

    /// <summary>
    /// Returns a random element from an Array as a string.
    /// </summary>
    /// <param name="array">The array to pick a random element from.</param>
    /// <returns>String representation of a random element.</returns>
    public static string RandomElementOfCollection(Array array)
    {
        var index = RandomInt(array.Length);
        return array.GetValue(index)?.ToString() ?? string.Empty;
    }

    /// <summary>
    /// Generates a random string without special characters containing only lowercase/uppercase letters and digits.
    /// Call ToLower when saving to DB. Newly calls ToLower automatically.
    /// </summary>
    /// <param name="length">Desired length of the string (actual length is length - 1).</param>
    /// <param name="isAlsoUpper">Whether to include uppercase characters in the result.</param>
    /// <returns>A random alphanumeric string.</returns>
    public static string RandomStringWithoutSpecial(int length, bool isAlsoUpper = false)
    {
        length--;
        var stringBuilder = new StringBuilder();
        for (var i = 0; i != length; i++) stringBuilder.Append(RandomCharWithoutSpecial());
        var result = stringBuilder.ToString();
        if (!isAlsoUpper) return result.ToLower();
        return result;
    }

    /// <summary>
    /// Returns a number between <paramref name="from"/> and <paramref name="to"/> - 1 (exclusive upper bound).
    /// Useful for index calculations.
    /// </summary>
    /// <param name="from">Minimum value (inclusive).</param>
    /// <param name="to">Maximum value (exclusive).</param>
    /// <returns>A random byte.</returns>
    public static byte RandomByte2(int from, int to)
    {
        return (byte)randomGenerator.Next(from, to);
    }

    /// <summary>
    /// Returns a random character from uppercase, lowercase letters and digits.
    /// Call ToLower when saving to DB.
    /// </summary>
    /// <returns>A random alphanumeric character.</returns>
    public static char RandomCharWithoutSpecial()
    {
        LetterAndDigitCharService letterAndDigitChar = new LetterAndDigitCharService();
        return RandomElementOfCollection(letterAndDigitChar.AllCharsWithoutSpecial)[0];
    }

    /// <summary>
    /// Generates a random string composed of specified character types.
    /// </summary>
    /// <param name="length">Desired length of the string (actual length is length - 1).</param>
    /// <param name="isUpper">Whether to include uppercase characters.</param>
    /// <param name="isLower">Whether to include lowercase characters.</param>
    /// <param name="isNumeric">Whether to include numeric characters.</param>
    /// <param name="isSpecial">Whether to include special characters.</param>
    /// <returns>A random string of the specified character types.</returns>
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

    /// <summary>
    /// Generates a random string of 7 characters.
    /// </summary>
    /// <returns>A random 7-character string.</returns>
    public static string RandomString()
    {
        var stringBuilder = new StringBuilder();
        for (var i = 0; i < 7; i++) stringBuilder.Append(RandomChar());
        return stringBuilder.ToString();
    }

    /// <summary>
    /// Generates an array of random bytes.
    /// </summary>
    /// <param name="count">Number of random bytes to generate.</param>
    /// <returns>An array of random bytes.</returns>
    public static byte[] RandomBytes(int count)
    {
        var buffer = new byte[count];
        for (var i = 0; i < count; i++) buffer[i] = (byte)randomGenerator.Next(0, byte.MaxValue);
        return buffer;
    }

    /// <summary>
    /// Returns a random number between 0 and <paramref name="to"/> - 1.
    /// </summary>
    /// <param name="to">Exclusive upper bound.</param>
    /// <returns>A random short value.</returns>
    public static short RandomShort(short to)
    {
        return (short)randomGenerator.Next(0, to);
    }

    /// <summary>
    /// Returns a random number between <paramref name="from"/> inclusive and <paramref name="to"/> inclusive.
    /// </summary>
    /// <param name="from">Minimum value (inclusive).</param>
    /// <param name="to">Maximum value (inclusive).</param>
    /// <returns>A random short value.</returns>
    public static short RandomShort(short from, short to)
    {
        return (short)randomGenerator.Next(from, to + 1);
    }

    /// <summary>
    /// Returns a random number between 0 and short.MaxValue - 1.
    /// </summary>
    /// <returns>A random short value.</returns>
    public static short RandomShort()
    {
        return (short)randomGenerator.Next(0, short.MaxValue);
    }

    /// <summary>
    /// Generates a random boolean value.
    /// </summary>
    /// <returns>A random boolean.</returns>
    public static bool RandomBool()
    {
        var index = RandomInt(2);
        var boolText = "";
        if (index == 0)
            boolText = bool.FalseString;
        else
            boolText = bool.TrueString;
        return bool.Parse(boolText);
    }

    /// <summary>
    /// Generates a random DateTime value up to the specified year.
    /// </summary>
    /// <param name="yearTo">Maximum year for the generated date.</param>
    /// <returns>A random DateTime value.</returns>
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

    /// <summary>
    /// Generates a random string of the specified length using all character types.
    /// </summary>
    /// <param name="length">Desired length of the string (actual length is length - 1).</param>
    /// <returns>A random string.</returns>
    public static string RandomString(int length)
    {
        length--;
        var stringBuilder = new StringBuilder();
        for (var i = 0; i != length; i++) stringBuilder.Append(RandomChar());
        return stringBuilder.ToString();
    }

    /// <summary>
    /// Returns a random character from all available character types.
    /// </summary>
    /// <returns>A random character.</returns>
    public static char RandomChar()
    {
        LetterAndDigitCharService letterAndDigitChar = new();
        return RandomElementOfCollection(letterAndDigitChar.AllChars)[0];
    }

    /// <summary>
    /// Returns a random element from an IList as a string.
    /// </summary>
    /// <param name="list">The list to pick a random element from.</param>
    /// <returns>String representation of a random element.</returns>
    public static string RandomElementOfCollection(IList list)
    {
        var index = RandomInt(list.Count);
        return list[index]?.ToString() ?? string.Empty;
    }

    /// <summary>
    /// Returns a random number between 0 and <paramref name="to"/> - 1.
    /// </summary>
    /// <param name="to">Exclusive upper bound.</param>
    /// <returns>A random integer.</returns>
    public static int RandomInt(int to)
    {
        return randomGenerator.Next(0, to);
    }
}

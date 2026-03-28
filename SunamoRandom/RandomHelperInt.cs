namespace SunamoRandom;

public static partial class RandomHelper
{
    /// <summary>
    /// Returns a random number from <paramref name="from"/> to <paramref name="to"/> - 1 (exclusive upper bound).
    /// </summary>
    /// <param name="from">Minimum value (inclusive).</param>
    /// <param name="to">Maximum value (exclusive).</param>
    /// <returns>A random integer.</returns>
    public static int RandomInt2(int from, int to)
    {
        return randomGenerator.Next(from, to);
    }

    /// <summary>
    /// Returns a random number between 0 and int.MaxValue - 1.
    /// </summary>
    /// <returns>A random integer.</returns>
    public static int RandomInt()
    {
        return randomGenerator.Next(0, int.MaxValue);
    }

    /// <summary>
    /// Returns a random number between <paramref name="from"/> and <paramref name="to"/> inclusive.
    /// </summary>
    /// <param name="from">Minimum value (inclusive).</param>
    /// <param name="to">Maximum value (inclusive).</param>
    /// <returns>A random integer.</returns>
    public static int RandomInt(int from, int to)
    {
        if (to == int.MaxValue) to--;
        if (from > to) throw new Exception($"From {from} is higher than to {to}");

        return randomGenerator.Next(from, to + 1);
    }
}

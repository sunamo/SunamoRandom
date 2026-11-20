namespace SunamoRandom;

public static partial class RandomHelper
{
    /// <summary>
    /// Random int 2.
    /// </summary>
    /// <param name="from">The from.</param>
    /// <param name="to">The to.</param>
    /// <returns>The random int 2 result.</returns>
    public static int RandomInt2(int from, int to)
    {
        return randomGenerator.Next(from, to);
    }

    /// <summary>
    /// Random int.
    /// </summary>
    /// <returns>The random int result.</returns>
    public static int RandomInt()
    {
        return randomGenerator.Next(0, int.MaxValue);
    }

    /// <summary>
    /// Random int.
    /// </summary>
    /// <param name="from">The from.</param>
    /// <param name="to">The to.</param>
    /// <returns>The random int result.</returns>
    public static int RandomInt(int from, int to)
    {
        if (to == int.MaxValue) to--;
        if (from > to) throw new Exception($"From {from} is higher than to {to}");

        return randomGenerator.Next(from, to + 1);
    }
}

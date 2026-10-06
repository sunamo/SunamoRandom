namespace SunamoRandom;

public static partial class RandomHelper
{
    public static int RandomInt2(int from, int to)
    {
        return randomGenerator.Next(from, to);
    }

    public static int RandomInt()
    {
        return randomGenerator.Next(0, int.MaxValue);
    }

    public static int RandomInt(int from, int to)
    {
        if (to == int.MaxValue) to--;
        if (from > to) throw new Exception($"From {from} is higher than to {to}");

        return randomGenerator.Next(from, to + 1);
    }
}

namespace SunamoRandom;

public class RandomHelperList
{
    public static List<int> GenerateNumbers(int length, int count)
    {
        List<int> result = new(count);
        Random random = new Random();
        for (int i = 0; i < count; i++)
        {
            result.Add(random.Next(int.Parse("1".PadRight(4, '0')), int.Parse("9".PadRight(4, '9'))));
        }

        return result;
    }
}

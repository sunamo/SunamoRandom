namespace SunamoRandom;




public class RandomHelperList
{
    public static List<int> GenerateNumbers(int length, int count)
    {
        List<int> result = new(count);

        for (int i = 0; i < count; i++)
        {
            result.Add(RandomHelper.RandomInt(int.Parse("1".PadRight(4, '0')), int.Parse("9".PadRight(4, '9'))));
        }

        return result;
    }
}

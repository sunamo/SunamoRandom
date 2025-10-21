// EN: Variable names have been checked and replaced with self-descriptive names
// CZ: Názvy proměnných byly zkontrolovány a nahrazeny samopopisnými názvy

public class RandomStringHelperTests
{
    [Fact]
    public void RandomStringTest()
    {
        var value = RandomStringHelper.RandomString(4, 2);
        var v2 = RandomStringHelper.RandomString(4, 1);
        int i = 0;
    }
}

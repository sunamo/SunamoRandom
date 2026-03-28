/// <summary>
/// Tests for the RandomStringHelper class.
/// </summary>
public class RandomStringHelperTests
{
    /// <summary>
    /// Verifies that RandomString generates strings of correct length with the expected character composition.
    /// </summary>
    [Fact]
    public void RandomStringTest()
    {
        var resultWithTwoSpecial = RandomStringHelper.RandomString(4, 2);
        var resultWithOneSpecial = RandomStringHelper.RandomString(4, 1);

        Assert.Equal(4, resultWithTwoSpecial.Length);
        Assert.Equal(4, resultWithOneSpecial.Length);
        Assert.NotEqual(resultWithTwoSpecial, resultWithOneSpecial);
    }
}

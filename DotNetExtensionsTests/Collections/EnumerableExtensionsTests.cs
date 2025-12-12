namespace DotNetExtensionsTests.Collections;

[TestClass]
public partial class EnumerableExtensionsTests
{
    private int[] _defaultSource = null!;

    [TestInitialize]
    public void Setup() => _defaultSource = [1, 2, 3, 4, 5];
}
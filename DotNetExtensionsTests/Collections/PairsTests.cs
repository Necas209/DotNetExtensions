using DotNetExtensions.Collections;

namespace DotNetExtensionsTests.Collections;

public partial class EnumerableExtensionsTests
{
    [TestMethod]
    public void Pairs_SourceHasMultipleElements_ReturnsExpectedPairs()
    {
        AssertPairsAreExpected(_defaultSource);
    }

    [TestMethod]
    public void Pairs_SourceIsCollection_ReturnsExpectedPairs()
    {
        AssertPairsAreExpected(_defaultSource.ToHashSet());
    }

    [TestMethod]
    public void Pairs_SourceIsEnumerable_ReturnsExpectedPairs()
    {
        AssertPairsAreExpected(Enumerable.Range(1, 5).Select(i => i));
    }

    private static void AssertPairsAreExpected(IEnumerable<int> source)
    {
        var result = source.Pairs().ToList();

        Assert.HasCount(10, result);
        Assert.AreEqual((1, 2), result[0]);
        Assert.AreEqual((1, 3), result[1]);
        Assert.AreEqual((1, 4), result[2]);
        Assert.AreEqual((1, 5), result[3]);
        Assert.AreEqual((2, 3), result[4]);
        Assert.AreEqual((2, 4), result[5]);
        Assert.AreEqual((2, 5), result[6]);
        Assert.AreEqual((3, 4), result[7]);
        Assert.AreEqual((3, 5), result[8]);
        Assert.AreEqual((4, 5), result[9]);
    }
}
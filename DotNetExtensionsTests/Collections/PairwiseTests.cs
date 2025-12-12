using DotNetExtensions.Collections;

namespace DotNetExtensionsTests.Collections;

public partial class EnumerableExtensionsTests
{
    [TestMethod]
    public void Pairwise_SourceHasMultipleElements_ReturnsExpectedPairs()
    {
        var result = _defaultSource.Pairwise().ToList();

        Assert.HasCount(4, result);
        Assert.AreEqual((1, 2), result[0]);
        Assert.AreEqual((2, 3), result[1]);
        Assert.AreEqual((3, 4), result[2]);
        Assert.AreEqual((4, 5), result[3]);
    }

    [TestMethod]
    public void Pairwise_SourceHasOneElement_ReturnsEmpty()
    {
        int[] source = [1];
        var result = source.Pairwise().ToList();

        Assert.IsEmpty(result);
    }

    [TestMethod]
    public void Pairwise_SourceIsEmpty_ReturnsEmpty()
    {
        int[] source = [];
        var result = source.Pairwise().ToList();

        Assert.IsEmpty(result);
    }
}
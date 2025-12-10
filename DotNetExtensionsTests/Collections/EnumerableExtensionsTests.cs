using DotNetExtensions.Collections;

namespace DotNetExtensionsTests.Collections;

[TestClass]
public partial class EnumerableExtensionsTests
{
    private static readonly int[] DefaultSource = [1, 2, 3, 4, 5];

    [TestMethod]
    public void Pairwise_SourceHasMultipleElements_ReturnsExpectedPairs()
    {
        var result = DefaultSource.Pairwise().ToList();

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

    [TestMethod]
    public void Adjacent_ValidLength_ReturnsSlidingWindows()
    {
        var result = DefaultSource.Adjacent(3).ToList();

        Assert.HasCount(3, result);
        CollectionAssert.AreEqual(DefaultSource[..3], result[0]);
        CollectionAssert.AreEqual(DefaultSource[1..4], result[1]);
        CollectionAssert.AreEqual(DefaultSource[2..5], result[2]);
    }

    [TestMethod]
    public void Adjacent_LengthGreaterThanSource_ReturnsEmpty()
    {
        var result = DefaultSource.Adjacent(6).ToList();

        Assert.IsEmpty(result);
    }

    [TestMethod]
    public void Adjacent_LengthZero_ReturnsEmpty()
    {
        var result = DefaultSource.Adjacent(0).ToList();

        Assert.IsEmpty(result);
    }

    [TestMethod]
    public void Adjacent_LengthOne_ReturnsSingleElementWindows()
    {
        var result = DefaultSource.Adjacent(1).ToList();

        Assert.HasCount(5, result);
        CollectionAssert.AreEqual(DefaultSource[..1], result[0]);
        CollectionAssert.AreEqual(DefaultSource[1..2], result[1]);
        CollectionAssert.AreEqual(DefaultSource[2..3], result[2]);
        CollectionAssert.AreEqual(DefaultSource[3..4], result[3]);
    }

    [TestMethod]
    public void Adjacent_LengthEqualsSource_ReturnsWholeSourceAsWindow()
    {
        var result = DefaultSource.Adjacent(5).ToList();

        Assert.HasCount(1, result);
        CollectionAssert.AreEqual(DefaultSource, result[0]);
    }

    [TestMethod]
    public void SkipAt_ValidIndex_RemovesElementAtIndex()
    {
        var result = DefaultSource.SkipAt(4).ToList();

        Assert.HasCount(4, result);
        CollectionAssert.AreEqual(DefaultSource[..4], result);
    }

    [TestMethod]
    public void SkipAt_IndexOutOfRange_ThrowsArgumentOutOfRangeException()
    {
        int[] source = [1, 2, 3, 4, 5];
        Assert.ThrowsExactly<ArgumentOutOfRangeException>(() => source.SkipAt(5).ToList());
    }

    [TestMethod]
    public void SkipAt_NegativeIndex_ThrowsArgumentOutOfRangeException()
    {
        Assert.ThrowsExactly<ArgumentOutOfRangeException>(() => DefaultSource.SkipAt(-1));
    }

    [TestMethod]
    public void SkipAt_EmptySource_ThrowsArgumentOutOfRangeException()
    {
        int[] source = [];
        Assert.ThrowsExactly<ArgumentOutOfRangeException>(() => source.SkipAt(0).ToList());
    }

    [TestMethod]
    public void SkipAtOrDefault_ValidIndex_RemovesElementAtIndex()
    {
        var result = DefaultSource.SkipAtOrDefault(2).ToList();
        int[] expected = [1, 2, 4, 5];

        CollectionAssert.AreEqual(expected, result);
    }

    [TestMethod]
    public void SkipAtOrDefault_NegativeIndex_ReturnsOriginalSequence()
    {
        var result = DefaultSource.SkipAtOrDefault(-1).ToList();

        CollectionAssert.AreEqual(DefaultSource, result);
    }

    [TestMethod]
    public void SkipAtOrDefault_IndexOutOfRange_ReturnsOriginalSequence()
    {
        var result = DefaultSource.SkipAtOrDefault(5).ToList();

        CollectionAssert.AreEqual(DefaultSource, result);
    }

    [TestMethod]
    public void SkipAtOrDefault_EmptySource_ReturnsEmpty()
    {
        int[] source = [];
        var result = source.SkipAtOrDefault(0).ToList();

        Assert.IsEmpty(result);
    }
    
    [TestMethod]
    public void Pairs_SourceHasMultipleElements_ReturnsExpectedPairs()
    {
        AssertPairsAreExpected(DefaultSource);
    }
    
    [TestMethod]
    public void Pairs_SourceIsCollection_ReturnsExpectedPairs()
    {
        AssertPairsAreExpected(DefaultSource.ToHashSet());
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
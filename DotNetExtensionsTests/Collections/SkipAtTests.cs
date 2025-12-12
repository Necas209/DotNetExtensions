using DotNetExtensions.Collections;

namespace DotNetExtensionsTests.Collections;

public partial class EnumerableExtensionsTests
{
    [TestMethod]
    public void SkipAt_ValidIndex_RemovesElementAtIndex()
    {
        var result = _defaultSource.SkipAt(4).ToList();

        Assert.HasCount(4, result);
        CollectionAssert.AreEqual(_defaultSource[..4], result);
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
        Assert.ThrowsExactly<ArgumentOutOfRangeException>(() => _defaultSource.SkipAt(-1));
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
        var result = _defaultSource.SkipAtOrDefault(2).ToList();
        int[] expected = [1, 2, 4, 5];

        CollectionAssert.AreEqual(expected, result);
    }

    [TestMethod]
    public void SkipAtOrDefault_NegativeIndex_ReturnsOriginalSequence()
    {
        var result = _defaultSource.SkipAtOrDefault(-1).ToList();

        CollectionAssert.AreEqual(_defaultSource, result);
    }

    [TestMethod]
    public void SkipAtOrDefault_IndexOutOfRange_ReturnsOriginalSequence()
    {
        var result = _defaultSource.SkipAtOrDefault(5).ToList();

        CollectionAssert.AreEqual(_defaultSource, result);
    }

    [TestMethod]
    public void SkipAtOrDefault_EmptySource_ReturnsEmpty()
    {
        int[] source = [];
        var result = source.SkipAtOrDefault(0).ToList();

        Assert.IsEmpty(result);
    }
}
using DotNetExtensions.Collections;

namespace DotNetExtensionsTests.Collections;

public partial class EnumerableExtensionsTests
{
    [TestMethod]
    public void Combinations_LengthZero_ReturnsSingleEmptyCombination()
    {
        var result = _defaultSource.Combinations(0).ToList();
        Assert.HasCount(1, result);
        Assert.IsEmpty(result[0]);
    }

    [TestMethod]
    public void Combinations_LengthOne_ReturnsAllSingleElementCombinations()
    {
        var result = _defaultSource.Combinations(1).ToList();
        Assert.HasCount(5, result);
        Assert.IsTrue(result[0] is [1]);
        Assert.IsTrue(result[1] is [2]);
        Assert.IsTrue(result[2] is [3]);
        Assert.IsTrue(result[3] is [4]);
        Assert.IsTrue(result[4] is [5]);
    }

    [TestMethod]
    public void Combinations_LengthTwo_ReturnsAllTwoElementCombinations()
    {
        var result = _defaultSource.Combinations(2).ToList();
        Assert.HasCount(10, result);
        Assert.IsTrue(result[0] is [1, 2]);
        Assert.IsTrue(result[1] is [1, 3]);
        Assert.IsTrue(result[2] is [1, 4]);
        Assert.IsTrue(result[3] is [1, 5]);
        Assert.IsTrue(result[4] is [2, 3]);
        Assert.IsTrue(result[5] is [2, 4]);
        Assert.IsTrue(result[6] is [2, 5]);
        Assert.IsTrue(result[7] is [3, 4]);
        Assert.IsTrue(result[8] is [3, 5]);
        Assert.IsTrue(result[9] is [4, 5]);
    }

    [TestMethod]
    public void Combinations_LengthThree_ReturnsAllThreeElementCombinations()
    {
        var result = _defaultSource.Combinations(3).ToList();
        Assert.HasCount(10, result);
        Assert.IsTrue(result[0] is [1, 2, 3]);
        Assert.IsTrue(result[1] is [1, 2, 4]);
        Assert.IsTrue(result[2] is [1, 2, 5]);
        Assert.IsTrue(result[3] is [1, 3, 4]);
        Assert.IsTrue(result[4] is [1, 3, 5]);
        Assert.IsTrue(result[5] is [1, 4, 5]);
        Assert.IsTrue(result[6] is [2, 3, 4]);
        Assert.IsTrue(result[7] is [2, 3, 5]);
        Assert.IsTrue(result[8] is [2, 4, 5]);
        Assert.IsTrue(result[9] is [3, 4, 5]);
    }

    [TestMethod]
    public void Combinations_LengthGreaterThanSource_ReturnsEmpty()
    {
        var result = _defaultSource.Combinations(6).ToList();
        Assert.IsEmpty(result);
    }

    [TestMethod]
    public void Combinations_NegativeLength_ThrowsArgumentOutOfRangeException()
    {
        Assert.ThrowsExactly<ArgumentOutOfRangeException>(() => _defaultSource.Combinations(-1));
    }
}
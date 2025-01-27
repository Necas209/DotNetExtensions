using System.Collections.Immutable;
using DotNetExtensions;

namespace DotNetExtensionsTests;

public partial class EnumerableExtensionsTests
{
    [TestMethod]
    public void TestCombinationsWithZeroLength()
    {
        int[] source = [1, 2, 3, 4, 5];
        var result = source.Combinations(0)
            .Select(x => x.ToImmutableArray())
            .ToImmutableArray();

        Assert.AreEqual(1, result.Length);
        Assert.IsTrue(result[0] is []);
    }

    [TestMethod]
    public void TestCombinationsWithOneLength()
    {
        int[] source = [1, 2, 3, 4, 5];
        var result = source.Combinations(1)
            .Select(x => x.ToImmutableArray())
            .ToImmutableArray();

        Assert.AreEqual(5, result.Length);
        Assert.IsTrue(result[0] is [1]);
        Assert.IsTrue(result[1] is [2]);
        Assert.IsTrue(result[2] is [3]);
        Assert.IsTrue(result[3] is [4]);
        Assert.IsTrue(result[4] is [5]);
    }

    [TestMethod]
    public void TestCombinationsWithTwoLength()
    {
        int[] source = [1, 2, 3, 4, 5];
        var result = source.Combinations(2)
            .Select(x => x.ToImmutableArray())
            .ToImmutableArray();

        Assert.AreEqual(10, result.Length);
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
    public void TestCombinationsWithThreeLength()
    {
        int[] source = [1, 2, 3, 4, 5];
        var result = source.Combinations(3)
            .Select(x => x.ToImmutableArray())
            .ToImmutableArray();

        Assert.AreEqual(10, result.Length);
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
    public void TestCombinationsWithLengthGreaterThanSource()
    {
        int[] source = [1, 2, 3, 4, 5];
        var result = source.Combinations(6).ToImmutableArray();

        Assert.AreEqual(0, result.Length);
    }
}
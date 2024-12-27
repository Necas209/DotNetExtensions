using System.Collections.Immutable;
using DotNetExtensions;

namespace DotNetExtensionsTests;

[TestClass]
public class EnumerableExtensionsTests
{
    [TestMethod]
    public void TestPairwiseWithElements()
    {
        int[] source = [1, 2, 3, 4, 5];
        var result = source.Pairwise().ToImmutableArray();

        Assert.AreEqual(4, result.Length);
        Assert.AreEqual((1, 2), result[0]);
        Assert.AreEqual((2, 3), result[1]);
        Assert.AreEqual((3, 4), result[2]);
        Assert.AreEqual((4, 5), result[3]);
    }

    [TestMethod]
    public void TestPairwiseWithOneElement()
    {
        int[] source = [1];
        var result = source.Pairwise().ToImmutableArray();

        Assert.AreEqual(0, result.Length);
    }

    [TestMethod]
    public void TestPairwiseWithNoElements()
    {
        int[] source = [];
        var result = source.Pairwise().ToImmutableArray();

        Assert.AreEqual(0, result.Length);
    }

    [TestMethod]
    public void TestQuintuplesWithElements()
    {
        int[] source = [1, 2, 3, 4, 5, 6, 7, 8, 9];
        var result = source.Quintuples().ToImmutableArray();

        Assert.AreEqual(5, result.Length);
        Assert.AreEqual((1, 2, 3, 4, 5), result[0]);
        Assert.AreEqual((2, 3, 4, 5, 6), result[1]);
        Assert.AreEqual((3, 4, 5, 6, 7), result[2]);
        Assert.AreEqual((4, 5, 6, 7, 8), result[3]);
        Assert.AreEqual((5, 6, 7, 8, 9), result[4]);
    }

    [TestMethod]
    public void TestAdjacentWithValidLength()
    {
        int[] source = [1, 2, 3, 4, 5];
        var result = source.Adjacent(3).ToArray();

        Assert.AreEqual(3, result.Length);
        Assert.IsTrue(result[0] is [1, 2, 3]);
        Assert.IsTrue(result[1] is [2, 3, 4]);
        Assert.IsTrue(result[2] is [3, 4, 5]);
    }

    [TestMethod]
    public void TestAdjacentWithInvalidLength()
    {
        int[] source = [1, 2, 3, 4, 5];
        var result = source.Adjacent(6).ToArray();

        Assert.AreEqual(0, result.Length);
    }

    [TestMethod]
    public void TestSkipAtWithValidIndex()
    {
        int[] source = [1, 2, 3, 4, 5];
        var result = source.SkipAt(4).ToImmutableArray();

        Assert.AreEqual(4, result.Length);
        Assert.AreEqual(1, result[0]);
        Assert.AreEqual(2, result[1]);
        Assert.AreEqual(3, result[2]);
        Assert.AreEqual(4, result[3]);
    }

    [TestMethod]
    public void TestSkipAtWithInvalidIndex()
    {
        int[] source = [1, 2, 3, 4, 5];
        var result = source.SkipAt(5).ToImmutableArray();

        Assert.AreEqual(5, result.Length);
        Assert.AreEqual(1, result[0]);
        Assert.AreEqual(2, result[1]);
        Assert.AreEqual(3, result[2]);
        Assert.AreEqual(4, result[3]);
        Assert.AreEqual(5, result[4]);
    }

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
}
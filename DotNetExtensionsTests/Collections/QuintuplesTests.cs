using System.Collections.Immutable;
using DotNetExtensions.Collections;

namespace DotNetExtensionsTests.Collections;

public partial class EnumerableExtensionsTests
{
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
    public void TestQuintuplesWithZeroElements()
    {
        int[] source = [];
        var result = source.Quintuples().ToImmutableArray();

        Assert.AreEqual(0, result.Length);
    }

    [TestMethod]
    public void TestQuintuplesWithOneElement()
    {
        int[] source = [1];
        var result = source.Quintuples().ToImmutableArray();

        Assert.AreEqual(0, result.Length);
    }

    [TestMethod]
    public void TestQuintuplesWithTwoElements()
    {
        int[] source = [1, 2];
        var result = source.Quintuples().ToImmutableArray();

        Assert.AreEqual(0, result.Length);
    }

    [TestMethod]
    public void TestQuintuplesWithThreeElements()
    {
        int[] source = [1, 2, 3];
        var result = source.Quintuples().ToImmutableArray();

        Assert.AreEqual(0, result.Length);
    }

    [TestMethod]
    public void TestQuintuplesWithFourElements()
    {
        int[] source = [1, 2, 3, 4];
        var result = source.Quintuples().ToImmutableArray();

        Assert.AreEqual(0, result.Length);
    }
}
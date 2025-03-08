using System.Collections.Immutable;
using DotNetExtensions.Collections;

namespace DotNetExtensionsTests.Collections;

[TestClass]
public partial class EnumerableExtensionsTests
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
}
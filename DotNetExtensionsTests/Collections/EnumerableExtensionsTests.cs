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
        var result = source.Pairwise().ToArray();

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

        Assert.AreEqual([], result);
    }

    [TestMethod]
    public void TestAdjacentWithZeroLength()
    {
        int[] source = [1, 2, 3, 4, 5];
        var result = source.Adjacent(0).ToArray();

        Assert.AreEqual([], result);
    }

    [TestMethod]
    public void TestAdjacentWithLengthOne()
    {
        int[] source = [1, 2, 3, 4, 5];
        var result = source.Adjacent(1).ToArray();

        var expected = ImmutableArray.Create<int[]>([1], [2], [3], [4], [5]);
        CollectionAssert.AreEqual(expected, result);
    }

    [TestMethod]
    public void TestAdjacentWithLengthEqualToSource()
    {
        int[] source = [1, 2, 3, 4, 5];
        var result = source.Adjacent(5).ToArray();

        Assert.AreEqual(1, result.Length);
        CollectionAssert.AreEqual(source, result[0]);
    }

    [TestMethod]
    public void TestSkipAtWithValidIndex()
    {
        int[] source = [1, 2, 3, 4, 5];
        var result = source.SkipAt(4).ToArray();
        var expected = ImmutableArray.Create(1, 2, 3, 4);

        CollectionAssert.AreEqual(expected, result);
    }

    [TestMethod]
    public void TestSkipAtWithInvalidIndex()
    {
        int[] source = [1, 2, 3, 4, 5];
        Assert.ThrowsExactly<ArgumentOutOfRangeException>(() => source.SkipAt(5).ToArray());
    }

    [TestMethod]
    public void TestSkipAtWithNegativeIndex()
    {
        int[] source = [1, 2, 3, 4, 5];
        Assert.ThrowsExactly<ArgumentOutOfRangeException>(() => source.SkipAt(-1).ToArray());
    }

    [TestMethod]
    public void TestSkipAtWithEmptySource()
    {
        int[] source = [];
        Assert.ThrowsExactly<ArgumentOutOfRangeException>(() => source.SkipAt(0).ToArray());
    }

    [TestMethod]
    public void TestSkipAtOrDefaultWithValidIndex()
    {
        int[] source = [1, 2, 3, 4, 5];
        var result = source.SkipAtOrDefault(2).ToArray();
        var expected = new[] { 1, 2, 4, 5 };

        CollectionAssert.AreEqual(expected, result);
    }

    [TestMethod]
    public void TestSkipAtOrDefaultWithNegativeIndex()
    {
        int[] source = [1, 2, 3, 4, 5];
        var result = source.SkipAtOrDefault(-1).ToArray();

        CollectionAssert.AreEqual(source, result);
    }

    [TestMethod]
    public void TestSkipAtOrDefaultWithOutOfRangeIndex()
    {
        int[] source = [1, 2, 3, 4, 5];
        var result = source.SkipAtOrDefault(5).ToArray();

        CollectionAssert.AreEqual(source, result);
    }

    [TestMethod]
    public void TestSkipAtOrDefaultWithEmptySource()
    {
        int[] source = [];
        var result = source.SkipAtOrDefault(0).ToArray();

        Assert.AreEqual(source, result);
    }
}
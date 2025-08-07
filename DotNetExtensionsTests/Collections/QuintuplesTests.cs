using DotNetExtensions.Collections;

namespace DotNetExtensionsTests.Collections;

public partial class EnumerableExtensionsTests
{
    [TestMethod]
    public void Quintuples_SourceHasEnoughElements_ReturnsExpectedQuintuples()
    {
        int[] source = [1, 2, 3, 4, 5, 6, 7, 8, 9];
        var result = source.Quintuples().ToList();

        Assert.HasCount(5, result);
        Assert.AreEqual((1, 2, 3, 4, 5), result[0]);
        Assert.AreEqual((2, 3, 4, 5, 6), result[1]);
        Assert.AreEqual((3, 4, 5, 6, 7), result[2]);
        Assert.AreEqual((4, 5, 6, 7, 8), result[3]);
        Assert.AreEqual((5, 6, 7, 8, 9), result[4]);
    }

    [TestMethod]
    public void Quintuples_SourceIsEmpty_ReturnsEmpty()
    {
        int[] source = [];
        var result = source.Quintuples().ToList();

        Assert.IsEmpty(result);
    }

    [TestMethod]
    public void Quintuples_SourceHasOneElement_ReturnsEmpty()
    {
        int[] source = [1];
        var result = source.Quintuples().ToList();

        Assert.IsEmpty(result);
    }

    [TestMethod]
    public void Quintuples_SourceHasTwoElements_ReturnsEmpty()
    {
        int[] source = [1, 2];
        var result = source.Quintuples().ToList();

        Assert.IsEmpty(result);
    }

    [TestMethod]
    public void Quintuples_SourceHasThreeElements_ReturnsEmpty()
    {
        int[] source = [1, 2, 3];
        var result = source.Quintuples().ToList();

        Assert.IsEmpty(result);
    }

    [TestMethod]
    public void Quintuples_SourceHasFourElements_ReturnsEmpty()
    {
        int[] source = [1, 2, 3, 4];
        var result = source.Quintuples().ToList();

        Assert.IsEmpty(result);
    }
}
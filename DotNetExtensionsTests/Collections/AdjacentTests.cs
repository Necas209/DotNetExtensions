using DotNetExtensions.Collections;

namespace DotNetExtensionsTests.Collections;

public partial class EnumerableExtensionsTests
{
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
}
using DotNetExtensions.Collections;

namespace DotNetExtensionsTests.Collections;

public partial class EnumerableExtensionsTests
{
    [TestMethod]
    public void Adjacent_ValidLength_ReturnsSlidingWindows()
    {
        var result = _defaultSource.Adjacent(3).ToList();

        Assert.HasCount(3, result);
        CollectionAssert.AreEqual(_defaultSource[..3], result[0]);
        CollectionAssert.AreEqual(_defaultSource[1..4], result[1]);
        CollectionAssert.AreEqual(_defaultSource[2..5], result[2]);
    }

    [TestMethod]
    public void Adjacent_LengthGreaterThanSource_ReturnsEmpty()
    {
        var result = _defaultSource.Adjacent(6).ToList();

        Assert.IsEmpty(result);
    }

    [TestMethod]
    public void Adjacent_LengthZero_ReturnsEmpty()
    {
        var result = _defaultSource.Adjacent(0).ToList();

        Assert.IsEmpty(result);
    }

    [TestMethod]
    public void Adjacent_LengthOne_ReturnsSingleElementWindows()
    {
        var result = _defaultSource.Adjacent(1).ToList();

        Assert.HasCount(5, result);
        CollectionAssert.AreEqual(_defaultSource[..1], result[0]);
        CollectionAssert.AreEqual(_defaultSource[1..2], result[1]);
        CollectionAssert.AreEqual(_defaultSource[2..3], result[2]);
        CollectionAssert.AreEqual(_defaultSource[3..4], result[3]);
    }

    [TestMethod]
    public void Adjacent_LengthEqualsSource_ReturnsWholeSourceAsWindow()
    {
        var result = _defaultSource.Adjacent(5).ToList();

        Assert.HasCount(1, result);
        CollectionAssert.AreEqual(_defaultSource, result[0]);
    }
}
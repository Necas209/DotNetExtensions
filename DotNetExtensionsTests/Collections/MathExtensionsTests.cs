using DotNetExtensions.Collections;

namespace DotNetExtensionsTests.Collections;

public partial class EnumerableExtensionsTests
{
    [TestMethod]
    public void Product_SourceHasMultipleElements_ReturnsCorrectProduct()
    {
        var result = _defaultSource.Product();
        Assert.AreEqual(120, result);
    }

    [TestMethod]
    public void Product_SourceHasOneElement_ReturnsThatElement()
    {
        int[] source = [7];
        var result = source.Product();
        Assert.AreEqual(7, result);
    }

    [TestMethod]
    public void Product_SourceIsEmpty_ThrowsInvalidOperationException()
    {
        int[] source = [];
        Assert.ThrowsExactly<InvalidOperationException>(() => source.Product());
    }

    [TestMethod]
    public void And_SourceHasMultipleElements_ReturnsCorrectAnd()
    {
        int[] source = [1, 3, 7, 15];
        var result = source.And();
        Assert.AreEqual(1, result);
    }

    [TestMethod]
    public void And_SourceHasOneElement_ReturnsThatElement()
    {
        int[] source = [7];
        var result = source.And();
        Assert.AreEqual(7, result);
    }

    [TestMethod]
    public void And_SourceIsEmpty_ThrowsInvalidOperationException()
    {
        int[] source = [];
        Assert.ThrowsExactly<InvalidOperationException>(() => source.And());
    }

    [TestMethod]
    public void Or_SourceHasMultipleElements_ReturnsCorrectOr()
    {
        var result = _defaultSource.Or();
        Assert.AreEqual(7, result);
    }

    [TestMethod]
    public void Or_SourceHasOneElement_ReturnsThatElement()
    {
        int[] source = [8];
        var result = source.Or();
        Assert.AreEqual(8, result);
    }

    [TestMethod]
    public void Or_SourceIsEmpty_ThrowsInvalidOperationException()
    {
        int[] source = [];
        Assert.ThrowsExactly<InvalidOperationException>(() => source.Or());
    }

    [TestMethod]
    public void Xor_SourceHasMultipleElements_ReturnsCorrectXor()
    {
        var result = _defaultSource.Xor();
        Assert.AreEqual(1, result);
    }

    [TestMethod]
    public void Xor_SourceHasOneElement_ReturnsThatElement()
    {
        int[] source = [9];
        var result = source.Xor();
        Assert.AreEqual(9, result);
    }

    [TestMethod]
    public void Xor_SourceIsEmpty_ThrowsInvalidOperationException()
    {
        int[] source = [];
        Assert.ThrowsExactly<InvalidOperationException>(() => source.Xor());
    }
}
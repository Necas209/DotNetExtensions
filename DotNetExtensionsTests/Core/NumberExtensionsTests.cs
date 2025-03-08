using DotNetExtensions.Core;

namespace DotNetExtensionsTests.Core;

[TestClass]
public class NumberExtensionsTests
{
    [TestMethod]
    public void TestNumberOfDigits()
    {
        Assert.AreEqual(1ul, 0.NumberOfDigits());
        Assert.AreEqual(1ul, 1.NumberOfDigits());
        Assert.AreEqual(2ul, 10.NumberOfDigits());
        Assert.AreEqual(1ul, (-1).NumberOfDigits());
        Assert.AreEqual(2ul, (-10).NumberOfDigits());
        Assert.AreEqual(3ul, (-100).NumberOfDigits());
        Assert.AreEqual(10ul, int.MaxValue.NumberOfDigits());
        Assert.AreEqual(10ul, int.MinValue.NumberOfDigits());
    }

    [TestMethod]
    public void TestSplitNumber()
    {
        Assert.AreEqual((0, 0), 0.Split());
        Assert.AreEqual((0, 1), 1.Split());
        Assert.AreEqual((1, 0), 10.Split());
        Assert.AreEqual((12, 34), 1234.Split());
        Assert.AreEqual((123, 456), 123456.Split());
        Assert.AreEqual((123, 4567), 1234567.Split());
    }

    [TestMethod]
    public void TestIsPalindrome()
    {
        Assert.IsTrue(0.IsPalindrome());
        Assert.IsTrue(1.IsPalindrome());
        Assert.IsTrue(11.IsPalindrome());
        Assert.IsTrue(121.IsPalindrome());
        Assert.IsTrue(12321.IsPalindrome());
        Assert.IsTrue(1234321.IsPalindrome());
        Assert.IsFalse(12.IsPalindrome());
        Assert.IsFalse(123.IsPalindrome());
        Assert.IsFalse(1234.IsPalindrome());
        Assert.IsFalse(int.MaxValue.IsPalindrome());
        Assert.IsFalse(int.MinValue.IsPalindrome());
    }

    [TestMethod]
    public void TestReverse()
    {
        Assert.AreEqual(0, 0.Reverse());
        Assert.AreEqual(1, 1.Reverse());
        Assert.AreEqual(1, 10.Reverse());
        Assert.AreEqual(21, 12.Reverse());
        Assert.AreEqual(4321, 1234.Reverse());
        Assert.AreEqual(7654321, 1234567.Reverse());
        Assert.AreEqual(-1, (-1).Reverse());
        Assert.AreEqual(-1, (-10).Reverse());
        Assert.AreEqual(-21, (-12).Reverse());
        Assert.AreEqual(-4321, (-1234).Reverse());
        Assert.AreEqual(-7654321, (-1234567).Reverse());
        Assert.ThrowsExactly<OverflowException>(() => _ = int.MaxValue.Reverse());
    }
}
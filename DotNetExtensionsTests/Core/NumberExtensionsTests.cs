using DotNetExtensions.Core;

namespace DotNetExtensionsTests.Core;

[TestClass]
public class NumberExtensionsTests
{
    [TestMethod]
    [DataRow(0, 1)]
    [DataRow(1, 1)]
    [DataRow(10, 2)]
    [DataRow(-1, 1)]
    [DataRow(-10, 2)]
    [DataRow(-100, 3)]
    [DataRow(int.MaxValue, 10)]
    [DataRow(int.MinValue, 10)]
    public void NumberOfDigits_VariousInputs_ReturnsExpected(int value, int expected)
    {
        Assert.AreEqual(expected, value.NumberOfDigits());
    }

    [TestMethod]
    [DataRow(0, 0, 0)]
    [DataRow(1, 0, 1)]
    [DataRow(10, 1, 0)]
    [DataRow(1234, 12, 34)]
    [DataRow(123456, 123, 456)]
    [DataRow(1234567, 123, 4567)]
    public void Split_VariousInputs_ReturnsExpected(int value, int expectedLeft, int expectedRight)
    {
        Assert.AreEqual((expectedLeft, expectedRight), value.Split());
    }

    [TestMethod]
    public void Split_NegativeNumber_ThrowsArgumentOutOfRangeException()
    {
        Assert.ThrowsExactly<ArgumentOutOfRangeException>(() => (-123).Split());
    }

    [TestMethod]
    [DataRow(0, true)]
    [DataRow(1, true)]
    [DataRow(11, true)]
    [DataRow(121, true)]
    [DataRow(12321, true)]
    [DataRow(1234321, true)]
    [DataRow(12, false)]
    [DataRow(123, false)]
    [DataRow(1234, false)]
    [DataRow(int.MaxValue, false)]
    [DataRow(int.MinValue, false)]
    public void IsPalindrome_VariousInputs_ReturnsExpected(int value, bool expected)
    {
        Assert.AreEqual(expected, value.IsPalindrome());
    }

    [TestMethod]
    [DataRow(0, 0)]
    [DataRow(1, 1)]
    [DataRow(10, 1)]
    [DataRow(12, 21)]
    [DataRow(1234, 4321)]
    [DataRow(1234567, 7654321)]
    [DataRow(-1, -1)]
    [DataRow(-10, -1)]
    [DataRow(-12, -21)]
    [DataRow(-1234, -4321)]
    [DataRow(-1234567, -7654321)]
    public void Reverse_VariousInputs_ReturnsExpected(int value, int expected)
    {
        Assert.AreEqual(expected, value.Reverse());
    }

    [TestMethod]
    public void Reverse_IntMaxValue_ThrowsOverflowException()
    {
        Assert.ThrowsExactly<OverflowException>(() => int.MaxValue.Reverse());
    }
}
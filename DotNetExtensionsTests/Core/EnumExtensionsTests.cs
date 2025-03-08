using DotNetExtensions.Core;

namespace DotNetExtensionsTests.Core;

[TestClass]
public class EnumExtensionsTests
{
    [Flags]
    private enum ByteFlags : byte
    {
        Flag1 = 1 << 0,
        Flag2 = 1 << 1,
        Flag3 = 1 << 2,
        Flag4 = 1 << 3
    }

    [TestMethod]
    public void TestHasAnyFlagByte()
    {
        const ByteFlags flags = ByteFlags.Flag1 | ByteFlags.Flag2 | ByteFlags.Flag4;

        Assert.IsTrue(flags.HasAnyFlag(ByteFlags.Flag1));
        Assert.IsTrue(flags.HasAnyFlag(ByteFlags.Flag2));
        Assert.IsTrue(flags.HasAnyFlag(ByteFlags.Flag4));
        Assert.IsFalse(flags.HasAnyFlag(ByteFlags.Flag3));
    }

    [Flags]
    private enum UShortFlags : ushort
    {
        Flag1 = 1 << 0,
        Flag2 = 1 << 1,
        Flag3 = 1 << 2,
        Flag4 = 1 << 3
    }

    [TestMethod]
    public void TestHasAnyFlagShort()
    {
        const UShortFlags flags = UShortFlags.Flag1 | UShortFlags.Flag2 | UShortFlags.Flag4;

        Assert.IsTrue(flags.HasAnyFlag(UShortFlags.Flag1));
        Assert.IsTrue(flags.HasAnyFlag(UShortFlags.Flag2));
        Assert.IsTrue(flags.HasAnyFlag(UShortFlags.Flag4));
        Assert.IsFalse(flags.HasAnyFlag(UShortFlags.Flag3));
    }

    [Flags]
    private enum UIntFlags : uint
    {
        Flag1 = 1 << 0,
        Flag2 = 1 << 1,
        Flag3 = 1 << 2,
        Flag4 = 1 << 3
    }

    [TestMethod]
    public void TestHasAnyFlagUInt()
    {
        const UIntFlags flags = UIntFlags.Flag1 | UIntFlags.Flag2 | UIntFlags.Flag4;

        Assert.IsTrue(flags.HasAnyFlag(UIntFlags.Flag1));
        Assert.IsTrue(flags.HasAnyFlag(UIntFlags.Flag2));
        Assert.IsTrue(flags.HasAnyFlag(UIntFlags.Flag4));
        Assert.IsFalse(flags.HasAnyFlag(UIntFlags.Flag3));
    }

    [Flags]
    private enum ULongFlags : ulong
    {
        Flag1 = 1 << 0,
        Flag2 = 1 << 1,
        Flag3 = 1 << 2,
        Flag4 = 1 << 3
    }

    [TestMethod]
    public void TestHasAnyFlagULong()
    {
        const ULongFlags flags = ULongFlags.Flag1 | ULongFlags.Flag2 | ULongFlags.Flag4;

        Assert.IsTrue(flags.HasAnyFlag(ULongFlags.Flag1));
        Assert.IsTrue(flags.HasAnyFlag(ULongFlags.Flag2));
        Assert.IsTrue(flags.HasAnyFlag(ULongFlags.Flag4));
        Assert.IsFalse(flags.HasAnyFlag(ULongFlags.Flag3));
    }
}
using DotNetExtensions;

namespace DotNetExtensionsTests;

[TestClass]
public class AccumulatorTests
{
    [TestMethod]
    public void Add_SingleValue_UpdatesProperties()
    {
        var accumulator = new Accumulator<int>();
        accumulator.Add(5);

        Assert.AreEqual(5, accumulator.Min);
        Assert.AreEqual(5, accumulator.Max);
        Assert.AreEqual(5, accumulator.Sum);
        Assert.AreEqual(1, accumulator.Count);
        Assert.AreEqual(5, accumulator.Mean);
    }

    [TestMethod]
    public void Add_MultipleValues_UpdatesProperties()
    {
        var accumulator = new Accumulator<int>();
        accumulator.Add(5);
        accumulator.Add(10);
        accumulator.Add(3);

        Assert.AreEqual(3, accumulator.Min);
        Assert.AreEqual(10, accumulator.Max);
        Assert.AreEqual(18, accumulator.Sum);
        Assert.AreEqual(3, accumulator.Count);
        Assert.AreEqual(6, accumulator.Mean);
    }

    [TestMethod]
    public void Reset_ResetsProperties()
    {
        var accumulator = new Accumulator<int>();
        accumulator.Add(5);
        accumulator.Add(10);
        accumulator.Reset();

        Assert.AreEqual(int.MaxValue, accumulator.Min);
        Assert.AreEqual(int.MinValue, accumulator.Max);
        Assert.AreEqual(0, accumulator.Sum);
        Assert.AreEqual(0, accumulator.Count);
        Assert.ThrowsException<InvalidOperationException>(() => accumulator.Mean);
    }
}
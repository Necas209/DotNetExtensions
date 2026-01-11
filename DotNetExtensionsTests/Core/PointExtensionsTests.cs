using System.Drawing;
using DotNetExtensions.Core;

namespace DotNetExtensionsTests.Core;

[TestClass]
public class PointExtensionsTests
{
    [TestMethod]
    public void GetNeighbors_WithOrigin_ReturnsExpectedNeighbors()
    {
        var point = new Point(0, 0);
        var (left, right, top, bottom) = point.GetNeighbors();

        Assert.AreEqual(new Point(-1, 0), left);
        Assert.AreEqual(new Point(1, 0), right);
        Assert.AreEqual(new Point(0, -1), top);
        Assert.AreEqual(new Point(0, 1), bottom);
    }

    [TestMethod]
    public void GetCorners_WithOrigin_ReturnsExpectedCorners()
    {
        var point = new Point(0, 0);
        var (topLeft, topRight, bottomLeft, bottomRight) = point.GetCorners();

        Assert.AreEqual(new Point(-1, -1), topLeft);
        Assert.AreEqual(new Point(1, -1), topRight);
        Assert.AreEqual(new Point(-1, 1), bottomLeft);
        Assert.AreEqual(new Point(1, 1), bottomRight);
    }

    [TestMethod]
    public void ManhattanDistance_WithPositiveCoordinates_ReturnsExpectedDistance()
    {
        var point = new Point(0, 0);
        var other = new Point(3, 4);

        Assert.AreEqual(7, point.ManhattanDistance(other));
    }

    [TestMethod]
    public void ManhattanDistance_WithSamePoint_ReturnsZero()
    {
        var point = new Point(0, 0);
        var other = new Point(0, 0);

        Assert.AreEqual(0, point.ManhattanDistance(other));
    }

    [TestMethod]
    public void ManhattanDistance_WithNegativeCoordinates_ReturnsExpectedDistance()
    {
        var point = new Point(0, 0);
        var other = new Point(-3, -4);

        Assert.AreEqual(7, point.ManhattanDistance(other));
    }
}
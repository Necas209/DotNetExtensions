using System.Drawing;

namespace DotNetExtensions.Core;

/// <summary>
/// Provides extension methods for working with <see cref="Point"/> structures.
/// </summary>
public static class PointExtensions
{
    /// <summary>
    /// Gets the four immediate neighbors of a given point: left, right, top, and bottom.
    /// </summary>
    /// <param name="point">The point for which to find the neighbors.</param>
    /// <returns>
    /// A tuple containing the neighbors of the given point:
    /// <list type="bullet">
    /// <item>Left: The point to the left of the given point (X - 1, Y).</item>
    /// <item>Right: The point to the right of the given point (X + 1, Y).</item>
    /// <item>Top: The point above the given point (X, Y - 1).</item>
    /// <item>Bottom: The point below the given point (X, Y + 1).</item>
    /// </list>
    /// </returns>
    public static (Point Left, Point Right, Point Top, Point Bottom) GetNeighbors(this Point point)
    {
        var left = point with { X = point.X - 1 };
        var right = point with { X = point.X + 1 };
        var top = point with { Y = point.Y - 1 };
        var bottom = point with { Y = point.Y + 1 };
        return (left, right, top, bottom);
    }

    /// <summary>
    /// Calculates the Manhattan distance between two points.
    /// </summary>
    /// <param name="point">The starting point.</param>
    /// <param name="other">The target point.</param>
    /// <returns>The Manhattan distance between the two points.</returns>
    /// <remarks>
    /// The Manhattan distance is calculated
    /// by summing the absolute differences between the X coordinates and the Y coordinates.
    /// It is commonly used in grid-based distance calculations where diagonal movement is not allowed.
    /// </remarks>
    public static int ManhattanDistance(this Point point, Point other)
    {
        return Math.Abs(point.X - other.X) + Math.Abs(point.Y - other.Y);
    }
}
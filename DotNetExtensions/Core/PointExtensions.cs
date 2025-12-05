using System.Drawing;

namespace DotNetExtensions.Core;

/// <summary>
/// Provides extension methods for working with <see cref="Point"/> structures.
/// </summary>
public static class PointExtensions
{
    /// <param name="point">The point for which to find the neighbors.</param>
    extension(Point point)
    {
        /// <summary>
        /// Gets the four immediate neighbors of a given point: left, right, top, and bottom.
        /// </summary>
        /// <returns>
        /// A tuple containing the neighbors of the given point:
        /// <list type="bullet">
        /// <item>Left: The point to the left of the given point (X - 1, Y).</item>
        /// <item>Right: The point to the right of the given point (X + 1, Y).</item>
        /// <item>Top: The point above the given point (X, Y - 1).</item>
        /// <item>Bottom: The point below the given point (X, Y + 1).</item>
        /// </list>
        /// </returns>
        public (Point Left, Point Right, Point Top, Point Bottom) GetNeighbors()
        {
            var left = point with { X = point.X - 1 };
            var right = point with { X = point.X + 1 };
            var top = point with { Y = point.Y - 1 };
            var bottom = point with { Y = point.Y + 1 };
            return (left, right, top, bottom);
        }

        /// <summary>
        /// Gets the four diagonal corners of a given point: top-left, top-right, bottom-left, and bottom-right.
        /// </summary>
        /// <returns>
        /// A tuple containing the corners of the given point:
        /// <list type="bullet">
        /// <item>TopLeft: The point diagonally above and to the left of the given point (X - 1, Y - 1).</item>
        /// <item>TopRight: The point diagonally above and to the right of the given point (X + 1, Y - 1).</item>
        /// <item>BottomLeft: The point diagonally below and to the left of the given point (X - 1, Y + 1).</item>
        /// <item>BottomRight: The point diagonally below and to the right of the given point (X + 1, Y + 1).</item>
        /// </list>
        /// </returns>
        public (Point TopLeft, Point TopRight, Point BottomLeft, Point BottomRight) GetCorners()
        {
            var topLeft = point with { X = point.X - 1, Y = point.Y - 1 };
            var topRight = point with { X = point.X + 1, Y = point.Y - 1 };
            var bottomLeft = point with { X = point.X - 1, Y = point.Y + 1 };
            var bottomRight = point with { X = point.X + 1, Y = point.Y + 1 };
            return (topLeft, topRight, bottomLeft, bottomRight);
        }

        /// <summary>
        /// Calculates the Manhattan distance between two points.
        /// </summary>
        /// <param name="other">The target point.</param>
        /// <returns>The Manhattan distance between the two points.</returns>
        /// <remarks>
        /// The Manhattan distance is calculated
        /// by summing the absolute differences between the X coordinates and the Y coordinates.
        /// It is commonly used in grid-based distance calculations where diagonal movement is not allowed.
        /// </remarks>
        public int ManhattanDistance(Point other)
        {
            return Math.Abs(point.X - other.X) + Math.Abs(point.Y - other.Y);
        }
    }
}
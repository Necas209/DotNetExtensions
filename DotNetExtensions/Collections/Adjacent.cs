namespace DotNetExtensions.Collections;

public static partial class EnumerableExtensions
{
    /// <summary>
    /// Returns all overlapping subarrays of the specified length from the source sequence.
    /// </summary>
    /// <typeparam name="T">The type of elements in the source sequence.</typeparam>
    /// <param name="source">The source sequence.</param>
    /// <param name="length">The length of each subarray.</param>
    /// <returns>
    /// A sequence of subarrays with the specified length,
    /// each represented as an array of type <typeparamref name="T"/>.
    /// </returns>
    /// <exception cref="ArgumentNullException">
    /// Thrown if the <paramref name="source"/> is <c>null</c>.
    /// </exception>
    /// <exception cref="ArgumentOutOfRangeException">
    /// Thrown if the <paramref name="length"/> is negative.
    /// </exception>
    public static IEnumerable<T[]> Adjacent<T>(this IEnumerable<T> source, int length)
    {
        ArgumentNullException.ThrowIfNull(source);
        ArgumentOutOfRangeException.ThrowIfNegative(length);

        return AdjacentInternal(source, length);
    }

    private static IEnumerable<T[]> AdjacentInternal<T>(IEnumerable<T> source, int length)
    {
        if (length == 0)
            yield break;

        var window = new Queue<T>(length);

        foreach (var item in source)
        {
            window.Enqueue(item);
            if (window.Count > length)
                window.Dequeue();

            if (window.Count == length)
                yield return window.ToArray();
        }
    }
}
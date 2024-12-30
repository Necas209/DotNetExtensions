namespace DotNetExtensions;

/// <summary>
/// Provides extension methods for working with enumerable sequences.
/// </summary>
public static partial class EnumerableExtensions
{
    /// <summary>
    /// Returns a sequence of consecutive pairs of elements from the source sequence.
    /// </summary>
    /// <typeparam name="T">The type of elements in the source sequence.</typeparam>
    /// <param name="source">The source sequence.</param>
    /// <returns>
    /// A sequence of tuples containing consecutive pairs of elements from the source.
    /// </returns>
    /// <exception cref="ArgumentNullException">
    /// Thrown if the <paramref name="source"/> is <c>null</c>.
    /// </exception>
    public static IEnumerable<(T First, T Second)> Pairwise<T>(this IEnumerable<T> source)
    {
        ArgumentNullException.ThrowIfNull(source);

        using var enumerator = source.GetEnumerator();
        if (!enumerator.MoveNext()) yield break;

        var previous = enumerator.Current;
        while (enumerator.MoveNext())
        {
            var current = enumerator.Current;
            yield return (previous, current);
            previous = current;
        }
    }

    /// <summary>
    /// Returns a sequence of overlapping quintuples (groups of five consecutive elements) from the source sequence.
    /// </summary>
    /// <typeparam name="T">The type of elements in the source sequence.</typeparam>
    /// <param name="source">The source sequence.</param>
    /// <returns>
    /// A sequence of tuples containing quintuples of consecutive elements from the source.
    /// </returns>
    /// <exception cref="ArgumentNullException">
    /// Thrown if the <paramref name="source"/> is <c>null</c>.
    /// </exception>
    public static IEnumerable<(T First, T Second, T Third, T Fourth, T Fifth)> Quintuples<T>(this IEnumerable<T> source)
    {
        ArgumentNullException.ThrowIfNull(source);

        using var enumerator = source.GetEnumerator();

        // Buffer the first five elements
        if (!enumerator.MoveNext()) yield break;
        var first = enumerator.Current;

        if (!enumerator.MoveNext()) yield break;
        var second = enumerator.Current;

        if (!enumerator.MoveNext()) yield break;
        var third = enumerator.Current;

        if (!enumerator.MoveNext()) yield break;
        var fourth = enumerator.Current;

        if (!enumerator.MoveNext()) yield break;
        var fifth = enumerator.Current;

        while (true)
        {
            yield return (first, second, third, fourth, fifth);

            // Slide the window forward
            first = second;
            second = third;
            third = fourth;
            fourth = fifth;

            if (!enumerator.MoveNext())
                yield break;

            fifth = enumerator.Current;
        }
    }

    /// <summary>
    /// Returns all overlapping sub-arrays of the specified length from the source sequence.
    /// </summary>
    /// <typeparam name="T">The type of elements in the source sequence.</typeparam>
    /// <param name="source">The source sequence.</param>
    /// <param name="length">The length of each subarray.</param>
    /// <returns>
    /// A sequence of sub-arrays of the specified length, each represented as an array of type <typeparamref name="T"/>.
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
        var array = source as T[] ?? source.ToArray();
        if (length > array.Length)
            yield break;

        for (var i = 0; i <= array.Length - length; i++)
        {
            var segment = new T[length];
            Array.Copy(array, i, segment, 0, length);
            yield return segment;
        }
    }

    /// <summary>
    /// Returns a new sequence that skips the element at the specified index.
    /// </summary>
    /// <typeparam name="T">The type of elements in the source sequence.</typeparam>
    /// <param name="source">The source sequence.</param>
    /// <param name="index">The index of the element to skip.</param>
    /// <returns>
    /// A new sequence without the element at the specified index.
    /// </returns>
    /// <exception cref="ArgumentNullException">
    /// Thrown if the <paramref name="source"/> is <c>null</c>.
    /// </exception>
    public static IEnumerable<T> SkipAt<T>(this IEnumerable<T> source, int index)
    {
        ArgumentNullException.ThrowIfNull(source);

        var i = 0;
        foreach (var item in source)
        {
            if (i++ == index) continue;
            yield return item;
        }
    }
}
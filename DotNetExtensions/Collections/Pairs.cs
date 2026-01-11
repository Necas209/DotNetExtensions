namespace DotNetExtensions.Collections;

public static partial class EnumerableExtensions
{
    /// <summary>
    /// Returns all unique unordered pairs from <paramref name="source"/> where each pair contains
    /// two distinct elements from the sequence. The order within each pair follows the original
    /// sequence order (first comes before second).
    /// </summary>
    /// <typeparam name="T">The element type of the sequence.</typeparam>
    /// <param name="source">The input sequence from which pairs are generated.</param>
    /// <returns>
    /// An <see cref="IEnumerable{T}"/> of tuples where each tuple contains two distinct elements
    /// from the source: (First, Second).
    /// </returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="source"/> is null.</exception>
    public static IEnumerable<(T First, T Second)> Pairs<T>(this IEnumerable<T> source)
    {
        ArgumentNullException.ThrowIfNull(source);

        switch (source)
        {
            case IList<T> list:
                {
                    return PairsInternal(list);
                }
            case ICollection<T> coll:
                {
                    var array = new T[coll.Count];
                    coll.CopyTo(array, 0);
                    return PairsInternal(array);
                }
            default:
                {
                    var buffered = source.ToList();
                    return PairsInternal(buffered);
                }
        }
    }

    /// <summary>
    /// Internal implementation that enumerates all unique unordered index pairs from an indexed buffer.
    /// </summary>
    /// <typeparam name="T">The element type of the buffer.</typeparam>
    /// <param name="buffer">An indexed collection (e.g. <see cref="IList{T}"/>) to enumerate pairs from.</param>
    /// <returns>An <see cref="IEnumerable{T}"/> of tuples (First, Second) for every pair where First precedes Second.</returns>
    private static IEnumerable<(T First, T Second)> PairsInternal<T>(IList<T> buffer)
    {
        for (var i = 0; i < buffer.Count; i++)
        {
            for (var j = i + 1; j < buffer.Count; j++)
            {
                yield return (buffer[i], buffer[j]);
            }
        }
    }
}
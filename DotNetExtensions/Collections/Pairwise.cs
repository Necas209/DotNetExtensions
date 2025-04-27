namespace DotNetExtensions.Collections;

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

        return PairwiseInternal(source);
    }

    private static IEnumerable<(T First, T Second)> PairwiseInternal<T>(IEnumerable<T> source)
    {
        using var enumerator = source.GetEnumerator();

        // Buffer the first element
        if (!enumerator.MoveNext()) yield break;
        var previous = enumerator.Current;

        while (enumerator.MoveNext())
        {
            var current = enumerator.Current;
            yield return (previous, current);
            previous = current;
        }
    }
}
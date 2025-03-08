namespace DotNetExtensions.Collections;

public static partial class EnumerableExtensions
{
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

        return QuintuplesInternal(source);
    }

    private static IEnumerable<(T First, T Second, T Third, T Fourth, T Fifth)> QuintuplesInternal<T>(
        IEnumerable<T> source)
    {
        using var enumerator = source.GetEnumerator();

        // Buffer the first four elements
        if (!enumerator.MoveNext()) yield break;
        var first = enumerator.Current;

        if (!enumerator.MoveNext()) yield break;
        var second = enumerator.Current;

        if (!enumerator.MoveNext()) yield break;
        var third = enumerator.Current;

        if (!enumerator.MoveNext()) yield break;
        var fourth = enumerator.Current;

        while (enumerator.MoveNext())
        {
            var fifth = enumerator.Current;
            yield return (first, second, third, fourth, fifth);
            first = second;
            second = third;
            third = fourth;
            fourth = fifth;
        }
    }
}
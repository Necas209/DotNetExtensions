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
        var window = new Queue<T>(5);

        foreach (var item in source)
        {
            window.Enqueue(item);
            if (window.Count > 5)
                window.Dequeue();

            if (window.Count != 5) continue;

            var arr = window.ToArray();
            yield return (arr[0], arr[1], arr[2], arr[3], arr[4]);
        }
    }
}
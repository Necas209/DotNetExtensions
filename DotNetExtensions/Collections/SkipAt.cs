namespace DotNetExtensions.Collections;

public static partial class EnumerableExtensions
{
    /// <summary>
    /// Returns a new sequence that skips the element at the specified index.
    /// Throws <see cref="ArgumentOutOfRangeException"/> if the index is negative or outside the bounds of the source.
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
    /// <exception cref="ArgumentOutOfRangeException">
    /// Thrown if the <paramref name="index"/> is negative or outside the bounds of the source.
    /// </exception>
    public static IEnumerable<T> SkipAt<T>(this IEnumerable<T> source, int index)
    {
        ArgumentNullException.ThrowIfNull(source);
        ArgumentOutOfRangeException.ThrowIfNegative(index);

        return SkipAtInternal(source, index);
    }

    private static IEnumerable<T> SkipAtInternal<T>(IEnumerable<T> source, int index)
    {
        using var enumerator = source.GetEnumerator();
        var i = 0;
        var found = false;

        while (enumerator.MoveNext())
        {
            if (i++ == index)
            {
                found = true;
                continue;
            }

            yield return enumerator.Current;
        }

        if (!found)
            throw new ArgumentOutOfRangeException(nameof(index), "Index is out of range of the source sequence.");
    }

    /// <summary>
    /// Returns a new sequence that skips the element at the specified index.
    /// If the index is negative or outside the bounds of the source, the original sequence is returned unchanged.
    /// </summary>
    /// <typeparam name="T">The type of elements in the source sequence.</typeparam>
    /// <param name="source">The source sequence.</param>
    /// <param name="index">The index of the element to skip.</param>
    /// <returns>
    /// A new sequence without the element at the specified index, or the original sequence if the index is out of range.
    /// </returns>
    /// <exception cref="ArgumentNullException">
    /// Thrown if the <paramref name="source"/> is <c>null</c>.
    /// </exception>
    public static IEnumerable<T> SkipAtOrDefault<T>(this IEnumerable<T> source, int index)
    {
        ArgumentNullException.ThrowIfNull(source);
        return index < 0 ? source : SkipAtOrDefaultInternal(source, index);
    }

    private static IEnumerable<T> SkipAtOrDefaultInternal<T>(IEnumerable<T> source, int index)
    {
        using var enumerator = source.GetEnumerator();
        var i = 0;

        while (enumerator.MoveNext())
        {
            if (i++ == index) continue;
            yield return enumerator.Current;
        }
    }
}
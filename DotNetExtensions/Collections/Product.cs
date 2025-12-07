using System.Numerics;

namespace DotNetExtensions.Collections;

public partial class EnumerableExtensions
{
    /// <summary>
    /// Returns the product of all elements in the source sequence.
    /// </summary>
    /// <typeparam name="T">The type of elements in the source sequence. Must implement <see cref="INumber{T}"/>.</typeparam>
    /// <param name="source">The source sequence.</param>
    /// <returns>
    /// The product of all elements in the source sequence.
    /// </returns>
    /// <exception cref="ArgumentNullException">
    /// Thrown if the <paramref name="source"/> is <c>null</c>.
    /// </exception>
    /// <exception cref="InvalidOperationException">
    /// Thrown if the <paramref name="source"/> contains no elements.
    /// </exception>
    public static T Product<T>(this IEnumerable<T> source) where T : INumber<T>
    {
        ArgumentNullException.ThrowIfNull(source);

        return ProductInternal(source);
    }
    
    private static T ProductInternal<T>(IEnumerable<T> source) where T : INumber<T>
    {
        return source.Aggregate((current, item) => current * item);
    }
}
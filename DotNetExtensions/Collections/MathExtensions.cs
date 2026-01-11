using System.Numerics;

namespace DotNetExtensions.Collections;

public partial class EnumerableExtensions
{
    /// <param name="source">The source sequence.</param>
    /// <typeparam name="T">The type of elements in the source sequence. Must implement <see cref="INumber{T}"/>.</typeparam>
    extension<T>(IEnumerable<T> source) where T : INumber<T>
    {
        /// <summary>
        /// Returns the product of all elements in the source sequence.
        /// </summary>
        /// <returns>The product of all elements in the source sequence.</returns>
        /// <exception cref="ArgumentNullException">Thrown if the <paramref name="source"/> is <c>null</c>.</exception>
        /// <exception cref="InvalidOperationException">Thrown if the <paramref name="source"/> contains no elements.</exception>
        public T Product()
        {
            ArgumentNullException.ThrowIfNull(source);

            using var e = source.GetEnumerator();
            if (!e.MoveNext())
                throw new InvalidOperationException("Sequence contains no elements.");

            var result = e.Current;
            while (e.MoveNext())
            {
                result *= e.Current;
            }

            return result;
        }
    }

    /// <param name="source">The source sequence.</param>
    /// <typeparam name="T">The type of elements in the source sequence. Must implement <see cref="IBinaryNumber{T}"/>.</typeparam>
    extension<T>(IEnumerable<T> source) where T : IBinaryNumber<T>
    {
        /// <summary>
        /// Returns the bitwise AND of all elements in the source sequence.
        /// </summary>
        /// <returns>The bitwise AND of all elements in the source sequence.</returns>
        /// <exception cref="ArgumentNullException">Thrown if the <paramref name="source"/> is <c>null</c>.</exception>
        /// <exception cref="InvalidOperationException">Thrown if the <paramref name="source"/> contains no elements.</exception>
        public T And()
        {
            ArgumentNullException.ThrowIfNull(source);

            using var e = source.GetEnumerator();
            if (!e.MoveNext())
                throw new InvalidOperationException("Sequence contains no elements.");

            var result = e.Current;
            while (e.MoveNext())
            {
                result &= e.Current;
            }

            return result;
        }

        /// <summary>
        /// Returns the bitwise OR of all elements in the source sequence.
        /// </summary>
        /// <returns>The bitwise OR of all elements in the source sequence.</returns>
        /// <exception cref="ArgumentNullException">Thrown if the <paramref name="source"/> is <c>null</c>.</exception>
        /// <exception cref="InvalidOperationException">Thrown if the <paramref name="source"/> contains no elements.</exception>
        public T Or()
        {
            ArgumentNullException.ThrowIfNull(source);

            using var e = source.GetEnumerator();
            if (!e.MoveNext())
                throw new InvalidOperationException("Sequence contains no elements.");

            var result = e.Current;
            while (e.MoveNext())
            {
                result |= e.Current;
            }

            return result;
        }

        /// <summary>
        /// Returns the bitwise XOR of all elements in the source sequence.
        /// </summary>
        /// <returns>The bitwise XOR of all elements in the source sequence.</returns>
        /// <exception cref="ArgumentNullException">Thrown if the <paramref name="source"/> is <c>null</c>.</exception>
        /// <exception cref="InvalidOperationException">Thrown if the <paramref name="source"/> contains no elements.</exception>
        public T Xor()
        {
            ArgumentNullException.ThrowIfNull(source);

            using var e = source.GetEnumerator();
            if (!e.MoveNext())
                throw new InvalidOperationException("Sequence contains no elements.");

            var result = e.Current;
            while (e.MoveNext())
            {
                result ^= e.Current;
            }

            return result;
        }
    }
}
using System.Numerics;

namespace DotNetExtensions.Core;

/// <summary>
/// Provides extension methods for working with numeric types.
/// </summary>
public static class NumberExtensions
{
    /// <param name="number">The number to analyze.</param>
    /// <typeparam name="T">The numeric type implementing <see cref="INumber{T}"/>.</typeparam>
    extension<T>(T number) where T : IBinaryInteger<T>
    {
        /// <summary>
        /// Calculates the number of digits in the given number, in base 10.
        /// </summary>
        /// <returns>The number of digits in the number.</returns>
        /// <remarks>
        /// For negative numbers, the sign is ignored, and the count includes all digits of the absolute value.
        /// </remarks>
        public int NumberOfDigits()
        {
            if (number == T.Zero)
                return 1;

            var ten = T.CreateChecked(10);
            var count = 0;
            while (number != T.Zero)
            {
                number /= ten;
                count++;
            }

            return count;
        }

        /// <summary>
        /// Determines whether the given number is a palindrome.
        /// </summary>
        /// <returns><c>true</c> if the number is a palindrome; otherwise, <c>false</c>.</returns>
        /// <remarks>
        /// Negative numbers are not considered palindromes.
        /// </remarks>
        public bool IsPalindrome()
        {
            if (number < T.Zero)
                return false;

            try
            {
                return number == number.Reverse();
            }
            catch (OverflowException)
            {
                // If the number is too large to reverse, it can't be a palindrome.
                return false;
            }
        }

        /// <summary>
        /// Reverses the digits of the given number.
        /// </summary>
        /// <returns>The reversed number.</returns>
        /// <remarks>
        /// For single-digit numbers, the result is the number itself.
        /// </remarks>
        /// <exception cref="OverflowException">
        /// Thrown if reversing the number causes an overflow.
        /// </exception>
        public T Reverse()
        {
            var ten = T.CreateChecked(10);

            var reverse = T.Zero;
            while (number != T.Zero)
            {
                checked
                {
                    reverse = reverse * ten + number % ten;
                }

                number /= ten;
            }

            return reverse;
        }

        /// <summary>
        /// Splits the given number into two parts: left and right.
        /// </summary>
        /// <returns>
        /// A tuple containing the left and right parts of the number.
        /// </returns>
        /// <remarks>
        /// The number is split based on the number of digits, with the left part containing
        /// the most significant digits and the right part containing the least significant digits.
        /// </remarks>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown if the number is negative.
        /// </exception>
        public (T Left, T Right) Split()
        {
            ArgumentOutOfRangeException.ThrowIfNegative(number);

            var numDigits = number.NumberOfDigits();
            var halfDigits = numDigits / 2 + numDigits % 2;
            var divisor = T.CreateChecked(Math.Pow(10, halfDigits));

            var leftPart = number / divisor;
            var rightPart = number % divisor;

            return (leftPart, rightPart);
        }
    }
}
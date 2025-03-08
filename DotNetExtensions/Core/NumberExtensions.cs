using System.Numerics;

namespace DotNetExtensions.Core;

/// <summary>
/// Provides extension methods for working with numeric types.
/// </summary>
public static class NumberExtensions
{
    /// <summary>
    /// Calculates the number of digits in the given number, in base 10.
    /// </summary>
    /// <typeparam name="T">The numeric type implementing <see cref="INumber{T}"/>.</typeparam>
    /// <param name="number">The number to analyze.</param>
    /// <returns>The number of digits in the number.</returns>
    /// <remarks>
    /// For negative numbers, the sign is ignored, and the count includes all digits of the absolute value.
    /// </remarks>
    public static ulong NumberOfDigits<T>(this T number) where T : IBinaryInteger<T>
    {
        if (number == T.Zero)
            return 1;

        if (number < T.Zero)
        {
            try
            {
                checked
                {
                    number = -number; // Make the number positive.
                }
            }
            catch (OverflowException)
            {
                number = -++number; // Increment to avoid overflow.
            }
        }

        var magnitude = (ulong)Math.Floor(Math.Log10(double.CreateChecked(number)));
        return magnitude + 1;
    }

    /// <summary>
    /// Determines whether the given number is a palindrome.
    /// </summary>
    /// <typeparam name="T">The numeric type implementing <see cref="IBinaryInteger{T}"/>.</typeparam>
    /// <param name="number">The number to check.</param>
    /// <returns><c>true</c> if the number is a palindrome; otherwise, <c>false</c>.</returns>
    /// <remarks>
    /// Negative numbers are not considered palindromes.
    /// </remarks>
    public static bool IsPalindrome<T>(this T number) where T : IBinaryInteger<T>
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
    /// <typeparam name="T">The numeric type implementing <see cref="IBinaryInteger{T}"/>.</typeparam>
    /// <param name="number">The number to reverse.</param>
    /// <returns>The reversed number.</returns>
    /// <remarks>
    /// For single-digit numbers, the result is the number itself.
    /// </remarks>
    /// <exception cref="OverflowException">
    /// Thrown if reversing the number causes an overflow.
    /// </exception>
    public static T Reverse<T>(this T number) where T : IBinaryInteger<T>
    {
        var ten = T.CreateChecked(10);
        if (number > -ten && number < ten)
            return number;

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
    /// <typeparam name="T">The numeric type implementing <see cref="INumber{T}"/>.</typeparam>
    /// <param name="number">The number to split.</param>
    /// <returns>
    /// A tuple containing the left and right parts of the number.
    /// </returns>
    /// <remarks>
    /// The number is split based on the number of digits, with the left part containing
    /// the most significant digits and the right part containing the least significant digits.
    /// </remarks>
    /// <exception cref="ArgumentException">
    /// Thrown if the number is negative.
    /// </exception>
    public static (T Left, T Right) Split<T>(this T number) where T : IBinaryInteger<T>
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
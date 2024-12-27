using System.Numerics;

namespace DotNetExtensions;

public static class NumberExtensions
{
    public static int NumberOfDigits<T>(this T number) where T : INumber<T>
    {
        if (number == T.Zero)
            return 1;

        if (number < T.Zero)
        {
            number = -number;
        }

        return (int)Math.Floor(Math.Log10(double.CreateChecked(number)) + 1);
    }

    public static bool IsPalindrome<T>(this T number) where T : IBinaryInteger<T>
    {
        if (number < T.Zero)
            return false;

        var ten = T.CreateChecked(10);
        if (number < ten)
            return true;

        var original = number;
        var reverse = T.Zero;
        while (number > T.Zero)
        {
            reverse = reverse * ten + number % ten;
            number /= ten;
        }
        
        return original == reverse;
    }

    public static (T Left, T Right) SplitNumber<T>(this T number) where T : INumber<T>
    {
        if (number < T.Zero)
            throw new ArgumentException("Number must be positive.", nameof(number));

        var numDigits = number.NumberOfDigits();
        var halfDigits = numDigits / 2 + numDigits % 2;
        var divisor = T.CreateChecked(Math.Pow(10, halfDigits));

        var leftPart = number / divisor;
        var rightPart = number % divisor;

        return (leftPart, rightPart);
    }
}
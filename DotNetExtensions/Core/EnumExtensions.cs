using System.Runtime.CompilerServices;

namespace DotNetExtensions.Core;

/// <summary>
/// Provides extension methods for working with enumeration types.
/// </summary>
public static class EnumExtensions
{
    /// <summary>
    /// Determines whether any of the specified flags are set in the enumeration value.
    /// </summary>
    /// <typeparam name="TEnum">The enumeration type. Must be an unmanaged type that inherits from <see cref="Enum"/>.</typeparam>
    /// <param name="value">The enumeration value to check.</param>
    /// <param name="flag">The flag or combination of flags to check for.</param>
    /// <returns><c>true</c> if any of the specified flags are set in <paramref name="value"/>; otherwise, <c>false</c>.</returns>
    /// <exception cref="Exception">
    /// Thrown if the size of the enumeration type does not match a known enum backing type
    /// (byte, ushort, int, or long).
    /// </exception>
    /// <remarks>
    /// This method uses unsafe code to determine the backing type of the enumeration and perform
    /// bitwise operations to check for flags efficiently.
    /// </remarks>
    public static bool HasAnyFlag<TEnum>(this TEnum value, TEnum flag) where TEnum : unmanaged, Enum
    {
        // Since this method covers all possible backing types of the enum, we can safely disable the CS8509 warning.
#pragma warning disable CS8509 // The switch expression does not handle all possible values of its input type (it is not exhaustive).
        return Unsafe.SizeOf<TEnum>() switch
#pragma warning restore CS8509 // The switch expression does not handle all possible values of its input type (it is not exhaustive).
        {
            sizeof(byte) => (Unsafe.As<TEnum, byte>(ref value) & Unsafe.As<TEnum, byte>(ref flag)) != 0,
            sizeof(ushort) => (Unsafe.As<TEnum, ushort>(ref value) & Unsafe.As<TEnum, ushort>(ref flag)) != 0,
            sizeof(uint) => (Unsafe.As<TEnum, uint>(ref value) & Unsafe.As<TEnum, uint>(ref flag)) != 0,
            sizeof(ulong) => (Unsafe.As<TEnum, ulong>(ref value) & Unsafe.As<TEnum, ulong>(ref flag)) != 0
        };
    }
}
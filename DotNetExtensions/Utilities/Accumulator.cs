using System.Diagnostics.CodeAnalysis;
using System.Numerics;

namespace DotNetExtensions.Utilities;

/// <summary>
/// A generic accumulator class that tracks the minimum, maximum, sum, and count of added values
/// and calculates the mean of the values.
/// </summary>
/// <typeparam name="T">
/// The numeric type of the values to be accumulated.
/// Must implement <see cref="INumber{TSelf}"/> and <see cref="IMinMaxValue{TSelf}"/>.
/// </typeparam>
public class Accumulator<T> where T : INumber<T>, IMinMaxValue<T>
{
    public Accumulator() => Reset();

    /// <summary>
    /// Gets the minimum value added to the accumulator.
    /// </summary>
    public T Min { get; private set; }

    /// <summary>
    /// Gets the maximum value added to the accumulator.
    /// </summary>
    public T Max { get; private set; }

    /// <summary>
    /// Gets the sum of all values added to the accumulator.
    /// </summary>
    public T Sum { get; private set; }

    /// <summary>
    /// Gets the count of values added to the accumulator.
    /// </summary>
    public int Count { get; private set; }

    /// <summary>
    /// Gets the mean of the values added to the accumulator.
    /// Throws an <see cref="InvalidOperationException"/> if no values have been added.
    /// </summary>
    /// <exception cref="InvalidOperationException">
    /// Thrown when attempting to calculate the mean with zero elements.
    /// </exception>
    public T Mean => Count > 0
        ? Sum / T.CreateChecked(Count)
        : throw new InvalidOperationException("Cannot calculate mean of zero elements.");

    /// <summary>
    /// Adds a value to the accumulator, updating the minimum, maximum, sum, and count.
    /// </summary>
    /// <param name="value">The value to add to the accumulator.</param>
    /// <exception cref="OverflowException">
    /// Thrown when the sum exceeds <see cref="T.MaxValue"/>
    /// or when the count exceeds <see cref="int.MaxValue"/>.
    /// </exception>
    public void Add(T value)
    {
        if (value < Min) Min = value;
        if (value > Max) Max = value;
        checked
        {
            Sum += value;
            Count++;
        }
    }

    /// <summary>
    /// Resets the accumulator, clearing all accumulated values.
    /// </summary>
    [MemberNotNull(nameof(Min), nameof(Max), nameof(Sum))]
    public void Reset()
    {
        Min = T.MaxValue;
        Max = T.MinValue;
        Sum = T.Zero;
        Count = 0;
    }
}
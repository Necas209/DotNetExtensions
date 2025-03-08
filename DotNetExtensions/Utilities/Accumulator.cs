using System.Diagnostics.CodeAnalysis;
using System.Numerics;

namespace DotNetExtensions.Utilities;

public class Accumulator<T> where T : INumber<T>, IMinMaxValue<T>
{
    public Accumulator() => Reset();

    public T Min { get; private set; }

    public T Max { get; private set; }

    public T Sum { get; private set; }

    public int Count { get; private set; }

    public T Mean => Count > 0
        ? Sum / T.CreateChecked(Count)
        : throw new InvalidOperationException("Cannot calculate mean of zero elements.");

    public void Add(T value)
    {
        if (value < Min)
        {
            Min = value;
        }

        if (value > Max)
        {
            Max = value;
        }

        Sum += value;
        Count++;
    }

    [MemberNotNull(nameof(Min), nameof(Max), nameof(Sum))]
    public void Reset()
    {
        Min = T.MaxValue;
        Max = T.MinValue;
        Sum = T.Zero;
        Count = 0;
    }
}
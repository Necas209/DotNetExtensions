using System.Numerics;

namespace DotNetExtensions.Utilities;

public class Accumulator<T> where T : INumber<T>, IMinMaxValue<T>
{
    public T Min { get; private set; } = T.MaxValue;

    public T Max { get; private set; } = T.MinValue;

    public T Sum { get; private set; } = T.Zero;

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

    public void Reset()
    {
        Min = T.MaxValue;
        Max = T.MinValue;
        Sum = T.Zero;
        Count = 0;
    }
}
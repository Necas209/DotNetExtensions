namespace DotNetExtensions;

public static partial class EnumerableExtensions
{
    public static IEnumerable<IEnumerable<T>> Combinations<T>(this IEnumerable<T> source, int length)
    {
        ArgumentNullException.ThrowIfNull(source);
        ArgumentOutOfRangeException.ThrowIfNegative(length);
        return CombinationsInternal(source, length);
    }

    private static IEnumerable<IEnumerable<T>> CombinationsInternal<T>(IEnumerable<T> source, int length)
    {
        var array = source as T[] ?? source.ToArray();

        if (length == 0)
        {
            yield return [];
            yield break;
        }

        if (length > array.Length)
            yield break;

        // Stack to hold the current state for iteration
        var stack = new Stack<(int Index, List<T> Combination)>();
        stack.Push((-1, []));

        while (stack.Count > 0)
        {
            var (index, combination) = stack.Pop();

            // If the combination is complete, yield it
            if (combination.Count == length)
            {
                yield return combination;
                continue;
            }

            // Push next elements onto the stack in reverse order to ensure correct order
            for (var i = array.Length - 1; i > index; i--)
            {
                var newCombination = new List<T>(combination) { array[i] };
                stack.Push((i, newCombination));
            }
        }
    }
}
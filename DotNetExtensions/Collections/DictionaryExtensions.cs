using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace DotNetExtensions.Collections;

/// <summary>
/// Provides extension methods for working with dictionaries.
/// </summary>
public static class DictionaryExtensions
{
    /// <summary>
    /// Gets the value associated with the specified key in the dictionary.
    /// If the key does not exist, the provided value is added to the dictionary
    /// and returned.
    /// </summary>
    /// <typeparam name="TKey">The type of the keys in the dictionary. Must be non-nullable.</typeparam>
    /// <typeparam name="TValue">The type of the values in the dictionary.</typeparam>
    /// <param name="dictionary">The dictionary to search for the key and add the value if it does not exist.</param>
    /// <param name="key">The key of the element to retrieve or add.</param>
    /// <param name="value">
    /// The value to add to the dictionary if the key does not exist. 
    /// If the key exists, this value is ignored.
    /// </param>
    /// <returns>
    /// The value associated with the specified key if it exists in the dictionary, 
    /// or the newly added value if the key was not present.
    /// </returns>
    /// <exception cref="ArgumentNullException">
    /// Thrown if <paramref name="dictionary"/> or <paramref name="key"/> is <c>null</c>.
    /// </exception>
    [return: NotNullIfNotNull(nameof(value))]
    public static TValue? GetOrAdd<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, TKey key, TValue value)
        where TKey : notnull
    {
        ArgumentNullException.ThrowIfNull(dictionary);
        ArgumentNullException.ThrowIfNull(key);

        ref var val = ref CollectionsMarshal.GetValueRefOrAddDefault(dictionary, key, out var exists);
        if (!exists) val = value;

        return val;
    }

    /// <summary>
    /// Attempts to update the value associated with the specified key in the dictionary.
    /// If the key does not exist, no changes are made, and the method returns <c>false</c>.
    /// </summary>
    /// <typeparam name="TKey">The type of the keys in the dictionary. Must be non-nullable.</typeparam>
    /// <typeparam name="TValue">The type of the values in the dictionary.</typeparam>
    /// <param name="dictionary">The dictionary to update the value in.</param>
    /// <param name="key">The key of the element to update.</param>
    /// <param name="value">The new value to set if the key exists in the dictionary.</param>
    /// <returns>
    /// <c>true</c> if the key exists and the value was updated; otherwise, <c>false</c>.
    /// </returns>
    /// <exception cref="ArgumentNullException">
    /// Thrown if <paramref name="dictionary"/> or <paramref name="key"/> is <c>null</c>.
    /// </exception>
    public static bool TryUpdate<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, TKey key, TValue value)
        where TKey : notnull
    {
        ArgumentNullException.ThrowIfNull(dictionary);
        ArgumentNullException.ThrowIfNull(key);

        ref var val = ref CollectionsMarshal.GetValueRefOrNullRef(dictionary, key);
        if (Unsafe.IsNullRef(ref val))
            return false;

        val = value;
        return true;
    }
}
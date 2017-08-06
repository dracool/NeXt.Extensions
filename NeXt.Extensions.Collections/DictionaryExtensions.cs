using System;
using System.Collections.Generic;

namespace NeXt.Extensions.Collections
{
    public static class DictionaryExtensions
    {
        /// <summary>
        /// Returns the value associated with a key or the types default value if the key doesn't exist
        /// </summary>
        public static TValue GetValueOrDefault<TKey, TValue>(this IReadOnlyDictionary<TKey, TValue> dict, TKey key)
        {
            if (dict == null) throw new ArgumentNullException(nameof(dict));

            return dict.TryGetValue(key, out var val)
                ? val
                : default(TValue);
        }

        /// <summary>
        /// Returns the value associated with a key or the <paramref name="defaultValue"/> if the key doesn't exist
        /// </summary>
        public static TValue GetValueOrDefault<TKey, TValue>(this IReadOnlyDictionary<TKey, TValue> dict, TKey key,  TValue defaultValue)
        {
            if (dict == null) throw new ArgumentNullException(nameof(dict));

            return dict.TryGetValue(key, out var val)
                ? val
                : defaultValue;
        }

        /// <summary>
        /// Returns the value associated with a key or the types default value if the key doesn't exist
        /// </summary>
        public static TValue GetValueOrDefault<TKey, TValue>(this IDictionary<TKey, TValue> dict, TKey key)
        {
            if (dict == null) throw new ArgumentNullException(nameof(dict));

            return dict.TryGetValue(key, out var val)
                ? val
                : default(TValue);
        }
ith
        /// <summary>
        /// Returns the value associated with a key or the <paramref name="defaultValue"/> if the key doesn't exist
        /// </summary>
        public static TValue GetValueOrDefault<TKey, TValue>(this IDictionary<TKey, TValue> dict, TKey key, TValue defaultValue)
        {
            if (dict == null) throw new ArgumentNullException(nameof(dict));

            return dict.TryGetValue(key, out var val)
                ? val
                : defaultValue;
        }
    }
}

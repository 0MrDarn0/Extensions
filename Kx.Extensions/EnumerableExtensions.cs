
using System;
using System.Collections.Generic;

namespace Kx.Extensions
{
    static public class EnumerableExtensions
    {
        /// <summary>
        /// Returns elements with distinct keys.
        /// </summary>
        static public IEnumerable<T> Distinct<T, TKey>(this IEnumerable<T> source, Func<T, TKey> keySelector, IEqualityComparer<TKey> keyComparer) {
            //hashset for uniqueness of keys
            var keyHashSet = new HashSet<TKey>(keyComparer);
            foreach (var element in source) {
                if (keyHashSet.Add(keySelector(element)))
                    yield return element;
            }
        }

        /// <summary>
        /// Returns elements with distinct keys.
        /// </summary>
        static public IEnumerable<T> Distinct<T, TKey>(this IEnumerable<T> source, Func<T, TKey> keySelector) => source.Distinct(keySelector, EqualityComparer<TKey>.Default);
    }
}

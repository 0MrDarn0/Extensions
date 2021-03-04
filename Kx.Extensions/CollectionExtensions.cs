using System.Collections.Generic;

namespace Kx.Extensions
{
    static public class CollectionExtensions
    {
        /// <summary>
        /// Adds multiple items to the collection.
        /// </summary>
        static public void AddRange<T>(this ICollection<T> collection, IEnumerable<T> items) 
        {
            foreach (var item in items)
                collection.Add(item);
        }
    }
}

using System.Collections.ObjectModel;

namespace Kx.Extensions
{
    static public class ObservableCollectionExtensions
    {

        static public T NextItem<T>(this ObservableCollection<T> collection, T currentItem)
        {
            var currentIndex = collection.IndexOf(currentItem);
            if (currentIndex < collection.Count - 1)
            {
                return collection[currentIndex + 1];
            }
            return collection[0];
        }
    }
}

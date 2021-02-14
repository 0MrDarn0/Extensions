using System;

namespace Kx.Extensions
{
    /// <summary>
    /// Extensions for <see cref="Enum"/>
    /// </summary>
    static public class EnumExtensions
    {
        /// <summary>
        /// Get the next value from the Enum
        /// </summary>
        static public T Next<T>(this T src) where T : struct
        {
            if (!typeof(T).IsEnum) throw new ArgumentException(String.Format("Argument {0} is not an Enum", typeof(T).FullName));

            T[] Arr = (T[])Enum.GetValues(src.GetType());
            int j = Array.IndexOf<T>(Arr, src) + 1;
            return (Arr.Length == j) ? Arr[0] : Arr[j];
        }
    }
}

using System;

namespace Kx.Extensions
{
    /// <summary>
    /// Extensions for numeric types.
    /// </summary>
    static public class NumericExtensions
    {
        /// <summary>
        /// Clamps a value to a given range.
        /// </summary>
        static public T Clamp<T>(this T value,  T min,  T max) where T : IComparable<T>
        {
            // Ensure max is greater than min
            if (max.CompareTo(min) < 0)
                throw new ArgumentException("Max must be greater than or equal to min.");

            // If value is less than min - return min
            if (value.CompareTo(min) <= 0)
                return min;

            // If value is greater than max - return max
            if (value.CompareTo(max) >= 0)
                return max;

            // Otherwise - return value
            return value;
        }

        /// <summary>
        /// Clamps a value to a given range.
        /// </summary>
        static public T ClampMin<T>( this T value,  T min) where T : IComparable<T>
        {
            // If value is less than min - return min
            if (value.CompareTo(min) <= 0)
                return min;

            // Otherwise - return value
            return value;
        }

        /// <summary>
        /// Clamps a value to a given range.
        /// </summary>
        static public T ClampMax<T>(this T value, T max) where T : IComparable<T>
        {
            // If value is greater than max - return max
            if (value.CompareTo(max) >= 0)
                return max;

            // Otherwise - return value
            return value;
        }
    }
}

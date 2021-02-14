using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kx.Extensions
{
    /// <summary>
    /// Extensions for <see cref="string" />.
    /// </summary>
    static public class StringExtensions
    {
        /// <summary>
        /// Indicates whether a string is null or empty.
        /// </summary>
        static public bool IsNullOrEmpty(this string s) => string.IsNullOrEmpty(s);

        /// <summary>
        /// Indicates whether a string is either null, empty, or whitespace.
        /// </summary>
        static public bool IsNullOrWhiteSpace(this string s) => string.IsNullOrWhiteSpace(s);

        /// <summary>
        /// Returns an empty string if given a null string, otherwise returns given string.
        /// </summary>
        static public string EmptyIfNull(this string s) => s ?? string.Empty;

        /// <summary>
        /// Determines whether the string only consists of digits.
        /// </summary>
        static public bool IsNumeric(this string s)
        {
            return s.ToCharArray().All(char.IsDigit);
        }

        /// <summary>
        /// Determines whether the string only consists of letters.
        /// </summary>
        static public bool IsAlphabetic(this string s)
        {
            return s.ToCharArray().All(char.IsLetter);
        }

        /// <summary>
        /// Determines whether the string only consists of letters and/or digits.
        /// </summary>
        static public bool IsAlphanumeric(this string s)
        {
            return s.ToCharArray().All(char.IsLetterOrDigit);
        }

        /// <summary>
        /// Removes all leading occurrences of a substring in the given string.
        /// </summary>
        static public string TrimStart(this string s, string sub,
            StringComparison comparison = StringComparison.Ordinal)
        {
            while (s.StartsWith(sub, comparison))
                s = s.Substring(sub.Length);

            return s;
        }

        /// <summary>
        /// Removes all trailing occurrences of a substring in the given string.
        /// </summary>
        static public string TrimEnd(this string s, string sub,
            StringComparison comparison = StringComparison.Ordinal)
        {
            while (s.EndsWith(sub, comparison))
                s = s.Substring(0, s.Length - sub.Length);

            return s;
        }

        /// <summary>
        /// Removes all leading and trailing occurrences of a substring in the given string.
        /// </summary>
        static public string Trim(this string s, string sub,
            StringComparison comparison = StringComparison.Ordinal)
        {
            return s.TrimStart(sub, comparison).TrimEnd(sub, comparison);
        }

        /// <summary>
        /// Reverses order of characters in a string.
        /// </summary>
        static public string Reverse(this string s)
        {
            // If length is 1 char or less - return same string
            if (s.Length <= 1)
                return s;

            // Concat a new string
            var sb = new StringBuilder(s.Length);
            for (var i = s.Length - 1; i >= 0; i--)
                sb.Append(s[i]);

            return sb.ToString();
        }

        /// <summary>
        /// Returns a string formed by repeating the given string given number of times.
        /// </summary>
        static public string Repeat(this string s, int count)
        {
            // If count is 0 - return empty string
            if (count == 0)
                return string.Empty;

            // Concat a new string
            var sb = new StringBuilder(s.Length * count);
            for (var i = 0; i < count; i++)
                sb.Append(s);

            return sb.ToString();
        }

        /// <summary>
        /// Returns a string formed by repeating the given character given number of times.
        /// </summary>
        static public string Repeat(this char c, int count)
        {
            // If count is 0 - return empty string
            if (count == 0)
                return string.Empty;

            return new string(c, count);
        }

        /// <summary>
        /// Returns a new string in which all occurrences of a specified string in the current instance are replaced with another specified string.
        /// </summary>
        static public string Replace(this string s, string oldValue, string newValue,
            StringComparison comparison = StringComparison.Ordinal)
        {
            var sb = new StringBuilder();

            var offset = 0;
            while (true)
            {
                // Find the next occurence of old value
                var index = s.IndexOf(oldValue, offset, comparison);

                // If not found - append the rest of the string and return
                if (index < 0)
                {
                    sb.Append(s, offset, s.Length - offset);
                    return sb.ToString();
                }

                // Append a portion of the string since last occurence until this one
                sb.Append(s, offset, index - offset);

                // Append new value
                sb.Append(newValue);

                // Advance offset
                offset = index + oldValue.Length;
            }
        }

        /// <summary>
        /// Discards null, empty and whitespace strings from a sequence.
        /// </summary>
        static public IEnumerable<string> ExceptNullOrWhiteSpace(this IEnumerable<string> source)
        {
            return source.Where(s => !IsNullOrWhiteSpace(s));
        }

        /// <summary>
        /// Splits string using given separators, discarding empty entries.
        /// </summary>
        static public string[] Split(this string s, params string[] separators)
        {
            return s.Split(separators, StringSplitOptions.RemoveEmptyEntries);
        }

        /// <summary>
        /// Splits string using given separators, discarding empty entries.
        /// </summary>
        static public string[] Split(this string s, params char[] separators)
        {
            return s.Split(separators, StringSplitOptions.RemoveEmptyEntries);
        }

    }
}

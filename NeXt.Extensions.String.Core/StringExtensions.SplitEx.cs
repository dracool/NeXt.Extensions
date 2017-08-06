using System;
using System.Collections.Generic;

namespace NeXt.Extensions.String
{
    public static partial class StringExtensions
    {
        /// <summary>
        /// Splits a string by a single char delimiter (omits empty values), execution is deferred
        /// </summary>
        /// <param name="s">the string to split</param>
        /// <param name="delimiter">the delimiter to split on</param>
        public static IEnumerable<string> SplitEx(this string s, char delimiter)
        {
            IEnumerable<string> DoSplit()
            {
                var cIndex = 0;
                int nIndex;
                do
                {
                    nIndex = s.IndexOf(delimiter, cIndex);
                    //omit empty
                    if (nIndex > cIndex + 1)
                    {
                        yield return s.Slice(cIndex, nIndex);
                    }
                    cIndex = nIndex + 1;
                } while (nIndex >= 0);
            }

            if (s == null) throw new ArgumentNullException(nameof(s));
            if (string.IsNullOrEmpty(s)) throw new ArgumentException("Value cannot be empty.", nameof(s));
            return DoSplit();
        }

        /// <summary>
        /// Splits a string by calling a delegate to determine if a character is a delimiter (omits empty values), execution is deferred
        /// </summary>
        /// <param name="s">the string to split</param>
        /// <param name="isDelimiter">the delegate that deterimines if a character is a delimiter</param>
        public static IEnumerable<string> SplitEx(this string s, Func<char, bool> isDelimiter)
        {
            IEnumerable<string> DoSplit()
            {

                var cIndex = 0;
                var nIndex = 0;
                do
                {
                    while (nIndex < s.Length && !isDelimiter(s[nIndex]))
                    {
                        nIndex++;
                    }
                    //omit empty
                    if (nIndex > cIndex + 1)
                    {
                        yield return s.Slice(cIndex, nIndex);
                    }
                    cIndex = nIndex + 1;
                    nIndex = cIndex + 1;
                } while (nIndex >= 0);
            }

            if (s == null) throw new ArgumentNullException(nameof(s));
            if (isDelimiter == null) throw new ArgumentNullException(nameof(isDelimiter));
            if (string.IsNullOrEmpty(s)) throw new ArgumentException("Value cannot be empty.", nameof(s));
            return DoSplit();
        }

        /// <summary>
        /// Splits a string by calling a delegate to determine if a character is a delimiter (omits empty values), execution is deferred
        /// </summary>
        /// <param name="s">the string to split</param>
        /// <param name="isDelimiter">the delegate that deterimines if a character is a delimiter</param>
        public static IEnumerable<string> SplitEx(this string s, Func<char, int, bool> isDelimiter)
        {
            IEnumerable<string> DoSplit()
            {
                var cIndex = 0;
                var nIndex = 0;
                do
                {
                    while (nIndex < s.Length && !isDelimiter(s[nIndex], nIndex))
                    {
                        nIndex++;
                    }
                    //omit empty
                    if (nIndex > cIndex + 1)
                    {
                        yield return s.Slice(cIndex, nIndex);
                    }
                    cIndex = nIndex + 1;
                    nIndex = cIndex + 1;
                } while (nIndex >= 0);
            }

            if (s == null) throw new ArgumentNullException(nameof(s));
            if (isDelimiter == null) throw new ArgumentNullException(nameof(isDelimiter));
            if (string.IsNullOrEmpty(s)) throw new ArgumentException("Value cannot be empty.", nameof(s));
            return DoSplit();
        }

        /// <summary>
        /// Splits a string by a string delimiter (omits empty values), execution is deferred
        /// </summary>
        /// <param name="s">the string to split</param>
        /// <param name="delimiter">the delimiter to split on</param>
        /// <param name="comparisonType">the type of string comparison (defaults to ordinal)</param>
        public static IEnumerable<string> SplitEx(this string s, string delimiter, StringComparison comparisonType = StringComparison.Ordinal)
        {
            IEnumerable<string> DoSplit()
            {
                var cIndex = 0;
                int nIndex;
                do
                {
                    nIndex = s.IndexOf(delimiter, cIndex, comparisonType);
                    //omit empty
                    if (nIndex > cIndex + 1)
                    {
                        yield return s.Slice(cIndex, nIndex);
                    }
                    cIndex = nIndex + delimiter.Length;
                } while (nIndex >= 0);
            }

            if (s == null) throw new ArgumentNullException(nameof(s));
            if (delimiter == null) throw new ArgumentNullException(nameof(delimiter));
            if (string.IsNullOrEmpty(s)) throw new ArgumentException("Value cannot be empty.", nameof(s));
            return DoSplit();
        }
    }
}
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace NeXt.Extensions.String
{
    public static partial class StringExtensions
    {
        /// <summary>
        /// splits a string into key and value at the first occurance of the delimiter, the value is <c>string.Empty</c> if the delimiter is missing
        /// </summary>
        /// <param name="s">the string to split</param>
        /// <param name="delimiter">the delimiter to split on</param>
        public static (string key, string value) ToKeyValue(this string s, char delimiter)
        {
            if (s == null) throw new ArgumentNullException(nameof(s));

            var x = s.IndexOf(delimiter);
            if (x > 0)  return (s.Slice(-x), s.Slice(x));
            if (x == 0) return (string.Empty, s.Slice(x));
            return (s, string.Empty);
        }

        /// <summary>
        /// splits a string into key and value at the first occurance of any of the delimiters, the value is <c>string.Empty</c> if the delimiter is missing
        /// </summary>
        /// <param name="s">the string to split</param>
        /// <param name="delimiters">array of allowed delimiters</param>
        public static (string key, string value) ToKeyValue(this string s, params char[] delimiters)
        {
            if (s == null) throw new ArgumentNullException(nameof(s));
            if (delimiters == null) throw new ArgumentNullException(nameof(delimiters));

            var x = s.IndexOfAny(delimiters);
            if (x > 0) return (s.Slice(-x), s.Slice(x));
            if (x == 0) return (string.Empty, s.Slice(x));
            return (s, string.Empty);
        }

        /// <summary>
        /// splits a string into key and value at the first occurance of any of the delimiters, the value is <c>string.Empty</c> if the delimiter is missing
        /// </summary>
        /// <param name="s">the string to split</param>
        /// <param name="delimiters">enumerable of allowed delimiters</param>
        public static (string key, string value) ToKeyValue(this string s, IEnumerable<char> delimiters)
        {
            if (s == null) throw new ArgumentNullException(nameof(s));
            if (delimiters == null) throw new ArgumentNullException(nameof(delimiters));

            var x = s.IndexOfAny(delimiters);
            if (x > 0) return (s.Slice(-x), s.Slice(x));
            if (x == 0) return (string.Empty, s.Slice(x));
            return (s, string.Empty);
        }

        /// <summary>
        /// splits a string into key and value at the first occurance of the delimiter, the value is <c>string.Empty</c> if the delimiter is missing
        /// </summary>
        /// <param name="s">the string to split</param>
        /// <param name="delimiter">the delimiter to split on</param>
        public static (string key, string value) ToKeyValue(this string s, string delimiter)
        {
            if (s == null) throw new ArgumentNullException(nameof(s));
            if (delimiter == null) throw new ArgumentNullException(nameof(delimiter));

            var x = s.IndexOf(delimiter, StringComparison.Ordinal);

            if (x > 0) return (s.Slice(-x), s.Substring(x + delimiter.Length));
            if (x == 0) return (string.Empty, s.Substring(delimiter.Length));
            return (s, string.Empty);
        }
    }
}
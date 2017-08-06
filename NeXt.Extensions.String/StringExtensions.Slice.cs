using System;

namespace NeXt.Extensions.String
{
    public static partial class StringExtensions
    {
        /// <summary>
        /// Slices from <paramref name="beginIndex"/> to <paramref name="excludedIndex"/>
        /// a slice doesn't include the <paramref name="excludedIndex"/> which makes it particularily useful for use with string.IndexOf on delimiters
        /// </summary>
        /// <param name="s"></param>
        /// <param name="beginIndex"></param>
        /// <param name="excludedIndex"></param>
        public static string Slice(this string s, int beginIndex, int excludedIndex)
        {
            if (s == null) throw new ArgumentNullException(nameof(s));

            return s.Substring(beginIndex, excludedIndex - beginIndex);
        }

        /// <summary>
        /// Shorthand substring for text parsing: the index is the delimiter character that is not part of the sliced string
        /// </summary>
        /// <remarks>
        /// Slicing on the index x returns the string from the character after index to end
        /// This function handles negative indices to slice from beginning to the character before Abs(index)
        /// 
        /// Example:
        /// <code>
        ///     var test = "Hello World";
        ///     var hello = text.Slice(-5));
        ///     var world = text.Slice( 5);
        /// </code>
        /// </remarks>
        /// <param name="s"></param>
        /// <param name="index">the delimiter index</param>
        public static string Slice(this string s, int index)
        {
            if (s == null) throw new ArgumentNullException(nameof(s));

            return index < 0 ? s.Substring(0, -index) : s.Substring(index + 1);
        }
    }
}
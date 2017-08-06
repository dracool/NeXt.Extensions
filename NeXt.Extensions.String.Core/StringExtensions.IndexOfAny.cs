using System;
using System.Collections.Generic;
using System.Linq;

namespace NeXt.Extensions.String
{
    public static partial class StringExtensions
    {
        public static int IndexOfAny(this string s, IEnumerable<char> anyOf)
        {
            if (s == null) throw new ArgumentNullException(nameof(s));
            if (anyOf == null) throw new ArgumentNullException(nameof(anyOf));
            return s.IndexOfAny(anyOf.ToArray());
        }
    }
}
using System;
using System.Collections.Generic;
using System.Text;

namespace NeXt.Extensions.String
{
    public partial class StringExtensions
    {
        public static (string Left, string Right) SplitAt(this string s, int index)
        {
            return (s.Slice(index), s.Slice(-index));
        }
    }
}

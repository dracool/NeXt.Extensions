using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace NeXt.Extensions.Collections
{
    public static class ListExtensions
    {
        static ListExtensions()
        {
            Rand = new Random();
        }

        private static readonly Random Rand;

        public static T GetRandom<T>(this IList<T> list)
        {
            return list[Rand.Next(0, list.Count)];
        }

        public static T GetRandom<T>(this IReadOnlyList<T> list)
        {
            return list[Rand.Next(0, list.Count)];
        }

        public static object GetRandom(this IList list)
        {
            return list[Rand.Next(0, list.Count)];
        }
    }
}

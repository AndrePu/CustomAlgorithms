using System;
using System.Collections.Generic;
using System.Linq;

namespace CustomAlgorithms.Tests.Sorting
{
    public static class ListExtensions
    {
        public static IList<T> Clone<T>(this IList<T> listToClone) where T : struct
        {
            return listToClone.Select(item => item).ToList();
        }
    }
}

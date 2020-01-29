using System;
using System.Collections.Generic;
using System.Text;

namespace CustomAlgorithms.Tests.Sorting
{
    public class SortingTestsHelper
    {
        public IList<int> GenerateIntList(int size, int inf = -1000000, int sup = 1000000)
        {
            var list = new List<int>(size);

            var rand = new Random();

            for (int i = 0; i < size; i++)
            {
                list.Add(rand.Next(inf, sup));
            }

            return list;
        }
    }
}

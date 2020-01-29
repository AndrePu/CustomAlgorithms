using System;
using System.Collections.Generic;
using System.Text;

namespace CustomAlgorithms.Sorting
{
    public class BubbleSort<T> : SortingAlgorithm<T> where T : IComparable<T>
    {
        public override void Sort(IList<T> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                for (int j = 1; j < list.Count - i; j++)
                {
                    if (list[j - 1].CompareTo(list[j]) == 1)
                    {
                        Swap(list, j - 1, j);
                    }
                }
            }
        }
    }
}

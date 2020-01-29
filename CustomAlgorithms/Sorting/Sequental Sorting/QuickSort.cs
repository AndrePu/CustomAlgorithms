using System;
using System.Collections.Generic;

namespace CustomAlgorithms.Sorting
{
    public class QuickSort<T> : SortingAlgorithm<T> where T : IComparable<T>
    {
        public override void Sort(IList<T> list)
        {
            QuickSortProcess(list, 0, list.Count - 1);
        }
        
        /// <summary>
        /// Sorts list collection by algorithm of Quick Sort.
        /// </summary>
        /// <param name="list"></param>
        /// <param name="left">Left index of sorting segment.</param>
        /// <param name="right">Right index of sortings segment.</param>
        private void QuickSortProcess(IList<T> list, int left, int right)
        {
            if (right - left > 0)
            {
                int dividePoint = Partition(list, left, right);

                QuickSortProcess(list, left, dividePoint - 1);
                QuickSortProcess(list, dividePoint + 1, right);
            }
        }

        private int Partition(IList<T> list, int left, int right)
        {
            T pivot = list[right];
            int j = left - 1;

            for (int i = left; i < right; i++)
            {
                if (list[i].CompareTo(pivot) == -1)
                {
                    j++;
                    Swap(list, i, j);
                }
            }

            j++;
            Swap(list, j, right);

            return j;
        }

    }
}

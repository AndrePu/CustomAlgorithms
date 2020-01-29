using System;
using System.Collections.Generic;
using System.Text;

namespace CustomAlgorithms.Sorting
{
    public class MergeSort<T> : SortingAlgorithm<T> where T : IComparable<T>
    {
        public override void Sort(IList<T> list)
        {
            MergeSortProcess(list, 0, list.Count - 1);
        }

        private void MergeSortProcess(IList<T> list, int from, int to)
        {
            int mid;
            if (from < to)
            {
                mid = from + (to - from) / 2;
                MergeSortProcess(list, from, mid); //left
                MergeSortProcess(list, mid + 1, to);
                Merge(list, from, to, mid);
            }

        }

        private void Merge(IList<T> list, int from, int to, int mid)
        {
            int i = from;
            int j = mid + 1;
            List<T> vector = new List<T>(to - from + 1);

            /*merge two parts in the vector*/
            while (i <= mid && j <= to)
            {
                if (list[i].CompareTo(list[j]) == -1)
                {
                    vector.Add(list[i]);
                    i++;
                }
                else
                {
                    vector.Add(list[j]);
                    j++;
                }
            }

            /*Inserting all the remaining values in vector*/
            while (i <= mid)
            {
                vector.Add(list[i]);
                i++;
            }

            while (j <= to)
            {
                vector.Add(list[j]);
                j++;
            }

            for (i = from; i <= to; i++)
            {
                list[i] = vector[i - from];
            }
        }
    }
}

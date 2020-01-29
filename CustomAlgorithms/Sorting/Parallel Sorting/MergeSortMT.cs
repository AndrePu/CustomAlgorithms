using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CustomAlgorithms.Sorting.ParallelSorting
{
    public class MergeSortMT<T> : ParallelSorting<T> where T : IComparable<T>
    {
        public override void Sort(IList<T> list)
        {
            MergeSortProcessMT(list, 0, list.Count - 1);
        }

        private void MergeSortProcessMT(IList<T> list, int from, int to)
        {
            int mid, reservedExtraThreads = 0;

            lock (locked)
            {
                if (accessibleExtraThreads > 0)
                {
                    reservedExtraThreads = 1;
                    accessibleExtraThreads -= 1;
                }
            }


            if (from < to)
            {
                mid = from + (to - from) / 2;

                if (reservedExtraThreads != 0)
                {
                    var leftPart = new Task(() => MergeSortProcessMT(list, from, mid)); //left

                    leftPart.Start();
                    MergeSortProcessMT(list, mid + 1, to);

                    leftPart.Wait();
                    accessibleExtraThreads++;
                }
                else
                {
                    MergeSortProcessMT(list, from, mid);
                    MergeSortProcessMT(list, mid + 1, to);
                }

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

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CustomAlgorithms.Sorting.ParallelSorting
{
    public class QuickSortMT<T> : ParallelSorting<T> where T : IComparable<T>
    {
        public override void Sort(IList<T> list)
        {
            QuickSortProcessMT(list, 0, list.Count - 1);
        }

        private void QuickSortProcessMT(IList<T> list, int left, int right)
        {
            int reservedExtraThreads = 0;

            lock (locked)
            {
                if (accessibleExtraThreads > 0)
                {
                    reservedExtraThreads = 1;
                    accessibleExtraThreads -= 1;
                }
            }

            if (right - left > 0)
            {
                int dividePoint = Partition(list, left, right);

                if (reservedExtraThreads != 0)
                {
                    var leftPart = new Task(() => QuickSortProcessMT(list, left, dividePoint - 1));
                    leftPart.Start();
                    QuickSortProcessMT(list, dividePoint + 1, right);

                    leftPart.Wait();
                    accessibleExtraThreads++;
                }
                else
                {
                    QuickSortProcessMT(list, left, dividePoint - 1);
                    QuickSortProcessMT(list, dividePoint + 1, right);
                }
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

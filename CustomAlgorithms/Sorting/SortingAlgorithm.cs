using System;
using System.Collections.Generic;


namespace CustomAlgorithms.Sorting
{
    public abstract class SortingAlgorithm<T> where T : IComparable<T>
    {
        public abstract void Sort(IList<T> list);

        protected void Swap(IList<T> list, int index1, int index2)
        {
            var temp = list[index1];
            list[index1] = list[index2];
            list[index2] = temp;
        }
    }
}

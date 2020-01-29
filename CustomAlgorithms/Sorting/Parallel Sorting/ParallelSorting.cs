using System;
using System.Collections.Generic;
using System.Text;

namespace CustomAlgorithms.Sorting.ParallelSorting
{
    public abstract class ParallelSorting<T> : SortingAlgorithm<T> where T : IComparable<T>
    {
        protected object locked = "dummy";
        protected int accessibleExtraThreads = Environment.ProcessorCount - 1;
    }
}

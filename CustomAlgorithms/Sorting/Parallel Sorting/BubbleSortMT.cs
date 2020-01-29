using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CustomAlgorithms.Sorting.ParallelSorting
{
    public class BubbleSortMT<T> : ParallelSorting<T> where T : IComparable<T>
    {
        public override void Sort(IList<T> list)
        {
            int listHalfAmount = list.Count / 2;

            for (int i = 0; i < list.Count; i++)
            {
                var tasks = new List<Task>(capacity: listHalfAmount);

                for (int j = i % 2; j < list.Count; j += 2)
                {
                    if (j + 1 != list.Count)
                    {
                        // Solving closure problem
                        int index1 = j;
                        int index2 = j + 1;

                        tasks.Add(new Task(() => DefineBiggerElement(list, index1, index2)));
                    }
                }

                ExecuteTasks(tasks, list.Count);
            }
        }

        private void ExecuteTasks(IList<Task> tasks, int listElementsCount)
        {
            int curFreeTask = (tasks.Count >= accessibleExtraThreads) ? accessibleExtraThreads : listElementsCount;

            for (int j = 0; j < tasks.Count && j < accessibleExtraThreads; j++)
            {
                tasks[j].Start();
            }


            foreach (var task in tasks)
            {
                task.Wait();

                lock (locked)
                {
                    if (curFreeTask != tasks.Count)
                    {
                        tasks[curFreeTask].Start();
                        curFreeTask++;
                    }
                }
            }
        }

        private void DefineBiggerElement(IList<T> list, int index1, int index2)
        {
            if (list[index1].CompareTo(list[index2]) == 1)
            {
                Swap(list, index1, index2);
            }
        }
    }
}

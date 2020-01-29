using NUnit.Framework;
using CustomAlgorithms.Sorting.ParallelSorting;
using System.Linq;
using System.Collections.Generic;

namespace CustomAlgorithms.Tests.Sorting
{

    [TestFixture]
    public class ParallelSortingsTests
    {
        private SortingTestsHelper testsHelper;

        [SetUp]
        public void Setup()
        {
            testsHelper = new SortingTestsHelper();
        }

        [Order(0)]
        [TestCase(TestName = "Correctness of Quick Parallel Sort")]
        public void CheckQuickSortAlgorithm()
        {
            int numsAmount = 1000000;
            ParallelSorting<int> sortAlgorithm = new QuickSortMT<int>();

            var list1 = testsHelper.GenerateIntList(numsAmount);
            var list2 = list1.Clone();


            sortAlgorithm.Sort(list1);
            ((List<int>)list2).Sort();
            

            Assert.IsTrue(list1.SequenceEqual(list2));
        }

        [Order(1)]
        [TestCase(TestName = "Correctness of Merge Parallel Sort")]
        public void CheckMergeSortAlgorithm()
        {
            int numsAmount = 1000000;
            ParallelSorting<int> sortAlgorithm = new MergeSortMT<int>();

            var list1 = testsHelper.GenerateIntList(numsAmount);
            var list2 = list1.Clone();


            sortAlgorithm.Sort(list1);
            ((List<int>)list2).Sort();


            Assert.IsTrue(list1.SequenceEqual(list2));
        }

        [Order(2)]
        [TestCase(TestName = "Correctness of Bubble Parallel Sort")]
        public void CheckBubbleSortAlgorithm()
        {
            int numsAmount = 1000;
            ParallelSorting<int> sortAlgorithm = new BubbleSortMT<int>();

            var list1 = testsHelper.GenerateIntList(numsAmount);
            var list2 = list1.Clone();


            sortAlgorithm.Sort(list1);
            ((List<int>)list2).Sort();


            Assert.IsTrue(list1.SequenceEqual(list2));
        }

    }
}
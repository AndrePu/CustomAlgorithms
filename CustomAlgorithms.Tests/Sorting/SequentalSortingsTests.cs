using NUnit.Framework;
using CustomAlgorithms.Sorting;
using System.Linq;
using System.Collections.Generic;

namespace CustomAlgorithms.Tests.Sorting
{

    [TestFixture]
    public class SequentalSortingsTests
    {
        private SortingTestsHelper testsHelper;

        [SetUp]
        public void Setup()
        {
            testsHelper = new SortingTestsHelper();
        }

        [Order(0)]
        [TestCase(TestName = "Correctness of Quick Sort")]
        public void CheckQuickSortAlgorithm()
        {
            int numsAmount = 1000000;
            SortingAlgorithm<int> sortAlgorithm = new QuickSort<int>();

            var list1 = testsHelper.GenerateIntList(numsAmount);
            var list2 = list1.Clone();


            sortAlgorithm.Sort(list1);
            ((List<int>)list2).Sort();
            

            Assert.IsTrue(list1.SequenceEqual(list2));
        }

        [Order(1)]
        [TestCase(TestName = "Correctness of Merge Sort")]
        public void CheckMergeSortAlgorithm()
        {
            int numsAmount = 1000000;
            SortingAlgorithm<int> sortAlgorithm = new MergeSort<int>();

            var list1 = testsHelper.GenerateIntList(numsAmount);
            var list2 = list1.Clone();


            sortAlgorithm.Sort(list1);
            ((List<int>)list2).Sort();


            Assert.IsTrue(list1.SequenceEqual(list2));
        }

        [Order(2)]
        [TestCase(TestName = "Correctness of Bubble Sort")]
        public void CheckBubbleSortAlgorithm()
        {
            int numsAmount = 10000;
            SortingAlgorithm<int> sortAlgorithm = new BubbleSort<int>();

            var list1 = testsHelper.GenerateIntList(numsAmount);
            var list2 = list1.Clone();


            sortAlgorithm.Sort(list1);
            ((List<int>)list2).Sort();


            Assert.IsTrue(list1.SequenceEqual(list2));
        }

    }
}
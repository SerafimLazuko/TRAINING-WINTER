using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static LogicMerge.MergeSortClass;

namespace LogicMerge.Tests
{
    [TestClass]
    public class MergeSortClassTest
    {
        [TestMethod]
        public void MergeSort_SortIntArray_ReturnedMerged()
        {
            int[] arr = { 3, 2, 1 };
            int[] expected = { 1, 2, 3 };

            int[] actual = MergeSort(arr);

            string s1 = expected.ToString();
            string s2 = actual.ToString();

            Assert.AreEqual(s1, s2);
        }


        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void MergeSort_ReceivesNullRef_ThrowsArgumentNullExeption()
        {
            int[] inputArray = null;

            MergeSort(inputArray);

        }


    }
}
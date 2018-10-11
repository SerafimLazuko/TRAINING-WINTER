using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static QSort.QSort;

namespace QSortLogic.Tests
{
    [TestClass]
    public class QSortTest
    {
        [TestMethod]
        public void QSort_ReceivesUnsortedArray_ReturnsSorted()
        {
            int[] inputArray = new[] { 9, 8, 7, 6, 5, 4, 3, 2, 1 };

            int[] expected = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            QuickSort(inputArray);
            
            CollectionAssert.AreEqual(inputArray, expected);
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void QSort_ReceivesNullRef_ThrowsArgumentNullExeption()
        {
            int[] inputArray = null;

            QuickSort(inputArray);

        }
    }
}

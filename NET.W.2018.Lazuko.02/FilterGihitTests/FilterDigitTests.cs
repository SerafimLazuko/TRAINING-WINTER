using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static FilterDigitLogic.Filter;

namespace FilterGigitTests
{
    [TestClass]
    public class FilterDigitTests
    {

        [TestMethod]
        public void FilterDigit_ReceivesNumberListAndSpecialDigit_DeletesElementsWithoutSpecialDigit()
        {
            List<int> list = new List<int> { 7, 1, 2, 3, 4, 5, 6, 7, 68, 69, 70, 15, 17 };

            List<int> expected = new List<int> { 7, 7, 70, 17 };

            FilterDigit(list, 7);

            Microsoft.VisualStudio.TestTools.UnitTesting.CollectionAssert.AreEqual(list, expected);
        }


        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void FilterDigit_ReceivesNullRef_ThrowsArgumentNullExeption()
        {
            List<int> list = null;

            FilterDigit(list, 9);

        }


        [TestMethod, ExpectedException(typeof(Exception))]
        public void FilterDigit_ReceivesEmptyList_ThrowsExeption()
        {
            List<int> list = new List<int> { };

            FilterDigit(list, 9);

        }
    }
}

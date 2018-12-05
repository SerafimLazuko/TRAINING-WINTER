using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static BinarySearch.Search;

namespace BinarySearch.Tests
{
    [TestClass]
    public class BinarySearchTests
    {
        [TestMethod]
        public void BinarySearch_checkForInt()
        {
            int[] array = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            int value = 7;

            int? actual = BinarySearch<int>(array, value);

            int? expected = 7;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void BinarySearch_checkForString()
        {
            string[] array = new string[] { "string0", "string1", "string2", "string3", "string4" };
            string value = "string3";

            int? actual = BinarySearch<string>(array, value);

            int? expected = 3;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void BinarySearch_checkForInt_returnsNull()
        {
            int[] array = new int[] { 0, 10, 20, 30, 40, 50, 60, 70, 80, 90 };
            int value = 75;

            int? actual = BinarySearch<int>(array, value);

            int? expected = null;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod, ExpectedException(typeof(NullReferenceException))]
        public void BinarySearch_checkForInt_ThrowsArgumentNullExeption()
        {
            int[] array = null;
            int value = 10;

            BinarySearch<int>(array, value);
        }
    }
}

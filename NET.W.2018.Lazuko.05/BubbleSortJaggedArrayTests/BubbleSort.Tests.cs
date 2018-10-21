using Microsoft.VisualStudio.TestTools.UnitTesting;
using static BubbleSortJaggedArrayLogic.BubbleSort;

namespace BubbleSortJaggedArrayTests
{
    [TestClass]
    public class UnitTest1
    {

        [TestMethod]
        public void SortInSumsAscending_ReceivesJaggedArray_ReturnsSorter()
        {
            int[][] actual = new int[5][];

            actual[0] = new int[5] { 9, 2, 11, 7, 9 };
            actual[1] = new int[3] { 10, 6, 8 };
            actual[2] = new int[4] { 2, 4, 6, 8 };
            actual[3] = new int[4] { 2, 0, 6, 0 };
            actual[4] = new int[2] { 2, 4 };

            int[][] expected = new int[5][];

            expected[0] = new int[2] { 2, 4 };
            expected[1] = new int[4] { 2, 0, 6, 0 };
            expected[2] = new int[4] { 2, 4, 6, 8 };
            expected[3] = new int[3] { 10, 6, 8 };
            expected[4] = new int[5] { 9, 2, 11, 7, 9 };

            SortInSumsAscending(actual);

            EqualCheck(expected, actual);
        }

        [TestMethod]
        public void SortInSumsDescending_ReceivesJaggedArray_ReturnsSorter()
        {
            int[][] actual = new int[5][];

            actual[0] = new int[5] { 9, 2, 11, 7, 9 };
            actual[1] = new int[3] { 10, 6, 8 };
            actual[2] = new int[4] { 2, 4, 6, 8 };
            actual[3] = new int[4] { 2, 0, 6, 0 };
            actual[4] = new int[2] { 2, 4 };

            int[][] expected = new int[5][];

            expected[0] = new int[5] { 9, 2, 11, 7, 9 };
            expected[1] = new int[3] { 10, 6, 8 };
            expected[2] = new int[4] { 2, 4, 6, 8 };
            expected[3] = new int[4] { 2, 0, 6, 0 };
            expected[4] = new int[2] { 2, 4 };

            SortInSumsAscending(actual);

            EqualCheck(expected, actual);
        }

        [TestMethod]
        public void SortInMaxValAscending_ReceivesJaggedArray_ReturnsSorter()
        {
            int[][] actual = new int[5][];

            actual[0] = new int[5] { 9, 2, 11, 7, 9 };
            actual[1] = new int[3] { 10, 6, 8 };
            actual[2] = new int[4] { 2, 4, 6, 8 };
            actual[3] = new int[4] { 2, 0, 6, 0 };
            actual[4] = new int[2] { 2, 4 };

            int[][] expected = new int[5][];

            expected[0] = new int[2] { 2, 4 };
            expected[1] = new int[4] { 2, 0, 6, 0 };
            expected[2] = new int[4] { 2, 4, 6, 8 };
            expected[3] = new int[3] { 10, 6, 8 };
            expected[4] = new int[5] { 9, 2, 11, 7, 9 };

            SortInSumsAscending(actual);

            EqualCheck(expected, actual);
        }

        [TestMethod]
        public void SortInMaxValDescending_ReceivesJaggedArray_ReturnsSorter()
        {
            int[][] actual = new int[5][];

            actual[0] = new int[5] { 9, 2, 11, 7, 9 };
            actual[1] = new int[3] { 10, 6, 8 };
            actual[2] = new int[4] { 2, 4, 6, 8 };
            actual[3] = new int[4] { 2, 0, 6, 0 };
            actual[4] = new int[2] { 2, 4 };

            int[][] expected = new int[5][];

            expected[0] = new int[5] { 9, 2, 11, 7, 9 };
            expected[1] = new int[3] { 10, 6, 8 };
            expected[2] = new int[4] { 2, 4, 6, 8 };
            expected[3] = new int[4] { 2, 0, 6, 0 };
            expected[4] = new int[2] { 2, 4 };

            SortInSumsAscending(actual);

            EqualCheck(expected, actual);
        }

        private static bool EqualCheck(int[][] arr1, int[][] arr2)
        {
            for(int i = 0; i < arr1.Length; i++)
            {
                for(int j = 0; j < arr1[i].Length; j++)
                {
                    if (arr1[i][j] != arr2[i][j]) return false;
                }
            }
            return true;
        }
    }
}

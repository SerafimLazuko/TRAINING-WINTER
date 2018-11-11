using System;

namespace BubbleSortJaggedArray.Sorts
{
    /// <summary>
    /// Provides functionality for sorting in according to required condition
    /// </summary>
    /// <seealso cref="BubbleSortJaggedArray.Sorts.ISorter" />
    public class SortInSumsDescending : ISorter
    {
        /// <summary>
        /// Sort method.
        /// </summary>
        /// <param name="jaggedArray">The jagged array.</param>
        /// <exception cref="System.ArgumentNullException">jaggedArray</exception>
        void ISorter.Sort(int[][] jaggedArray)
        {
            if (jaggedArray == null)
                throw new ArgumentNullException(nameof(jaggedArray));

            for (int i = 0; i < jaggedArray.Length; i++)
            {
                for (int j = 0; j < jaggedArray.Length; j++)
                {
                    if (SumRowElements(jaggedArray, row: i) > SumRowElements(jaggedArray, row: j))
                    {
                        SwapRows(ref jaggedArray, i, j);
                    }
                }
            }
        }

        /// <summary>
        /// Returns sum of this row elements.
        /// </summary>
        /// <param name="array">The array.</param>
        /// <param name="row">The row.</param>
        /// <returns></returns>
        private static int SumRowElements(int[][] array, int row)
        {
            int result = 0;

            for (int i = 0; i < array[row].Length; i++)
            {
                result += array[row][i];
            }

            return result;
        }

        /// <summary>
        /// Swaps the rows.
        /// </summary>
        /// <param name="jaggedArray">The jagged array.</param>
        /// <param name="i">The i.</param>
        /// <param name="j">The j.</param>
        private static void SwapRows(ref int[][] jaggedArray, int i, int j)
        {
            int[] temp = jaggedArray[i];
            jaggedArray[i] = jaggedArray[j];
            jaggedArray[j] = temp;

        }
    }
}

using System;
namespace BubbleSortJaggedArrayLogic
{
    /// <summary>
    /// Provides API for executing bubble sorting
    /// </summary>
    public static  class BubbleSort
    {
        #region Sorts
        /// <summary>
        /// Sorts a jagged array in sums ascending.
        /// </summary>
        /// <param name="jaggedArray">The jagged array.</param>
        public static void SortInSumsAscending(int[][] jaggedArray)
        {
            if (jaggedArray == null)
                throw new ArgumentNullException(nameof(jaggedArray));

            for(int i = 0; i < jaggedArray.Length; i++)
            {
                for(int j = 0; j < jaggedArray.Length; j++)
                {
                    if(SumRowElements(jaggedArray,row: i) < SumRowElements(jaggedArray, row: j))
                    {
                        SwapRows(ref jaggedArray, i, j);
                    }
                }
            }
        }

        /// <summary>
        /// Sorts a jagged array in sums descending.
        /// </summary>
        /// <param name="jaggedArray">The jagged array.</param>
        public static void SortInSumsDescending(int[][] jaggedArray)
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
        /// Sorts a jagged array in maximum value ascending.
        /// </summary>
        /// <param name="jaggedArray">The jagged array.</param>
        public static void SortInMaxValAscending(int[][] jaggedArray)
        {
            if (jaggedArray == null)
                throw new ArgumentNullException(nameof(jaggedArray));

            for (int i = 0; i < jaggedArray.Length; i++)
            {
                for(int j = 0; j < jaggedArray.Length; j++)
                {
                    if (FindMax(jaggedArray[i]) > FindMax(jaggedArray[j]))
                        SwapRows(ref jaggedArray, i, j);
                }
            }
        }

        /// <summary>
        /// Sorts a jagged array in maximum value descending.
        /// </summary>
        /// <param name="jaggedArray">The jagged array.</param>
        public static void SortInMaxValDescending(int[][] jaggedArray)
        {
            if (jaggedArray == null)
                throw new ArgumentNullException(nameof(jaggedArray));

            for (int i = 0; i < jaggedArray.Length; i++)
            {
                for (int j = 0; j < jaggedArray.Length; j++)
                {
                    if (FindMax(jaggedArray[i]) < FindMax(jaggedArray[j]))
                        SwapRows(ref jaggedArray, i, j);
                }
            }
        }

        /// <summary>
        /// Sorts a jagged array in minimum value ascending.
        /// </summary>
        /// <param name="jaggedArray">The jagged array.</param>
        public static void SortInMinValAscending(int[][] jaggedArray)
        {
            if (jaggedArray == null)
                throw new ArgumentNullException(nameof(jaggedArray));

            for (int i = 0; i < jaggedArray.Length; i++)
            {
                for (int j = 0; j < jaggedArray.Length; j++)
                {
                    if (FindMin(jaggedArray[i]) < FindMin(jaggedArray[j]))
                        SwapRows(ref jaggedArray, i, j);
                }
            }
        }

        /// <summary>
        /// Sorts a jagged array in minimum value descending.
        /// </summary>
        /// <param name="jaggedArray">The jagged array.</param>
        public static void SortInMinValDescending(int[][] jaggedArray)
        {
            if (jaggedArray == null)
                throw new ArgumentNullException(nameof(jaggedArray));

            for (int i = 0; i < jaggedArray.Length; i++)
            {
                for (int j = 0; j < jaggedArray.Length; j++)
                {
                    if (FindMin(jaggedArray[i]) > FindMin(jaggedArray[j]))
                        SwapRows(ref jaggedArray, i, j);
                }
            }
        }

        #endregion

        #region Private API
        /// <summary>
        /// Finds the minimum.
        /// </summary>
        /// <param name="array">The array.</param>
        /// <returns></returns>
        private static int FindMin(int[] array)
        {
            int result = array[0];

            for (int i = 1; i < array.Length; i++)
                if (result > array[i]) result = array[i];

            return result;
        }

        /// <summary>
        /// Finds the maximum.
        /// </summary>
        /// <param name="array">The array.</param>
        /// <returns></returns>
        private static int FindMax(int[] array)
        {
            int result = array[0];

            for(int i = 1; i < array.Length; i++)
                if (result < array[i]) result = array[i];

            return result;
        }

        /// <summary>
        /// Swaps the elements.
        /// </summary>
        /// <param name="a">a.</param>
        /// <param name="b">The b.</param>
        private static void SwapElements(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
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

        /// <summary>
        /// Sums the row elements.
        /// </summary>
        /// <param name="array">The array.</param>
        /// <param name="row">The row.</param>
        /// <returns></returns>
        private static int SumRowElements(int[][] array, int row)
        {
            int result = 0;

            for(int i = 0; i< array[row].Length; i++)
            {
                result += array[row][i];
            }

            return result;
        }

        #endregion
    }
}

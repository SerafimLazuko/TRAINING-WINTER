using BubbleSortJaggedArray.Sorts;

namespace BubbleSortJaggedArrayLogic
{
    /// <summary>
    /// Provides API for executing bubble sorting
    /// </summary>
    public static  class BubbleSort
    {
        /// <summary>
        /// Performs the sort according to the sorter
        /// </summary>
        /// <param name="sorter">The sorter.</param>
        /// <param name="jaggedArray">The jagged array.</param>
        public static void PerformSort(ISorter sorter, ref int[][] jaggedArray)
        {
            sorter.Sort(jaggedArray);
        }
    }
}

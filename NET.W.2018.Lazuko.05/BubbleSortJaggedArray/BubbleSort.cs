using System;
using BubbleSortJaggedArray.Sorts;

namespace BubbleSortJaggedArrayLogic
{
    /// <summary>
    /// Provides API for executing bubble sorting
    /// </summary>
    public static  class BubbleSort
    {
        public static void PerformSort(ISorter sorter, int[][] jaggedArray)
        {
            sorter.Sort(jaggedArray);
        }
    }
}

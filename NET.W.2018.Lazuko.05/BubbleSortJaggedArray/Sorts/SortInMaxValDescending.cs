using System;

namespace BubbleSortJaggedArray.Sorts
{
    public class SortInMaxValDescending : ISorter
    {
        void ISorter.Sort(int[][] jaggedArray)
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

        private static int FindMax(int[] array)
        {
            int result = array[0];

            for (int i = 1; i < array.Length; i++)
                if (result < array[i]) result = array[i];

            return result;
        }

        private static void SwapRows(ref int[][] jaggedArray, int i, int j)
        {
            int[] temp = jaggedArray[i];
            jaggedArray[i] = jaggedArray[j];
            jaggedArray[j] = temp;

        }
    }
}
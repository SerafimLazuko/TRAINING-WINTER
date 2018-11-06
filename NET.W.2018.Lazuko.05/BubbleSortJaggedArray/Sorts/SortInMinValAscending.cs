using System;

namespace BubbleSortJaggedArray.Sorts
{
    public class SortInMinValAscending : ISorter
    {
        void ISorter.Sort(int[][] jaggedArray)
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

        private static int FindMin(int[] array)
        {
            int result = array[0];

            for (int i = 1; i < array.Length; i++)
                if (result > array[i]) result = array[i];

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
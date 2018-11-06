using System;

namespace BubbleSortJaggedArray.Sorts
{
    public class SortInSumsDescending : ISorter
    {
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

        private static int SumRowElements(int[][] array, int row)
        {
            int result = 0;

            for (int i = 0; i < array[row].Length; i++)
            {
                result += array[row][i];
            }

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

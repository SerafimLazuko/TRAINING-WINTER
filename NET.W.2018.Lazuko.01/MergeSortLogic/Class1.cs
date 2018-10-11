using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MergeSortLogic
{
    public class MergeSort
    {
        #region Public API

        /// <summary>
        /// allows sort the array by merge
        /// </summary>
        /// <param name="array">origin array</param>
        /// <returns>returns sorted array</returns>

        public static int[] MergeSort(int[] array)
        {
            if (array.Length == 1)
            {
                return array;
            }

            int mid_point = array.Length / 2;
            return Merge(MergeSort(array.Take(mid_point).ToArray()), MergeSort(array.Skip(mid_point).ToArray()));
        }

        private static int[] Merge(int[] array1, int[] array2)
        {
            int a = 0, b = 0;

            int[] merged = new int[array1.Length + array2.Length];

            for (int i = 0; i < array1.Length + array2.Length; i++)
            {

                if (b < array1.Length && a < array2.Length)
                    if (array1[a] > array2[b])
                        merged[i] = array2[b++];
                    else
                        merged[i] = array1[a++];
                else
                  if (b < array2.Length)
                    merged[i] = array2[b++];
                else
                    merged[i] = array1[a++];
            }
            return merged;
        }

        #endregion
    }
}

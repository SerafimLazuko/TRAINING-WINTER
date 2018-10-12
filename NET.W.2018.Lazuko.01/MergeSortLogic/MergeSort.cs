using System;
using System.Linq;

namespace LogicMerge
{
    /// <summary>
    /// The class contains methods for working with arrays.
    /// These methods allow you to perform merge sorting
    /// </summary>

    public class MergeSortClass
    {

        #region Public API

        /// <summary>
        /// allows sort the array by merge
        /// </summary>
        /// <param name="array">origin array</param>
        /// <returns>returns sorted array</returns>

        public static int[] MergeSort(int[] array)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array));
            }

            if (array.Length == 1)
            {
                return array;
            }

            int mid_point = array.Length / 2;
            return Merge(MergeSort(array.Take(mid_point).ToArray()), MergeSort(array.Skip(mid_point).ToArray()));
        }

        #endregion


        #region Private API
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
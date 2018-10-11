using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QSort
{
    /// <summary>
    /// class that describes the quick sort method
    /// </summary>
    public class QSort
    {

        #region Public API

        /// <summary>
        /// Function array accepting a null check
        /// </summary>
        /// <param name="array">The array.</param>
        /// <exception cref="System.ArgumentNullException">array</exception>
        public static void QuickSort(int[] array)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array));
            }

            QuickSort(array, 0, array.Length - 1);
        }

        #endregion

        #region Private API

        /// <summary>
        /// Quick sort function. Recursion function on incoming array
        /// </summary>
        /// <param name="array">The array.</param>
        /// <param name="left">The left.</param>
        /// <param name="right">The right.</param>
        private static void QuickSort(int[] array, int left, int right)
        {
            if (left < right)
            {
                int pivot = Partition(array, left, right);
                QuickSort(array, left, pivot - 1);
                QuickSort(array, pivot + 1, right);
            }

        }

        /// <summary>
        /// the function distributes the elements 
        /// of the array relative to pivot.
        /// </summary>
        /// <param name="array">The array.</param>
        /// <param name="left">The left.</param>
        /// <param name="right">The right.</param>
        /// <returns></returns>
        private static int Partition(int[] array, int left, int right)
        {
            {
                int pivot = array[right];

                int wall = left - 1;

                for (int current = left; current < right; current++)
                {
                    if (array[current] <= pivot)
                    {
                        wall++;
                        Swap(ref array[wall], ref array[current]);
                    }
                }

                Swap(ref array[wall + 1], ref array[right]);

                return wall + 1;
            }
        }

        /// <summary>
        /// swap
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="first">The first.</param>
        /// <param name="second">The second.</param>
        private static void Swap<T>(ref T first, ref T second)
        {
            T temp = first;
            first = second;
            second = temp;
        }
        #endregion
    }
}

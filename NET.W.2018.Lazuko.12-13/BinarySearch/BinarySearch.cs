using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearch
{
    /// <summary>
    /// Provides API for binary searching;
    /// </summary>
    public static class Search
    {
        /// <summary>
        /// generic method, returns index of position of value in input array;
        /// returns null, if position hasn't found;
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="array">The array.</param>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static int? BinarySearch<T>(T[] array, T value)
            => BinarySearch<T>(array, value, 0, array.Length, Comparer<T>.Default.Compare);
        
        public static int? BinarySearch<T>(T[] array, T value, Comparison<T> comparer)
            => BinarySearch<T>(array, value, 0, array.Length, comparer);

        public static int? BinarySearch<T>(T[] array, T value, IComparer<T> comparer) 
            => BinarySearch<T>(array, value, 0, array.Length, comparer.Compare);

        /// <summary>
        /// private method, performs a position of value search;
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="array">The array.</param>
        /// <param name="value">The value.</param>
        /// <param name="first">The first index.</param>
        /// <param name="last">The last index.</param>
        /// <param name="comparer">The comparer for perfoming a comparison.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">array is null</exception>
        /// <exception cref="InvalidOperationException">Array length must be >= 2!</exception>
        private static int? BinarySearch<T>(T[] array, T value, int first, int last, Comparison<T> comparer)
        {
            if (array == null)
                throw new ArgumentNullException(nameof(array));

            if (array.Length < 2)
                throw new InvalidOperationException("Array length must be >= 2!");

            return BinarySearchCore(first, last);

            int? BinarySearchCore(int left, int right)
            {
                int mid = (left + right) / 2;

                if (left - mid == 0) return null;

                int comparisonResult = comparer(value, array[mid]);

                if (comparisonResult == 0)
                    return mid;

                if (comparisonResult < 0)
                    return BinarySearchCore(left, mid);
                else
                    return BinarySearchCore(mid + 1, right);
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace FilterDigitLogic
{

    /// <summary>
    /// Filters the input list according to the incoming rule
    /// </summary>
    public static class Filter
    {

        #region Public API


        /// <summary>
        /// Public method. Checks incoming data, calls private PerformFilter
        /// </summary>
        /// <param name="list">The list.</param>
        /// <param name="digit">The digit.</param>
        /// <exception cref="System.ArgumentNullException">list</exception>
        /// <exception cref="System.ArgumentException">digit</exception>
        /// <exception cref="System.Exception">list</exception>
        public static void FilterDigit(List<int> list, int digit)
        {
            if(list == null)
            {
                throw new ArgumentNullException(nameof(list));
            }

            if (digit < 0)
            {
                throw new ArgumentException(nameof(digit));
            }

            if (list.Count == 0)
            {
                throw new Exception($"{nameof(list)} is empty!");
            }

            PerformFilter(list, digit);

        }

        #endregion


        #region Private API


        /// <summary>
        /// Removes inappropriate list items
        /// </summary>
        /// <param name="list">The list.</param>
        /// <param name="digit">The digit.</param>
        private static void PerformFilter(List<int> list, int digit)
        {
            for (int i = 0; i < list.Count; i++)
            {
                
                if (!Checker(list[i], digit))
                {
                    list.Remove(list[i]);
                    i--;
                }
            }
        }


        /// <summary>
        /// Checks the current list item for a given digit
        /// </summary>
        /// <param name="number">The number.</param>
        /// <param name="digit">The digit.</param>
        /// <returns></returns>
        private static bool Checker(int number, int digit)
        {
            string stringFormat = number.ToString();

            Regex regex = new Regex(@"" + digit + "");

            return regex.IsMatch(stringFormat);
        }

        #endregion
    }
    
}

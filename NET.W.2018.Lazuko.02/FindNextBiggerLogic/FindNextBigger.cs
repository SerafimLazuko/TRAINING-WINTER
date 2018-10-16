using System;
using System.Linq;

namespace FindNextBiggerNumberNamespace
{

    /// <summary>
    /// Class containing methods for finding next bigger number 
    /// </summary>
    public static class FindNextBigger
    {

        #region Public API   


        /// <summary>
        ///  Public function. Gets number, returns bigger.
        /// </summary>
        /// <param name="number">The number.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">number</exception>
        public static int FindNextBiggerNumber(int number)
        {

            if (number <= 0)
            {
                throw new ArgumentException(nameof(number));
            }

            return Finder(number);

        }


        #endregion


        #region Private API


        /// <summary>
        /// Main function. Performs calculations. 
        /// </summary>
        /// <param name="number">The number.</param>
        /// <returns></returns>
        private static int Finder(int number)
        {
            int resultNumber = -1;

            int[] arrayOfDigits = NumberToArray(number);

            int[] currentNumber = new int[arrayOfDigits.Length];

            for (int i = 0; i < currentNumber.Length; i++)
            {
                currentNumber[i] = arrayOfDigits[i];
            }


            for (int i = arrayOfDigits.Length - 1; i > 0; i--)
            {

                Swap(ref currentNumber[i], ref currentNumber[i - 1]);


                if (ArrayToNumber(currentNumber) > ArrayToNumber(arrayOfDigits))
                {
                    Sort(currentNumber, i);
                    return ArrayToNumber(currentNumber);
                }

                Swap(ref currentNumber[i - 1], ref currentNumber[i]);

            }

            return resultNumber;
        }


        /// <summary>
        /// Converts array to number.
        /// </summary>
        /// <param name="array">The array.</param>
        /// <returns></returns>
        private static int ArrayToNumber(int[] array)
        {
            int number = 0;

            for (int i = 0; i < array.Length; i++)
            {
                number += array[i] * Convert.ToInt32(Math.Pow(10, array.Length - i - 1));
            }

            return number;
        }


        /// <summary>
        /// Converts number to array.
        /// </summary>
        /// <param name="number">The number.</param>
        /// <returns></returns>
        private static int[] NumberToArray(int number)
        {

            string stringOfDigits = number.ToString();

            int[] arrayOfDigits = new int[stringOfDigits.Length];

            for (int i = 0; i < stringOfDigits.Length; ++i)
            {
                arrayOfDigits[i] = Int32.Parse(Convert.ToString(stringOfDigits[i]));
            }

            return arrayOfDigits;
        }


        /// <summary>
        /// Sorts array from position to the end ascending 
        /// </summary>
        /// <param name="array">The array.</param>
        /// <param name="pos">The position.</param>
        private static void Sort(int[] array, int pos)
        {
            for (int i = pos; i < array.Length; i++)
            {
                for (int j = pos; j < array.Length; j++)
                {
                    if (array[i] <= array[j])
                    {
                        Swap(ref array[i], ref array[j]);
                    }
                }
            }
        }


        /// <summary>
        /// Performs a swap
        /// </summary>
        /// <param name="a">a.</param>
        /// <param name="b">The b.</param>
        private static void Swap(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }


        #endregion
    }
}
using System;

namespace InsertNumberNamespace
{

    /// <summary>
    /// Class implements the InsertNumber algorithm
    /// </summary>
    public class Insert
    {

        #region Public API


        /// <summary>
        /// Public method, checks incoming parameters, call private Insert
        /// </summary>
        /// <param name="numberSource">The number source.</param>
        /// <param name="numberIn">The number in.</param>
        /// <param name="posLeft">The position left.</param>
        /// <param name="posRight">The position right.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentException"></exception>
        public static int InsertNumber(int numberSource, int numberIn, int posLeft, int posRight)
        {
            if (numberSource <= 0 || numberIn <= 0 || posLeft < 0 || posRight < 0 || posLeft > 31 || posRight > 31) 
            {
                throw new ArgumentException();
            }

            return InsertIn(numberSource, numberIn, posLeft, posRight);

        }


        #endregion


        #region Private API


        /// <summary>
        /// Main function, executes InsertNumber algorithm,
        /// insert binary format InNumber into SourceNumber
        /// from i to j byte
        /// </summary>
        /// <param name="numberSource">The number source.</param>
        /// <param name="numberIn">The number in.</param>
        /// <param name="posLeft">The position left.</param>
        /// <param name="posRight">The position right.</param>
        /// <returns></returns>
        private static int InsertIn(int numberSource, int numberIn, int posLeft, int posRight)
        {
            
            int[] binarySource = DecimalToBinary(numberSource);
            int[] binaryIn = DecimalToBinary(numberIn);

            for(int i = binarySource.Length - 1 - posLeft, j = binaryIn.Length - 1 ; i >= binarySource.Length - 1  - posRight; i-- , j--)
            {
                binarySource[i] = binaryIn[j];
            }

            int result = BinaryToDecimal(binarySource);

            return result;
        }

        /// <summary>
        /// Converts number to binary form
        /// </summary>
        /// <param name="number">The number.</param>
        /// <returns></returns>
        private static int[] DecimalToBinary(int number)
        {
            int[] result = new int[32];

            for(int i = result.Length - 1; number > 0; i--)
            {
                result[i] = number % 2;
                number /= 2;
            }
            return result;
        }

        /// <summary>
        /// Converts binary number to decimal
        /// </summary>
        /// <param name="binarySource">The binary source.</param>
        /// <returns></returns>
        private static int BinaryToDecimal(int[] binarySource)
        {
            int result = 0;
            
            int _base = 1;

            for (int i = binarySource.Length-1; i >= 0; i--)
            {
                result += binarySource[i] * _base;
                
                _base *= 2;
            }

            return result;
        }


        #endregion
    }
}

using System;

namespace FibbonacciSequence
{
    /// <summary>
    /// Provides API for creating  
    /// </summary>
    public static class FSGenerator
    {
        /// <summary>
        /// Generates Fibbonacci numbers
        /// </summary>
        private static int[] Generate(int numberElements)
        {
            if (numberElements < 1)
                throw new ArgumentException("Number of Elements must be > 1");

            int[] sequence = new int[numberElements];

            sequence[0] = 0;
            sequence[1] = 1;

            if (numberElements > 2)
            {
                for (int i = 2; i < numberElements; i++)
                {
                    sequence[i] = GetCurrent(sequence, i);
                }
            }
            return sequence;
        }

        /// <summary>
        /// Gets the current number
        /// </summary>
        /// <param name="index">The index.</param>
        /// <returns></returns>
        private static int GetCurrent(int[] array, int index)
        {
            return array[index - 2] + array[index - 1];
        }

    }
}
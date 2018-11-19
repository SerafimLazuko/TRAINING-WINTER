using System;
using System.Numerics;
using System.Collections.Generic;

namespace FibbonacciSequence
{
    /// <summary>
    /// Provides API for creating  
    /// </summary>
    public class FSGenerator
    {
        /// <summary>
        /// Generates Fibbonacci numbers
        /// </summary>
        public static IEnumerable<BigInteger> Generate(int numberElements)
        {
            if (numberElements < 1)
                throw new ArgumentException("Number of Elements must be > 1");

            yield return 0;
            yield return 1;

            BigInteger current = 1;
            BigInteger currentNext = 1;

            while (numberElements > 2)
            {
                yield return current;

                BigInteger temp = current;

                current = currentNext + current;

                currentNext = temp;

                numberElements--;
            }
        }
        
    }
}
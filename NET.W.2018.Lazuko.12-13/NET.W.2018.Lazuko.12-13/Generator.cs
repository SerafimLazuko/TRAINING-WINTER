using System;
using System.Collections;

namespace FibbonacciSequence
{
    /// <summary>
    /// Provides API for creating  
    /// </summary>
    public class FSGenerator
    {
        #region Fields & Prop

        private int[] sequence;

        public int[] Sequence
        {
            get => sequence;

            private set
            {
                if (value.Length >= 2)
                {
                    sequence = value;
                }
                else throw new ArgumentException("Can't creates Sequence!");
            }
        }

        #endregion

        /// <summary>
        /// Initializes a new instance by Generate method.
        /// </summary>
        /// <param name="numberElements">The number elements.</param>
        public FSGenerator(int numberElements)
        {
            Sequence = new int[numberElements];
            Generate();
        }

        /// <summary>
        /// Generates Fibbonacci numbers
        /// </summary>
        private void Generate()
        {
            Sequence[0] = 0;
            Sequence[1] = 1;

            for(int i = 2; i < sequence.Length; i++)
            {
                Sequence[i] = GetCurrent(i);
            }
        }

        /// <summary>
        /// Gets the current number
        /// </summary>
        /// <param name="index">The index.</param>
        /// <returns></returns>
        private int GetCurrent(int index)
        {
            return Sequence[index - 2] + Sequence[index - 1];
        }

        /// <summary>
        /// Allows you to iterate over the collection
        /// </summary>
        /// <returns></returns>
        private IEnumerator GetEnumerator()
        {
            foreach (int c in Sequence)
            {
                yield return c;
            }
        }
    }
}

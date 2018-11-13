using System;
using System.Collections;

namespace FibbonacciSequence
{
    /// <summary>
    /// Provides API for creating  
    /// </summary>
    public class FSGenerator
    {
        private int[] sequence;

        public int[] Sequence
        {
            get => sequence;

            set
            {
                if (value.Length >= 2)
                {
                    sequence = value;
                }
                else throw new ArgumentException("Can't creates Sequence!");
            }
        }
        
        public FSGenerator(int numberElements)
        {
            Sequence = new int[numberElements];
            Generate();
        }

        private void Generate()
        {
            Sequence[0] = 0;
            Sequence[1] = 1;

            for(int i = 2; i < sequence.Length; i++)
            {
                Sequence[i] = GetCurrent(i);
            }
        }

        private int GetCurrent(int index)
        {
            return Sequence[index - 2] + Sequence[index - 1];
        }

        //private IEnumerator GetEnumerator()
        //{
        //    foreach(int c in Sequence)
        //    {
        //        yield return c;
        //    }
        //}
    }
}

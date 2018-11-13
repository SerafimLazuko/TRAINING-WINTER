using System;
using System.Diagnostics;

namespace GCDEuclideanAlgorithm
{ 
    /// <summary>
    /// Provides API for finding GCD
    /// </summary>
    public static class GCDFinder
    {
        #region Public Euclidean Algorithm overloads 

        public static int EuclideanAlgorithm(params int[] numbers )
        {
            if (numbers == null) throw new ArgumentNullException(nameof(numbers));

            if (numbers.Length <= 1) throw new ArgumentException(nameof(numbers));

            Stopwatch timeSpan = new Stopwatch();

            timeSpan.Start();

            int result = 0;

            for(int i = 0; i < numbers.Length - 1; i++)
            {
                result = FindGCD(result, numbers[i]);
            }

            timeSpan.Stop();

            var elapsedTime = timeSpan.Elapsed;

            return result;
        }

        public static int EuclideanAlgorithm(int firstNumber, int secondNumber)
        {
            Stopwatch timeSpan = new Stopwatch();

            timeSpan.Start();

            int result = FindGCD(firstNumber, secondNumber);

            var elapsedTime = timeSpan.Elapsed;

            return result;
        }

        public static int EuclideanAlgorithm(int firstNumber, int secondNumber, int thirdNumber)
        {
            Stopwatch timeSpan = new Stopwatch();

            timeSpan.Start();
            
            int result = FindGCD(FindGCD(firstNumber, secondNumber), thirdNumber);

            var elapsedTime = timeSpan.Elapsed;

            return result;
        }

        #endregion

        #region Public Binary Euclidean Algorithm overloads

        public static int BinaryEuclideanAlgorithm(params int[] numbers)
        {

            if (numbers == null) throw new ArgumentNullException(nameof(numbers));

            if (numbers.Length <= 1) throw new ArgumentException(nameof(numbers));
            
            Stopwatch timeSpan = new Stopwatch();

            timeSpan.Start();

            int result = 0;

            for (int i = 0; i < numbers.Length ; i++)
            {
                result = FindGCD(result, numbers[i]);
            }

            var elapsedTime = timeSpan.Elapsed;

            return result;
        }

        public static int BinaryEuclideanAlgorithm(int firstNumber, int secondNumber)
        {
            Stopwatch timeSpan = new Stopwatch();

            timeSpan.Start();

            int result = BinaryFindGCD(firstNumber, secondNumber);

            var elapsedTime = timeSpan.Elapsed;

            return result;
        }

        public static int BinaryEuclideanAlgorithm(int firstNumber, int secondNumber, int thirdNumber)
        {
            Stopwatch timeSpan = new Stopwatch();

            timeSpan.Start();
            
            int result = BinaryFindGCD(BinaryFindGCD(firstNumber, secondNumber), thirdNumber);

            var elapsedTime = timeSpan.Elapsed;

            return result;
        }

        #endregion

        #region Private API
        
        private static int BinaryFindGCD(int firstNumber, int secondNumber)
        {
         
            if (firstNumber == 0 && secondNumber == 0)
                throw new ArgumentException($"{firstNumber} and {secondNumber} = 0, invalid arguments");

            if (firstNumber == 0) return secondNumber;
            if (secondNumber == 0) return firstNumber;

            NumbersRefactor(ref firstNumber,ref secondNumber);

            int k = 1;

            while (firstNumber != 0 && secondNumber != 0)
            {
                while (firstNumber % 2 != 1 && secondNumber % 2 != 1)
                {
                    firstNumber /= 2;
                    secondNumber /= 2;
                    k *= 2;
                }

                while (firstNumber % 2 != 1) firstNumber /= 2;
                while (secondNumber % 2 != 1) secondNumber /= 2;


                if (firstNumber >= secondNumber)

                    firstNumber = firstNumber - secondNumber;
                else
                    secondNumber = secondNumber - firstNumber;

            }

            return secondNumber * k;
        }

        private static int FindGCD(int firstNumber, int secondNumber)
        {

            if (firstNumber == 0 && secondNumber == 0)
                throw new ArgumentException($"{firstNumber} and {secondNumber} = 0, invalid arguments");

            if (firstNumber == 0) return secondNumber;
            if (secondNumber == 0) return firstNumber;

            NumbersRefactor(ref firstNumber, ref secondNumber);

            int Finder(int big, int small)
            {
                int rest = -1;
                
                while (big >= small)
                {
                    big = big - small;
                    rest = big;
                }

                if (rest == 0) return small;
                
                else
                {
                    big = small;
                    small = rest;

                    return Finder(big, small);
                }

            }

            return Finder(firstNumber, secondNumber);

        }
        
        private static void NumbersRefactor(ref int firstNumber, ref int secondNumber)
        {
            if (firstNumber < 0) firstNumber *= -1;
            if (secondNumber < 0) secondNumber *= -1;

            if (firstNumber < secondNumber)
            {
                int temp = firstNumber;
                firstNumber = secondNumber;
                secondNumber = temp;
            }
        }

        #endregion
    }
}

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

        /// <summary>
        /// Finds GCD of two numbers;
        /// </summary>
        /// <param name="firstNumber">The first number.</param>
        /// <param name="secondNumber">The second number.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentException"></exception>
        public static int EuclideanAlgorithm(int firstNumber, int secondNumber)
        {
            Stopwatch timeSpan = new Stopwatch();

            timeSpan.Start();

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

            var elapsedTime = timeSpan.Elapsed;

            return Finder(firstNumber, secondNumber);
        }

        /// <summary>
        /// Finds GCD of three numbers, using method for two numbers
        /// </summary>
        /// <param name="firstNumber">The first number.</param>
        /// <param name="secondNumber">The second number.</param>
        /// <param name="thirdNumber">The third number.</param>
        /// <returns></returns>
        public static int EuclideanAlgorithm(int firstNumber, int secondNumber, int thirdNumber) => FindGCD(EuclideanAlgorithm, firstNumber, secondNumber, thirdNumber);

        /// <summary>
        /// Finds GCD for any amount of numbers
        /// </summary>
        /// <param name="numbers">The numbers.</param>
        /// <returns></returns>
        public static int EuclideanAlgorithm(params int[] numbers) => FindGCD(EuclideanAlgorithm, numbers);

        #endregion

        #region Public Binary Euclidean Algorithm overloads       

        /// <summary>
        /// Finds GCD of two numbers, Binary Algorithm;
        /// </summary>
        /// <param name="firstNumber">The first number.</param>
        /// <param name="secondNumber">The second number.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentException"></exception>
        public static int BinaryEuclideanAlgorithm(int firstNumber, int secondNumber)
        {
            Stopwatch timeSpan = new Stopwatch();

            timeSpan.Start();

            if (firstNumber == 0 && secondNumber == 0)
                throw new ArgumentException($"{firstNumber} and {secondNumber} = 0, invalid arguments");

            if (firstNumber == 0) return secondNumber;
            if (secondNumber == 0) return firstNumber;

            NumbersRefactor(ref firstNumber, ref secondNumber);

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

            var elapsedTime = timeSpan.Elapsed;

            return secondNumber * k;
        }

        /// <summary>
        /// Finds GCD of three numbers, using method for two numbers,  Binary Algorithm;
        /// </summary>
        /// <param name="firstNumber">The first number.</param>
        /// <param name="secondNumber">The second number.</param>
        /// <param name="thirdNumber">The third number.</param>
        /// <returns></returns>
        public static int BinaryEuclideanAlgorithm(int firstNumber, int secondNumber, int thirdNumber) => FindGCD(BinaryEuclideanAlgorithm, firstNumber, secondNumber, thirdNumber);

        /// <summary>
        /// Finds GCD for any amount of numbers, Binary Euclidean Algorithm;
        /// </summary>
        /// <param name="numbers">The numbers.</param>
        /// <returns></returns>
        public static int BinaryEuclideanAlgorithm(params int[] numbers) => FindGCD(BinaryEuclideanAlgorithm, numbers);

        #endregion

        #region Private API

        /// <summary>
        /// Finds the GCD, implementation of Func Delegate
        /// </summary>
        /// <param name="gcd">The GCD.</param>
        /// <param name="numbers">The numbers.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">numbers</exception>
        /// <exception cref="System.ArgumentException">numbers</exception>
        private static int FindGCD(Func<int, int, int> gcd,  params int[] numbers)
        {
            if (numbers == null) throw new ArgumentNullException(nameof(numbers));

            if (numbers.Length <= 1) throw new ArgumentException(nameof(numbers));

            int result = 0;

            for (int i = 0; i < numbers.Length; i++)
            {
                result = gcd(result, numbers[i]);
            }
            return result;
        }

        /// <summary>
        /// Finds the GCD for three numbers, implementation of Func Delegate;
        /// </summary>
        /// <param name="gcd">The GCD.</param>
        /// <param name="firstNumber">The first number.</param>
        /// <param name="secondNumber">The second number.</param>
        /// <param name="thirdNumber">The third number.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">gcd</exception>
        /// <exception cref="System.ArgumentException"></exception>
        private static int FindGCD(Func<int,int,int> gcd, int firstNumber, int secondNumber, int thirdNumber)
        {
            if (gcd == null)
            {
                throw new ArgumentNullException(nameof(gcd));
            }
            if (firstNumber == 0 && secondNumber == 0 && thirdNumber == 0)
            {
                throw new ArgumentException();
            }

            return gcd(gcd(firstNumber, secondNumber), thirdNumber);
        }

        /// <summary>
        /// Supporting method, refacts numbers, if they are negative;
        /// </summary>
        /// <param name="firstNumber">The first number.</param>
        /// <param name="secondNumber">The second number.</param>
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
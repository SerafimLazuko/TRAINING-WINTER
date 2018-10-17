using System;

namespace GCDEuclideanAlgorithm
{
    public static class GCDFinder
    {
        
        #region Public Euclidean Algorithm overloads 

        public static int EuclideanAlgorithm(params int[] numbers )
        {
            DateTime inTime = DateTime.Now;

            if (numbers.Length <= 1) throw new ArgumentException(nameof(numbers));
            
            if (numbers == null) throw new ArgumentNullException(nameof(numbers));
            

            int result = 0;

            for(int i = 0; i < numbers.Length - 1; i++)
            {
                result = FindGCD(result, numbers[i]);
            }

            DateTime outTime = DateTime.Now;

            TimeSpan requiredTime = outTime.Subtract(inTime);

            return result;
        }

        public static int EuclideanAlgorithm(int firstNumber, int secondNumber)
        {
            DateTime inTime = DateTime.Now;

            int result = FindGCD(firstNumber, secondNumber);

            DateTime outTime = DateTime.Now;

            TimeSpan requiredTime = outTime.Subtract(inTime);

            return result;
        }

        public static int EuclideanAlgorithm(int firstNumber, int secondNumber, int thirdNumber)
        {
            DateTime inTime = DateTime.Now;

            int result = FindGCD(FindGCD(firstNumber, secondNumber), thirdNumber);

            DateTime outTime = DateTime.Now;

            TimeSpan requiredTime = outTime.Subtract(inTime);

            return result;
        }

        #endregion

        #region Public Binary Euclidean Algorithm overloads

        public static int BinaryEuclideanAlgorithm(params int[] numbers)
        {
            DateTime inTime = DateTime.Now;

            if (numbers.Length <= 1) throw new ArgumentException(nameof(numbers));

            if (numbers == null) throw new ArgumentNullException(nameof(numbers));


            int result = 0;

            for (int i = 0; i < numbers.Length ; i++)
            {
                result = FindGCD(result, numbers[i]);
            }

            DateTime outTime = DateTime.Now;

            TimeSpan requiredTime = outTime.Subtract(inTime);

            return result;
        }

        public static int BinaryEuclideanAlgorithm(int firstNumber, int secondNumber)
        {
            DateTime inTime = DateTime.Now;

            int result = BinaryFindGCD(firstNumber, secondNumber);

            DateTime outTime = DateTime.Now;

            TimeSpan requiredTime = outTime.Subtract(inTime);

            return result;
        }

        public static int BinaryEuclideanAlgorithm(int firstNumber, int secondNumber, int thirdNumber)
        {
            DateTime inTime = DateTime.Now;

            int result = BinaryFindGCD(BinaryFindGCD(firstNumber, secondNumber), thirdNumber);

            DateTime outTime = DateTime.Now;

            TimeSpan requiredTime = outTime.Subtract(inTime);

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

            NumbersRefactor(firstNumber, secondNumber, out firstNumber, out secondNumber);

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

            if (firstNumber == 0) return secondNumber;
            if (secondNumber == 0) return firstNumber;

            NumbersRefactor(firstNumber, secondNumber, out firstNumber, out secondNumber);

            int Finder(int big, int small)
            {
                int rest = -1;
                
                while (big >= small)
                {
                    big = big - small;
                    rest = big;
                }

                if (rest == 0)
                {
                    return small;
                }

                else
                {
                    big = small;
                    small = rest;

                    return Finder(big, small);
                }

            }

            return Finder(firstNumber, secondNumber);

        }
        
        private static void NumbersRefactor(int inFirst, int inSecond ,out int firstNumber, out int secondNumber)
        {
            if (inFirst < 0) inFirst *= -1;
            if (inSecond < 0) inSecond *= -1;

            if (inFirst < inSecond)
            {
                firstNumber = inSecond;
                secondNumber = inFirst;
                return;
            }
            else
            {
                firstNumber = inFirst;
                secondNumber = inSecond;
                return;
            }

        }
        
        #endregion

    }
}

using System;

namespace DoubleExtensionLogic
{
    public static class DoubleExtension
    {
        public static string DoubleToBinaryString(double number)
        {
            return DoubleToString(number);
        }

        private static string DoubleToString(double number)
        {
            int sign = 0;
            int exponenta = 0;

            if (number < 0) { sign = 1; number *= -1; }

            int[] numberBinaryForm = DoubleToBinary(number, ref exponenta);

            exponenta--;
            
            Tuple<int, int, int[]> normalizedFormTuple = new Tuple<int, int, int[]>(sign, exponenta, numberBinaryForm);

            return string.Join("", BinaryToIEEEFormat(normalizedFormTuple));
        }
        
        private static int[] DoubleToBinary(double number, ref int exponenta)
        {
            int[] binaryArray = new int[53];

            double numberFrPart = number % 1;
            double numberIntPart = number - numberFrPart;
            
            for (int i = 0; i < binaryArray.Length; i++)
            {
                if (numberIntPart > 1)
                {
                    binaryArray[i] = (int)(number % 2);
                    numberIntPart /= 2;
                    exponenta++;
                }
                else
                {
                    binaryArray[i] = (int)(numberFrPart * 2) % 10;

                    numberFrPart *= 2.0;

                    while (numberFrPart >= 1) numberFrPart -= 1.0;
                }
            }

            return binaryArray;
        }

        private static int[] OrderToBinary(int number)
        {
            int[] array = new int[11];

            for (int i = array.Length - 1; i >= 0; i--)
            {
                array[i] = number % 2;
                number = number / 2;
            }
            return array;
        }

        private static int[] BinaryToIEEEFormat(Tuple<int, int, int[]> normalizedForm)
        {
            int sign = normalizedForm.Item1;

            int[] order = OrderToBinary(normalizedForm.Item2 + 1023);

            int[] mantissa = normalizedForm.Item3;


            int[] result = new int[64];

            for (int i = 0; i < result.Length; i++)
            {
                if (i == 0)
                    result[i] = sign;

                if (i > 0 && i <= 11)
                    result[i] = order[i - 1];

                if (i > 11)
                    result[i] = mantissa[i - 11];
            }

            return result;
        }

    }
}

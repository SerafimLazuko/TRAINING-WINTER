using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringExtension
{
    public static class StringExtension
    {
        public static string DoubleToStringConventer(double number)
        {
            return DoubleToString(number);
        }

        private static string DoubleToString(double number)
        {
            int sign = 0;
            int exponenta = 0;

            DoubleToNormalizedForm(ref number, ref sign, ref exponenta);

            int[] normalizedInBinaryForm = DoubleNormilizedToBinary(number);

            Tuple<int ,int[], int> normalizedFormTuple = new Tuple<int, int[], int>(sign, normalizedInBinaryForm, exponenta);
            
            return string.Join("", BinaryToIEEEFormat(normalizedFormTuple)); 
        }

        private static void DoubleToNormalizedForm(ref double number, ref int sign, ref int exponenta)
        {
            if (number < 0)
            {
                number *= -1;
                sign = 1;
            }

            if (number < 1.0)
                while (number < 1)
                {
                    number *= 10;
                    exponenta -= 1;
                }
            else
                while (number >= 10)
                {
                    number /= 10;
                    exponenta += 1;
                }

        }

        private static int[] BinaryToIEEEFormat(Tuple<int, int[], int> normalizedForm)
        {

            int[] order = IntToBinary(normalizedForm.Item3 + 1023);

            int[] mantissa = normalizedForm.Item2;

            int sign = normalizedForm.Item1;


            int[] result = new int[64];

            for (int i = 0; i < result.Length; i++)
            {
                if (i == 0)
                    result[i] = sign;

                if (i > 0 && i <= 11)
                    result[i] = order[i - 1];

                if (i > 11)
                    result[i] = mantissa[i - 12];
            }
            
            return result;
        }

        private static int[] DoubleNormilizedToBinary(double number)
        {
            int[] binaryArray = new int[52];

            binaryArray[0] = 1;

            number -= (int) number % 10;

            for(int i = 1; i < binaryArray.Length; i++)
            {
                binaryArray[i] = (int) (2 * number) % 10;
                number *= 2;

                if (number >= 1) number -= (int) number % 10;
            }
            return binaryArray;
        }

        private static int[] IntToBinary(int number)
        {
            int[] binaryArray = new int[11];

            for(int i = 0; i < binaryArray.Length; i++)
            {
                binaryArray[i] = number % 2;
                number = number / 2;
            }

            return binaryArray;
        }
        
    }
}

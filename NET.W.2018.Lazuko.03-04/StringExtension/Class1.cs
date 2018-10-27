using System.Text;
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;

namespace DoubleExtensionLogic
{
    /// <summary>
    /// DoubleExtension class
    /// </summary>
    [StructLayout(LayoutKind.Explicit)]
    public class Number
    {
        [FieldOffset(0)]
        private double doubleNumber;

        [FieldOffset(0)]
        private readonly long intNumber;
        
        public double DoubleNumber { get => doubleNumber; set => doubleNumber = value; }

        public long IntNumber { get => intNumber; }

        public Number(double number)
        {
            DoubleNumber = number;
        }

        /// <summary>
        /// Represent Doubles to string IEEE754 format.
        /// </summary>
        /// <param name="number">The number.</param>
        /// <returns></returns>
        public string DoubleToIEEE754Format(Number number)
        {
            string result = StringRepresentation(number.intNumber).ToString();

            char[] charArray = result.ToCharArray();

            Array.Reverse(charArray);

            return new string(charArray);

        }

        /// <summary>
        /// Private method
        /// </summary>
        /// <param name="longNumber">The long number.</param>
        /// <returns></returns>
        private StringBuilder StringRepresentation(long longNumber )
        {
            StringBuilder result = new StringBuilder();

            int i = 0;

            for(int j = 0; j < 64; j++)
            { 
                result.Append((longNumber >> i++) & 1);
            } 

            return result;
        }
    }
}

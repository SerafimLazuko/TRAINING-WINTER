using System;
using System.Collections.Generic;

namespace PolynomialLogic
{
    public sealed class Polynomial 
    {
        readonly int[] coefficients;

        public int[] Coefficiants
        {
            get => coefficients;
            set => Array.Copy(value, coefficients, value.Length);
        }

        public Polynomial() : this(null) { }

        public Polynomial(int[] coefficients)
        {
            this.coefficients = coefficients;
        }

        public double GetValue(double x)
        {
            double result = 0;

            for (int i = coefficients.Length - 2; i <= 0; i--)
            {
                result += coefficients[i] * x;
                x *= x;
            }
            
            return result;
        }

        public static Polynomial operator +(Polynomial polynom1, Polynomial polynom2)
        {
            if (polynom1 == null || polynom2 == null)
                throw new ArgumentNullException();

            if (polynom1.Coefficiants.Length != polynom2.Coefficiants.Length)
            {
                throw new ArgumentException($"{polynom1} length is not equal to {polynom2} length");
            }

            int[] result = new int[polynom1.Coefficiants.Length];

            for (int i = 0; i < polynom1.Coefficiants.Length; i++)
            {
                result[i] = polynom1.Coefficiants[i] + polynom2.Coefficiants[i];
            }

            return new Polynomial(result);
        }

        public static Polynomial operator -(Polynomial polynom1, Polynomial polynom2)
        {
            if (polynom1 == null || polynom2 == null)
                throw new ArgumentNullException();

            if (polynom1.Coefficiants.Length != polynom2.Coefficiants.Length)
            {
                throw new ArgumentException($"{polynom1} length is not equal to {polynom2} length");
            }

            int[] result = new int[polynom1.Coefficiants.Length];

            for (int i = 0; i < polynom1.Coefficiants.Length; i++)
            {
                result[i] = polynom1.Coefficiants[i] - polynom2.Coefficiants[i];
            }

            return new Polynomial(result);
        }

        public static Polynomial operator *(Polynomial polynom1, Polynomial polynom2)
        {
            if (polynom1 == null || polynom2 == null)
                throw new ArgumentNullException();

            int[] result = new int[polynom1.Coefficiants.Length + polynom1.Coefficiants.Length - 1];

            for (int i = 0; i < polynom1.Coefficiants.Length; i++)
            {
                for (int j = 0; j < polynom2.Coefficiants.Length; j++)
                {
                    result[i + j] += polynom1.Coefficiants[i] * polynom2.Coefficiants[j];
                }
            }

            return new Polynomial(result);
        }

        public static Polynomial operator *(Polynomial polynom, int number)
        {
            if (polynom == null)
                throw new ArgumentNullException();

            int[] result = new int[polynom.Coefficiants.Length];

            for (int i = 0; i < polynom.Coefficiants.Length; i++)
            {
                result[i] = polynom.Coefficiants[i] * number;
            }

            return new Polynomial(result);
        }

        public static Polynomial operator /(Polynomial polynom, int number)
        {
            if (polynom == null)
                throw new ArgumentNullException();

            if (number == 0)
                throw new ArgumentException($"{number} must be > 0");

            int[] result = new int[polynom.Coefficiants.Length];

            for (int i = 0; i < polynom.Coefficiants.Length; i++)
            {
                result[i] = polynom.Coefficiants[i] / number;
            }

            return new Polynomial(result);
        }

        public static bool operator ==(Polynomial polynom1, Polynomial polynom2)
        {
            if (polynom1 == null || polynom2 == null)
                throw new ArgumentNullException();

            for (int i = 0; i < polynom1.Coefficiants.Length; i++)
            {
                if (polynom1.Coefficiants[i] != polynom2.Coefficiants[i]) return false;
            }
            return true;
        }

        public static bool operator !=(Polynomial polynom1, Polynomial polynom2)
        {
            if (polynom1 == null || polynom2 == null)
                throw new ArgumentNullException();

            return !polynom1.Equals(polynom2);
        }

        public override string ToString()
        {
            string[] stringFormat = new string[Coefficiants.Length];

            int degree = Coefficiants.Length - 1;
            
            for (int i = 0; i < Coefficiants.Length; i++)
            {
                stringFormat[i] = Coefficiants[i].ToString() + $"*x^{degree--}";
            }

            return string.Join($"+", stringFormat, 0, stringFormat.Length);
        }
        
        public override bool Equals(Object obj)
        {
            if (obj == null)
            {
                return false;
            }

            Polynomial polynomial = obj as Polynomial;

            if (polynomial == null)
            {
                return false;
            }
            
            if (coefficients.Length != polynomial.Coefficiants.Length)
            {
                return false;
            }

            for (int i = 0; i < coefficients.Length; ++i)
            {
                if (coefficients[i] != polynomial.Coefficiants[i])
                {
                    return false;
                }
            }

            return true;
        }

        public override int GetHashCode()
        {
            return 1112971371 + EqualityComparer<int[]>.Default.GetHashCode(coefficients);
        }
    }
} 

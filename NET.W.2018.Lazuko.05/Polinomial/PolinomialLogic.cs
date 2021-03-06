﻿using System;
using System.Collections.Generic;

namespace PolynomialLogic
{
    /// <summary>
    /// Class providing API for work with polynomials
    /// </summary>
    public sealed class Polynomial 
    {
        #region Fields & Properties

        readonly double[] coefficients;

        public double[] Coefficiants
        {
            get => coefficients;
            set => Array.Copy(value, coefficients, value.Length);
        }

        #endregion

        /// <summary>
        /// Constructor
        /// Initializes a new instance of the <see cref="Polynomial"/> class.
        /// </summary>
        /// <param name="coefficients">The coefficients.</param>
        public Polynomial(double[] coefficients)
        {
            this.coefficients = coefficients;
        }

        #region API and Operations

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

            double[] result = new double[polynom1.Coefficiants.Length];

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

            double[] result = new double[polynom1.Coefficiants.Length];

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

            double[] result = new double[polynom1.Coefficiants.Length + polynom1.Coefficiants.Length - 1];

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

            double[] result = new double[polynom.Coefficiants.Length];

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

            double[] result = new double[polynom.Coefficiants.Length];

            for (int i = 0; i < polynom.Coefficiants.Length; i++)
            {
                result[i] = polynom.Coefficiants[i] / number;
            }

            return new Polynomial(result);
        }

        public static bool operator ==(Polynomial polynom1, Polynomial polynom2)
        {
            if (polynom1 is null || polynom2 is null) 
                throw new ArgumentNullException();

            for (int i = 0; i < polynom1.Coefficiants.Length; i++)
            {
                if (polynom1.Coefficiants[i] != polynom2.Coefficiants[i]) return false;
            }
            return true;
        }

        public static bool operator !=(Polynomial polynom1, Polynomial polynom2)
        {
            if (polynom1 is null || polynom2 is null)
                throw new ArgumentNullException();

            return !polynom1.Equals(polynom2);
        }

        #endregion

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
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

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns>
        /// true if the specified object  is equal to the current object; otherwise, false.
        /// </returns>
        public override bool Equals(Object obj)
        {
            if (obj == null)
            {
                return false;
            }

            Polynomial polynomial = obj as Polynomial;

            if (polynomial is null) 
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

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table. 
        /// </returns>
        public override int GetHashCode()
        {
            return 1112971371 + EqualityComparer<double[]>.Default.GetHashCode(coefficients);
        }
    }
} 

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using static GCDEuclideanAlgorithm.GCDFinder;

namespace GCDTests
{
    [TestClass]
    public class UnitTests
    {
        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public int EuclideanAlgorithm_ReceivesNull_ThrowArgumentNullException()
        {
            int[] numbers = null;

            return EuclideanAlgorithm(numbers);
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public int BinaryEuclideanAlgorithm_ReceivesNull_ThrowArgumentNullException()
        {
            int[] numbers = null;

            return BinaryEuclideanAlgorithm(numbers);

        }
    }

    [TestFixture]
    public class NUnitTests
    {

        [TestCase(11, 33, 66, 0, 110, ExpectedResult = 11)]
        [TestCase(11, 33, 66, 99, 110, ExpectedResult = 11)]

        public int GCDEuclideanAlgorithm_ReceivesSetOfNumbers_ReturnsGCD(params int[] numbers)
        {
            return EuclideanAlgorithm(numbers);
        }


        [TestCase(1071, 462, ExpectedResult = 21)]
        [TestCase(113, 0, ExpectedResult = 113)]
        [TestCase(-21, 15, ExpectedResult = 3)]
        [TestCase(37, 13, ExpectedResult = 1)]

        public int GCDEuclideanAlgorithm_ReceiveTwoNumbers_ReturnsGCD(int first, int second)
        {
            return EuclideanAlgorithm(first, second);
        }



        [TestCase(11, 0, 0, ExpectedResult = 11)]
        [TestCase(11, 12, 13, ExpectedResult = 1)]
        [TestCase(11, 33, 66, ExpectedResult = 11)]

        public int GCDEuclideanAlgorithm_ReceiveThreeNumbers_ReturnsGCD(int first, int second, int third)
        {
            return EuclideanAlgorithm(first, second, third);
        }



        [TestCase(11, 33, 66, 0, 110, ExpectedResult = 11)]
        [TestCase(11, 33, 66, 99, 110, ExpectedResult = 11)]

        public int BinaryEuclideanAlgorithm_ReceivesSetOfNumbers_ReturnsGCD(params int[] numbers)
        {
            return BinaryEuclideanAlgorithm(numbers);
        }


        [TestCase(1071, 462, ExpectedResult = 21)]
        [TestCase(113, 0, ExpectedResult = 113)]
        [TestCase(-21, 15, ExpectedResult = 3)]
        [TestCase(37, 13, ExpectedResult = 1)]

        public int BinaryEuclideanAlgorithm_ReceiveTwoNumbers_ReturnsGCD(int first, int second)
        {
            return BinaryEuclideanAlgorithm(first, second);
        }



        [TestCase(11, 0, 0, ExpectedResult = 11)]
        [TestCase(11, 12, 13, ExpectedResult = 1)]
        [TestCase(11, 33, 66, ExpectedResult = 11)]

        public int BinaryEuclideanAlgorithm_ReceiveThreeNumbers_ReturnsGCD(int first, int second, int third)
        {
            return BinaryEuclideanAlgorithm(first, second, third);
        }

    }


   
}

using System;
using NUnit.Framework;
using static GCDEuclideanAlgorithm.GCDFinder;

namespace GCDTestsNUnit
{
    [TestFixture]
    public class NUnitTests
    {
        [Test]
        public void GCDEuclideanAlgorithm_ReceivesNull_ThrowsException()
        {
           Assert.Throws<ArgumentNullException>(() => EuclideanAlgorithm(null));
        }

        [Test]
        public void GCDEuclideanAlgorithm_ReceivesEmptyArray_ThrowsException()
        {
            int[] arr = new int[0];
            Assert.Throws<ArgumentException>(() => EuclideanAlgorithm(arr));
        }

        [Test]
        public void GCDEuclideanAlgorithm_ReceivesTwoElementsEqualsNull_ThrowsException()
        {
            Assert.Throws<ArgumentException>(() => EuclideanAlgorithm(0,0));
        }

        [Test]
        public void BinaryEuclideanAlgorithm_ReceivesNull_ThrowsException()
        {
            Assert.Throws<ArgumentNullException>(() => BinaryEuclideanAlgorithm(null));
        }


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

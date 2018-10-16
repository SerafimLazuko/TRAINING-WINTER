using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using static InsertNumberNamespace.Insert;

namespace InsertNumberTests
{
    [TestFixture]
    public class InsertTests
    {
        [TestCase(8, 15, 3, 8, ExpectedResult = 120)]
        [TestCase(15, 15, 0, 0, ExpectedResult = 15)]
        [TestCase(8, 15, 0, 0, ExpectedResult = 9)]

        public int InsertNumber_InsertBitesOfInNumberToSourceNumberFromIToJBit_ReturnResultOfInsert(int _source, int _in, int left, int right)
        {
            return (InsertNumber(_source, _in, left, right));
        }
    }
}

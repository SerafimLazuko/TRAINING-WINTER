using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace PolynomialLogic.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void EqualsTest_ChecksIfPolynom1EqualToPolynom2_ReturnBool()
        {
            Polynomial polinom1 = new Polynomial(new int[5] { 1, 2, 3, 4, 5 });
            Polynomial polinom2 = new Polynomial(new int[5] { 1, 2, 3, 4, 5 });

            bool expected = true;

            bool actual = polinom1.Equals(polinom2);

            Assert.AreEqual(expected, actual);
        }
    }
}

using System;
using System.Globalization;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BookLogicTests
{
    [TestClass]
    public class BookLogicTests
    {
        BookLogic.Book book = new BookLogic.Book("9-111-34505-1", "Lev Tolstoi", "Anna Karenina", "House", 1877, 864, 0);
        IFormatProvider formatProvider = CultureInfo.CurrentCulture;

        [TestMethod]
        public void ToString_ReceivesFormat_A_AndFormatProvider_ReturtStringRepresentation()
        {
            string expected = "Author: Lev Tolstoi, Title: Anna Karenina.";
            
            string actual = book.ToString("A", formatProvider);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ToString_ReceivesFormat_G_AndFormatProvider_ReturtStringRepresentation()
        {
            string expected = $"ISBN: 9-111-34505-1, Author: Lev Tolstoi, Title: Anna Karenina, Publishing House: House, Publishing Year: 1877, P: 864, Cost: 0."; 

            string actual = book.ToString("G", formatProvider);

            Assert.AreEqual(expected, actual);
        }
    }
}

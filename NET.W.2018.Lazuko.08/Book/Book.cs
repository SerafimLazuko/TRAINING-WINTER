using System;
using System.Text.RegularExpressions;

namespace BookLogic
{
    /// <summary>
    /// Class describing the state of the object "book"
    /// </summary>
    public class Book
    {
        #region Fields

        private string isbn;
        private string author;
        private string name;
        private string publishingHouse;
        private int publishingYear;
        private int pagesNumber;
        private int price;

        #endregion

        #region Propertyes

        public string ISBN
        {
            get => isbn;

            private set
            {
                string pattern = @"[0-9]{1}-[0-9]{3}-[0-9]{5}-[0-9]{1}";

                if (Regex.IsMatch(value, pattern))
                    isbn = value;

                else throw new Exception($"The expression {value} does not match the pattern");
            }

        }

        public string Author
        {
            get => author;

            private set
            {
                if (value != string.Empty)
                    author = value;

                else throw new ArgumentException(nameof(value));
            }
        }

        public string Name
        {
            get => name;

            private set
            {
                if (value != string.Empty)
                    name = value;

                else throw new ArgumentException(nameof(value));
            }
        }

        public string PublishingHouse
        {
            get => publishingHouse;

            private set
            {
                if (value != string.Empty)
                    publishingHouse = value;

                else throw new ArgumentException(nameof(value));
            }
        }

        public int PublishingYear
        {
            get => publishingYear;

            private set
            {
                if (value > 0 && value < 2019)
                    publishingYear = value;

                else throw new ArgumentException(nameof(value));
            }
        }

        public int PagesNumber
        {
            get => pagesNumber;

            private set
            {
                if (value > 0)
                    pagesNumber = value;

                else throw new ArgumentException(nameof(value));
            }
        }

        public int Price
        {
            get => price;

            private set
            {
                if (value < 0)
                    throw new ArgumentException(nameof(value));

                price = value;
            }
        }

        #endregion

        #region Constructors

        public Book(string isbn, string author, string name, string publishingHouse, int publishingYear, int pagesNumber, int price)
        {
            this.ISBN = isbn;
            this.Author = author;
            this.Name = name;
            this.PublishingHouse = publishingHouse;
            this.PublishingYear = publishingYear;
            this.PagesNumber = pagesNumber;
            this.Price = price;
        }

        public Book(Book book)
        {
            this.ISBN = book.ISBN;
            this.Author = book.Author;
            this.Name = book.Name;
            this.PublishingHouse = book.PublishingHouse;
            this.PublishingYear = book.PublishingYear;
            this.PagesNumber = book.PagesNumber;
            this.Price = book.Price;
        }

        public Book() { }

        #endregion

        /// <summary>
        /// Returns a string representation
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString() => $"ISBN: {ISBN}, Name: {Name}, Author: {Author}, Publishing House: {PublishingHouse}, Publishing year: {PublishingYear}, Pages number: {PagesNumber}, Price: {Price}";

        /// <summary>
        /// checks book class objects for equality
        /// </summary>
        /// <param name="obj">The <see cref="System.Object" /> to compare with this instance.</param>
        /// <returns>
        ///   <c>true</c> if the specified <see cref="System.Object" /> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public override bool Equals(object obj)
        {
            Book book = (Book)obj;

            if (this.ISBN == book.ISBN && this.Author == book.Author && this.Name == book.Name && this.Price == book.Price
                && this.PublishingHouse == book.PublishingHouse && this.PublishingYear == book.PublishingYear && this.PagesNumber == book.PagesNumber)
            {
                return true;
            }

            return false;
        }
    }
}

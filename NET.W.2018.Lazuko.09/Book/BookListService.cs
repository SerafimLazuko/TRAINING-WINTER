using System;
using System.IO;
using System.Collections.ObjectModel;
using System.Collections;
using BookLogic.Matches;

namespace BookLogic.BookListService
{
    /// <summary>
    /// Provides with API to work with book collection;
    /// </summary>
    public class BookListService
    {
        #region Class members

        public Collection<Book> books;

        public Collection<Book> Books
        {
            get
            {
                Collection<Book> result = new Collection<Book>();

                foreach (Book book in books)
                {
                    result.Add(new Book(book));
                }

                return result;
            }

            set
            {
                foreach (Book book in value)
                {
                    books.Add(new Book(book));
                }
            }
        }

        public BookListService(Collection<Book> inputBooks)
        {
            Books = inputBooks;
        }

        #endregion

        #region API

        /// <summary>
        /// Adds the book in collection books.
        /// </summary>
        /// <param name="book">The book.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException"></exception>
        /// <exception cref="System.Exception"></exception>
        public bool AddBook(Book book)
        {
            if (book == null || books == null)
            {
                throw new ArgumentNullException();
            }

            foreach(Book b in Books)
            {
                if (b.Equals(book))
                    throw new Exception($"the same book {book} is already exist!");
            }

            Books.Add(book);

            return true;
        }

        /// <summary>
        /// Removes the book from books collection.
        /// </summary>
        /// <param name="book">The book.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException"></exception>
        /// <exception cref="System.Exception">no matches found!</exception>
        public bool RemoveBook(Book book)
        {
            if (book == null || books == null)
            {
                throw new ArgumentNullException();
            }

            int count = 0;

            for(int i = 0; i < Books.Count; i++)
            {
                if (book.Equals(Books[i]))
                {
                    Books.Remove(book);
                    i--;
                    count++;
                }
            }

            if (count == 0)
                return false;
            
            return true;            
        }

        /// <summary>
        /// Finds the book in books collection by tag.
        /// </summary>
        /// <param name="matcher">The matcher.</param>
        /// <param name="tag">The tag.</param>
        /// <returns></returns>
        public Collection<Book> FindBookByTag(IMatcher matcher, string tag)
        {
            Collection<Book> result = new Collection<Book>();

            foreach(Book book in Books)
            {
                if (matcher.IsMatch(book, tag))
                    result.Add(book);
            }
            
            return result;
        }

        /// <summary>
        /// Sorts the book in books collection.
        /// </summary>
        /// <param name="comparer">The comparer.</param>
        public void SortBook(IComparer comparer)
        {
            for (int i = 0; i < Books.Count; i++)
            {
                for (int j = 0; j < Books.Count; j++)
                {
                    if(comparer.Compare(Books[i], Books[j]) == 1)
                    {
                        Book temp = Books[i];
                        Books[i] = Books[j];
                        Books[j] = temp;
                    }
                }
            }
        }

        /// <summary>
        /// Saves the info about book in file.
        /// </summary>
        public void SaveInFile()
        {
            try
            {
                string path = @"C:\Users\User\source\repos\TRAINING - WINTER\NET.W.2018.Lazuko.08";

                using (BinaryWriter writer = new BinaryWriter(new FileStream(path, FileMode.OpenOrCreate)))
                {
                    foreach (Book book in books)
                    {
                        writer.Write(book.ISBN);
                        writer.Write(book.Author);
                        writer.Write(book.Name);
                        writer.Write(book.PublishingHouse);
                        writer.Write(book.PublishingYear);
                        writer.Write(book.PagesNumber);
                        writer.Write(book.Price);
                    }
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        /// <summary>
        /// Reads the info from file.
        /// </summary>
        public void ReadFromFile()
        {
            try
            {
                string path = @"C:\Users\User\source\repos\TRAINING - WINTER\NET.W.2018.Lazuko.08";
                using (BinaryReader reader = new BinaryReader(new FileStream(path, FileMode.Open)))
                {
                    while (reader.PeekChar() > -1)
                    {
                        books.Add(new Book(reader.ReadString(), reader.ReadString(), reader.ReadString(), reader.ReadString(), reader.ReadInt32(), reader.ReadInt32(), reader.ReadInt32()));
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        #endregion
    }
}

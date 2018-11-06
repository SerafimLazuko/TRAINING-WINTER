using System;
using System.IO;
using System.Collections.ObjectModel;
using System.Collections;
using BookLogic.Matches;
using BookLogic.Sorters;

namespace BookLogic.BookListService
{
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
                throw new Exception("no matches found!");

            return true;            
        }

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

        public  void SortBookByTag(IComparer comparer)
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

        #endregion

        //public void SaveInFile()
        //{
        //    try
        //    {
        //        string path = @"C:\Users\User\source\repos\TRAINING - WINTER\NET.W.2018.Lazuko.08";

        //        using (BinaryWriter writer = new BinaryWriter(new FileStream(path, FileMode.OpenOrCreate)))
        //        {
                    
        //        }
                 
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine(e.Message);
        //    } 
        //}
    }
}

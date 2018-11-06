using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;
using BookLogic;
using BookLogic.Sorters;
using BookLogic.BookListService;
using System.Collections.ObjectModel;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            Book firstBook = new Book("978-5-699-12014-7", "A", "Crime and Punishment", "Russian Gazette", 1866, 452, 28);
            Book secondBook = new Book("978-5-699-12014-7", "B", "Crime and Punishment", "Russian Gazette", 2014, 75, 30);
            Book thirdBook = new Book("978-5-699-12014-4", "C", "Crime and Punishment", "Russian Gazette", 1943, 324, 25);
            Book fourthBook = new Book("978-5-699-12014-1", "D", "Crime and Punishment", "Russian Gazette", 2014, 132, 26);

            Collection<Book> books = new Collection<Book>();

            BookListService.AddBook(ref books, firstBook);
            BookListService.AddBook(ref books, secondBook);
            BookListService.AddBook(ref books, thirdBook);
            BookListService.AddBook(ref books, fourthBook);

            IComparer comparer = new SortAuthorDescending() ;

            BookListService.SortBookByTag(ref books, comparer);

            foreach(Book book in books)
            {
                Console.WriteLine(book.ToString());
            }

            Console.ReadKey();

        }
    }
}

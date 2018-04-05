using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            IBookListStorage bookListStorage = new BookListStorage("Storage.bin");
            IBookListService bookListService = new BookListService(bookListStorage);

            bookListService.AddBook(new Book("978-0-7356-6745-7", "Jeffrey Richter", "CLR via C#", "Microsoft Press", 2017, 826, 59.99));
            bookListService.AddBook(new Book("978-1-4842-1332-2", "Andrew Troelsen", "C# 6.0 and the .NET 4.6 Framework", "APress", 2015, 1311, 44.99));

            var book = new List<Book>();
            book.Add(bookListService.FindBook(new FindBookByName("CLR via C#", bookListService.GetAllBooks().ToList())));
            book.Add(bookListService.FindBook(new FindBookByISBN("978-1-4842-1332-2", bookListService.GetAllBooks().ToList())));

            ShowBook(book);
            bookListService.Sort(null);
            ShowBook(bookListService.GetAllBooks());

            bookListService.Save();
            Console.ReadKey();
            
        }

        private static void ShowBook(Book book)
        {
            Console.WriteLine(book);
        }

        private static void ShowBook(IEnumerable<Book> books)
        {
            foreach (var book in books)
            {
                Console.Write(book);
                Console.WriteLine();
            }
        }
    }
}

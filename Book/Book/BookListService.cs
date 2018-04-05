using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book
{
    public class BookListService : IBookListService
    {
        private readonly IBookListStorage bookListStorage;

        private List<Book> books = new List<Book>();

        private ILogger logger;

        public BookListService(IBookListStorage bookListStorage)
        {
            if (ReferenceEquals(bookListStorage, null))
            {
                throw new ArgumentException();
            }
            this.bookListStorage = bookListStorage;
        }

        public void AddBook(Book book)
        {
            if (ReferenceEquals(book, null))
            {
                throw new ArgumentException();
            }
            books.Add(book);
        }

        public Book FindBook(IFinder parameter)
        {
            if (ReferenceEquals(parameter, null))
            {
                throw new ArgumentNullException();
            }
            return parameter.FindBookByTag();
        }

        public IEnumerable<Book> GetAllBooks()
        {
            return bookListStorage.GetBookList();
        }

        public void RemoveBook(Book book)
        {
            if (ReferenceEquals(book, null))
            {
                throw new ArgumentNullException();
            };
            books.Remove(book);
        }

        public void Save()
        {
            bookListStorage.SaveBooks(books);
        }

        public void Sort(IComparer<Book> comparator)
        {
            var booksArray = books.ToArray();
            if (ReferenceEquals(comparator, null))
            {
                Array.Sort(booksArray);
            }
            else
            {
                Array.Sort(booksArray, comparator);
            }
            books.Clear();
            books.AddRange(booksArray);
        }
    }
}

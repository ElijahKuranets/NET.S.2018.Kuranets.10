using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book
{
    public interface IBookListService
    {
        void AddBook(Book book);

        void RemoveBook(Book book);

        Book FindBook(IFinder parameter);

        void Sort(IComparer<Book> comparator);

        void Save();

        IEnumerable<Book> GetAllBooks();
    }
}

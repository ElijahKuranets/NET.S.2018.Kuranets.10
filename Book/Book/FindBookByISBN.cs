using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book
{
    public class FindBookByISBN : IFinder
    {
        public string Isbn { get; }
        public List<Book> Books { get; }
        public FindBookByISBN(string isbn, IEnumerable<Book> books)
        {
            Isbn = isbn;
            Books = books.ToList();
        }
        public Book FindBookByTag()
        {
            return Books.FirstOrDefault(book => book.ISBN == Isbn);
        }
    }
}

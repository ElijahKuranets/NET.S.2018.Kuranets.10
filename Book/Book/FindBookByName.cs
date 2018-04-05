using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book
{
    public class FindBookByName : IFinder
    {
        public string Name { get; }
        public List<Book> Books { get; }

        public FindBookByName(string name, List<Book> books)
        {
            Name = name;
            Books = books;
        }

        public Book FindBookByTag()
        {
            return Books.FirstOrDefault(book => book.Title == Name); 
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book
{
    public class BookListStorage: IBookListStorage
    {
        /// <summary>
        /// Field "path" is a file location
        /// </summary>
        private readonly string path;

        public BookListStorage()
        {
            if (string.IsNullOrEmpty(path))
            {
                throw new ArgumentException("Incorrect");
            }
        }

        #region public methods
        public IEnumerable<Book> GetBookList()
        {
            List<Book> books = new List<Book>();
            using (var br = new BinaryReader(File.Open(path, FileMode.OpenOrCreate, FileAccess.Read, FileShare.Read)))
            {
                while (br.BaseStream.Position != br.BaseStream.Length)
                {
                    var book = Reader(br);
                    books.Add(book);
                }
            }
            return books;
        }

        public void AppendBookToFile(Book book)
        {
            using (var bw = new BinaryWriter(File.Open(path, FileMode.Append, FileAccess.Write, FileShare.None)))
            {
                Writer(bw,book);
            }
        }

        public void SaveBooks(IEnumerable<Book> booksSave)
        {
            using (var bw = new BinaryWriter(File.Open(path, FileMode.Create, FileAccess.Write, FileShare.None)))
            {
                foreach (var book in booksSave)
                {
                    Writer(bw, book);
                }
            }
        }
#endregion

        #region private methods
        private static void Writer(BinaryWriter binary, Book book)
        {
            binary.Write(book.ISBN);
            binary.Write(book.AuthorName);
            binary.Write(book.Title);
            binary.Write(book.Publisher);
            binary.Write(book.Year);
            binary.Write(book.NumberOfPages);
            binary.Write(book.Price);
        }

        private static Book Reader(BinaryReader binary)
        {
            var isbn = binary.ReadString();
            var author = binary.ReadString();
            var title = binary.ReadString();
            var publisher = binary.ReadString();
            var year = binary.ReadInt32();
            var numberofpages = binary.ReadInt32();
            var price = binary.ReadDouble();

            return new Book(isbn, author, title, publisher, year, numberofpages, price);
        }
        #endregion 
    }
}

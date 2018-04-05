using System;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book
{
    public class Book : IEquatable<Book>, IComparable, IComparable<Book>, IFormattable
    {
        public string ISBN { get; set; }
        public string AuthorName { get; set; }
        public string Title { get; set; }
        public string Publisher { get; set; }
        public int Year { get; set; }
        public int NumberOfPages { get; set; }
        public double Price { get; set; }

        public Book() { }

        public Book(string isbn, string author, string title, string publisher, int year, int numberofpages, double price)
        {
            ISBN = isbn;
            AuthorName = author;
            Title = title;
            Publisher = publisher;
            Year = year;
            NumberOfPages = numberofpages;
            Price = price;
        }

        #region IEquatable
        public bool Equals(Book book)
        {
            if (ReferenceEquals(book, null))
            {
                return false;
            }
            if (ReferenceEquals(this, book))
            {
                return true;
            }
            else return book.ISBN == ISBN;
        }
        #endregion

        #region IComparable
        public int CompareTo(object bookObject)
        {
            if (ReferenceEquals(bookObject, null))
            {
                return 1;
            }
            var book = (Book)bookObject;
            return CompareTo(book);
        }
        #endregion

        #region IComparable<Book>
        public int CompareTo(Book book)
        {
            if (ReferenceEquals(book, null))
            {
                return 1;
            }
            return string.Compare(Title, book.Title);
        }
        #endregion

        #region IFormattable
        public string ToString(string format, IFormatProvider formatProvider)
        {
            if (string.IsNullOrEmpty(format))
            {
                format = "5";
            }

            switch (format)
            {
                case "1": return $"Author: {AuthorName} Book: {Title} ";
                case "2": return $"Author: {AuthorName} Book: {Title} Publisher: {Publisher} Year: {Year}";
                case "3": return $"ISBN: {ISBN} Author: {AuthorName} Book: {Title} Publisher: {Publisher} Year: {Year}";
                case "4": return $"ISBN: {ISBN} Author: {AuthorName} Book: {Title} Publisher: {Publisher} Year: {Year} NumberOfPages: {NumberOfPages}";
                case "5": return $"ISBN: {ISBN} Author: {AuthorName} Book: {Title} Publisher: {Publisher} Year: {Year} Price: {Price}";
                case "6": return $"ISBN: {ISBN} Author: {AuthorName} Book: {Title} Publisher: {Publisher} Year: {Year} NumberOfPages: {NumberOfPages} Price: {Price}";
                default: throw new FormatException($"The {format} format string is not supported.");
            }
        }
        #endregion

        #region Override Methods
        public override bool Equals(object bookEquals)
        {
            var book = (Book)bookEquals;
            if (book == null)
            {
                return false;
            };
            return ISBN == book.ISBN && AuthorName == book.AuthorName && book.Title == Title && book.Publisher == Publisher && book.Year == Year && book.NumberOfPages == NumberOfPages && book.Price == Price;
        }

        public override int GetHashCode()
        {
            return ISBN.GetHashCode();
        }

        public override string ToString()
        {
            return ToString("7", null);
        }
        #endregion
    }
}

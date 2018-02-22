namespace LibraryManager
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;

    public class BookList
    {
        public List<Book> a_books;

        public BookList()
        {
            a_books = new List<Book>();
        }
    }
}
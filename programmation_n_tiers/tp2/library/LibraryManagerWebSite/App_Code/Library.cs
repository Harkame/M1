using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace LibraryManager
{
    public class Library
    {
        public List<Book> a_books;

        public List<Subscriber> a_subscribers;

        public Library()
        {
            a_books = new List<Book>();

            a_subscribers = new List<Subscriber>();
        }
    }
}
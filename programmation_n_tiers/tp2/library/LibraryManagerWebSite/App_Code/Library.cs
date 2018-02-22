using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace LibraryManager
{
    public static class Library
    {
        public static List<Book> a_books = new List<Book>();

        public static List<Subscriber> a_subscribers = new List<Subscriber>();
    }
}
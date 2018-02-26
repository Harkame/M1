namespace LibraryManager
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Runtime.Serialization;

    public static class Library
    {
        public static List<Book> a_books = new List<Book>();

        public static List<Librarian> a_librarians = new List<Librarian>();

        public static List<Subscriber> a_subscribers = new List<Subscriber>();

        static Library()
        {
            Library.a_books.Add(new Book("book1", "author1", 0, 1, "editor1"));
            Library.a_books.Add(new Book("book2", "author1", 1, 10, "editor1"));
            Library.a_books.Add(new Book("book3", "author2", 2, 5, "editor2"));
            Library.a_books.Add(new Book("book4", "author3", 3, 9, "editor3"));
            Library.a_books.Add(new Book("book5", "author4", 4, 0, "editor2"));

            Library.a_librarians.Add(new Librarian("123"));
            Library.a_librarians.Add(new Librarian("toto"));
            
            Library.a_subscribers.Add(new Subscriber("123"));
            Library.a_subscribers.Add(new Subscriber("toto"));
            Library.a_subscribers.Add(new Subscriber("yolo"));
            Library.a_subscribers.Add(new Subscriber("test"));
            Library.a_subscribers.Add(new Subscriber("password"));
        }
    }
}
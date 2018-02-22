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

        static Library()
        {
            Library.a_books.Add(new Book("book1", "author1", 0, 1, "editor1"));
            Library.a_books.Add(new Book("book2", "author1", 1, 10, "editor1"));
            Library.a_books.Add(new Book("book3", "author2", 2, 5, "editor2"));
            Library.a_books.Add(new Book("book4", "author3", 3, 9, "editor3"));
            Library.a_books.Add(new Book("book5", "author4", 4, 0, "editor2"));
            
            Library.a_subscribers.Add(new Subscriber(0, "123"));
            Library.a_subscribers.Add(new Subscriber(1, "toto"));
            Library.a_subscribers.Add(new Subscriber(2, "yolo"));
            Library.a_subscribers.Add(new Subscriber(3, "test"));
            Library.a_subscribers.Add(new Subscriber(4, "password"));
        }
    }
}
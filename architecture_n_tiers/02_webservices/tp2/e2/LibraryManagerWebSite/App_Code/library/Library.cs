namespace LibraryManager
{
    using System.Collections.Generic;

    public static class Library
    {
        public static List<Book> Books = new List<Book>();

        public static List<Librarian> Librarians = new List<Librarian>();

        public static List<Subscriber> Subscribers = new List<Subscriber>();

        public static List<User> Connections = new List<User>();

        static Library()
        {
            Library.Books.Add(new Book("book1", "author1", 0, 1, "editor1"));
            Library.Books.Add(new Book("book2", "author1", 1, 10, "editor1"));
            Library.Books.Add(new Book("book3", "author2", 2, 5, "editor2"));
            Library.Books.Add(new Book("book4", "author3", 3, 9, "editor3"));
            Library.Books.Add(new Book("book5", "author4", 4, 0, "editor2"));

            Library.Librarians.Add(new Librarian("password123"));
            Library.Librarians.Add(new Librarian("password321"));
            
            Library.Subscribers.Add(new Subscriber("password123"));
            Library.Subscribers.Add(new Subscriber("password321"));
        }

        public static bool IsValid(User p_user)
        {
            return (p_user != null) && Connections.Contains(p_user);
        }
    }
}
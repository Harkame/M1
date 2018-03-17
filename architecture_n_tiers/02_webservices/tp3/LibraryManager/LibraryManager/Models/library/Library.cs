namespace LibraryManager
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Runtime.Serialization;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.Web.Mvc;
    using System.Web.Security;

    public static class Library
    {
        [Required]
        [DisplayName("Book")]
        public static List<Book> Books { get; set; }

        [Required]
        [DisplayName("Librarians")]
        public static List<Librarian> Librarians { get; set; }

        [Required]
        [DisplayName("Subscribers")]
        public static List<Subscriber> Subscribers { get; set; }

        [Required]
        [DisplayName("Connections")]
        public static List<User> Connections { get; set; }

        static Library()
        {
            Books = new List<Book>();

            Librarians = new List<Librarian>();

            Subscribers = new List<Subscriber>();

            Connections = new List<User>();

            Books.Add(new Book("book1", "author1", 0, 1, "editor1"));
            Books.Add(new Book("book2", "author1", 1, 10, "editor1"));
            Books.Add(new Book("book3", "author2", 2, 5, "editor2"));
            Books.Add(new Book("book4", "author3", 3, 9, "editor3"));
            Books.Add(new Book("book5", "author4", 4, 0, "editor2"));

            Librarians.Add(new Librarian("123"));
            Librarians.Add(new Librarian("toto"));

            Subscribers.Add(new Subscriber("123"));
            Subscribers.Add(new Subscriber("toto"));
            Subscribers.Add(new Subscriber("yolo"));
            Subscribers.Add(new Subscriber("test"));
            Subscribers.Add(new Subscriber("password"));
        }

        public static bool IsValid(int p_user_id)
        {
            foreach(User t_user in Connections)
                if(p_user_id == t_user.ID)
                    return true;

            return false;
        }
    }
}
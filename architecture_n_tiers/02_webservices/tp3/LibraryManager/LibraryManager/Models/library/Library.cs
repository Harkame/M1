using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LibraryManager
{
    public static class Library
    {
        [Required]
        public static List<Book> Books { get; set; }

        [Required]
        public static List<Librarian> Librarians { get; set; }

        [Required]
        public static List<Subscriber> Subscribers { get; set; }

        [Required]
        public static List<User> Connections { get; set; }

        static Library()
        {
            Books = new List<Book>();

            Librarians = new List<Librarian>();

            Subscribers = new List<Subscriber>();

            Connections = new List<User>();

            Books.Add(new Book("book1", "author1", 1, "editor1"));
            Books.Add(new Book("book2", "author1", 10, "editor1"));
            Books.Add(new Book("book3", "author2", 5, "editor2"));
            Books.Add(new Book("book4", "author3", 9, "editor3"));
            Books.Add(new Book("book5", "author4", 0, "editor2"));

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

        public static bool IsValidLibrarian(int p_librarian_id)
        {
            foreach (User t_user in Connections)
                if (t_user.ID == p_librarian_id && t_user.GetType().Name.Equals("Librarian"))
                    return true;

            return false;
        }

        public static bool IsValidSubscriber(int p_subscriber_id)
        {
            foreach (User t_user in Connections)
                if (t_user.ID == p_subscriber_id && t_user.GetType().Name.Equals("Subscriber"))
                    return true;

            return false;
        }
    }
}
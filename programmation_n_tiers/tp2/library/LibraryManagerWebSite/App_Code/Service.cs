using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace LibraryManager
{
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class Service : System.Web.Services.WebService
    {
        private static Library a_library;

        public Service ()
        {
            a_library = new Library();

            a_library.a_books.Add(new Book("book1", "author1", 0, 1, "editor1"));
            a_library.a_books.Add(new Book("book2", "author1", 1, 10, "editor1"));
            a_library.a_books.Add(new Book("book3", "author2", 2, 5, "editor2"));
            a_library.a_books.Add(new Book("book4", "author3", 3, 9, "editor3"));
            a_library.a_books.Add(new Book("book5", "author4", 4, 0, "editor2"));

            a_library.a_subscribers.Add(new Subscriber(0, "123"));
            a_library.a_subscribers.Add(new Subscriber(1, "toto"));
            a_library.a_subscribers.Add(new Subscriber(2, "yolo"));
            a_library.a_subscribers.Add(new Subscriber(3, "test"));
            a_library.a_subscribers.Add(new Subscriber(4, "password"));
        }

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod]
        public Book SearchBookByISDN(int p_isbn)
        {
            foreach (Book t_book in a_library.a_books)
                if (t_book.a_isbn == p_isbn)
                    return t_book;

            return null;
        }

        [WebMethod]
        public List<Book> SearchBooksByAuthor(String p_author)
        {
            List<Book> t_books = new List<Book>();

            foreach (Book t_book in a_library.a_books)
                if (t_book.a_author.ToLower().Equals(p_author.ToLower()))
                    t_books.Add(t_book);

            return t_books;
        }

        [WebMethod]
        public Subscriber Authentificate(int p_id, String p_password)
        {
            foreach (Subscriber t_subscriber in a_library.a_subscribers)
                if (t_subscriber.a_id == p_id && t_subscriber.a_password.Equals(p_password))
                    return t_subscriber;

            return null;
        }

        [WebMethod]
        public String GetBookDescription(Book p_book)
        {
            foreach (Book t_book in a_library.a_books)
                if (t_book.a_isbn == p_book.a_isbn)
                    return t_book.ToString();

            return null;
        }

        [WebMethod]
        public void CommentBook(Book p_book_to_comment, Subscriber p_subscriber, String p_description)
        {
            foreach (Book t_book in a_library.a_books)
                if (t_book.a_isbn == p_book_to_comment.a_isbn)
                    t_book.Comment(p_subscriber, p_description);
        }
    }
}
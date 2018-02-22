namespace LibraryManager
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Services;

    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]

    public class Service : System.Web.Services.WebService
    {
        public Service ()
        {
        }

        [WebMethod]
        public Book SearchBookByISDN(int p_isbn)
        {
            foreach (Book t_book in Library.a_books)
                if (t_book.a_isbn == p_isbn)
                    return t_book;

            return null;
        }

        [WebMethod]
        public Book[] SearchBooksByAuthor(String p_author)
        {
            List<Book> t_books = new List<Book>();

            foreach (Book t_book in Library.a_books)
                if (t_book.a_author.Equals(p_author))
                    t_books.Add(t_book);

            return t_books.ToArray();
        }

        [WebMethod]
        public Subscriber Authentificate(int p_id, String p_password)
        {
            foreach (Subscriber t_subscriber in Library.a_subscribers)
                if (t_subscriber.a_id == p_id && t_subscriber.a_password.Equals(p_password))
                    return t_subscriber;

            return null;
        }

        [WebMethod]
        public String GetBookDescription(Book p_book)
        {
            foreach (Book t_book in Library.a_books)
                if (t_book.a_isbn == p_book.a_isbn)
                    return t_book.ToString();

            return null;
        }

        [WebMethod]
        public String CommentBook(Book p_book_to_comment, Subscriber p_subscriber, String p_description)
        {
            for (int t_index = 0; t_index < Library.a_books.Count; t_index++)
                if (Library.a_books[t_index].a_isbn == p_book_to_comment.a_isbn)
                {
                    Library.a_books[t_index].Comment(p_subscriber, p_description);
                    return Library.a_books[t_index].ToString();
                }
            return null;
        }
    }
}
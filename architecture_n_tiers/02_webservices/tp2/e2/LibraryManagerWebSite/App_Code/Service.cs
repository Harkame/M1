namespace LibraryManager
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Services;
    using System.Text;

    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]

    public class Service : System.Web.Services.WebService
    {
        public Service ()
        {
        }

        [WebMethod]
        public Book SearchBookByISBN(int p_isbn)
        {
            foreach (Book t_book in Library.a_books)
                if (t_book.ISBN == p_isbn)
                    return t_book;

            return null;
        }

        [WebMethod]
        public String GetCommands(Person p_user)
        {
            if (p_user == null)
                return null;

            StringBuilder t_commands = new StringBuilder();

            t_commands.Append("Action :");
            t_commands.Append(Environment.NewLine);
            t_commands.Append("[1] : Show books");
            t_commands.Append(Environment.NewLine);
            t_commands.Append("[2] : Search book by ISBN");
            t_commands.Append(Environment.NewLine);
            t_commands.Append("[3] : Search book by Author");
            t_commands.Append(Environment.NewLine);
            t_commands.Append("[4] : Comment book");
            t_commands.Append(Environment.NewLine);
            t_commands.Append("[5] : Add book (Librarian only)");
            t_commands.Append(Environment.NewLine);
            t_commands.Append("[6] : Exit");
            t_commands.Append(Environment.NewLine);

            return t_commands.ToString();
        }

        [WebMethod]
        public String GetBooks()
        {
            StringBuilder r_books = new StringBuilder();

            foreach (Book t_book in Library.a_books)
            {
                r_books.Append(t_book.ToString());
                r_books.Append(Environment.NewLine);
            }

            return r_books.ToString();
        }

        [WebMethod]
        public Book[] SearchBooksByAuthor(String p_author)
        {
            List<Book> t_books = new List<Book>();

            foreach (Book t_book in Library.a_books)
                if (t_book.Author.Equals(p_author))
                    t_books.Add(t_book);

            return t_books.ToArray();
        }

        [WebMethod]
        public Librarian[] GetLibrarians()
        {
            return null;
        }

        [WebMethod]
        public Person Authentificate(int p_id, String p_password)
        {
            foreach (Librarian t_librarian in Library.a_librarians)
                if (t_librarian.ID == p_id && t_librarian.Password.Equals(p_password))
                    return t_librarian;

            foreach (Subscriber t_subscriber in Library.a_subscribers)
                if (t_subscriber.ID == p_id && t_subscriber.Password.Equals(p_password))
                    return t_subscriber;

            return null;
        }

        [WebMethod]
        public void AddBook(String p_title, String p_author, int p_isbn, int p_stock, String p_editor)
        {
            Library.a_books.Add(new Book(p_title, p_author, p_isbn, p_stock, p_editor));
        }

        [WebMethod]
        public String GetBookDescription(Book p_book)
        {
            foreach (Book t_book in Library.a_books)
                if (t_book.ISBN == p_book.ISBN)
                    return t_book.ToString();

            return null;
        }

        [WebMethod]
        public String CommentBook(Book p_book_to_comment, Person p_subscriber, String p_description)
        {
            for (int t_index = 0; t_index < Library.a_books.Count; t_index++)
                if (Library.a_books[t_index].ISBN == p_book_to_comment.ISBN)
                {
                    Library.a_books[t_index].Comment(p_subscriber, p_description);
                    return Library.a_books[t_index].ToString();
                }
            return null;
        }
    }
}
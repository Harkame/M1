namespace LibraryManager.Controllers
{
    using System;
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Mvc;
    using System.Text;

    public class BookController : Controller
    {
        /// <summary>
        /// Return all books in the Library
        /// </summary>
        /// <returns>Return an array of Book, all of the List of books in the Library</returns>
        [HttpGet]
        public String GetBooks()
        {
            StringBuilder r_books = new StringBuilder();

            foreach(Book t_book in Library.Books)
                r_books.Append(t_book.ToString());

            return r_books.ToString();
        }

        /// <summary>
        /// Return an object Book designated by his ISBN
        /// </summary>
        /// <param name="p_User">User for check if he is connected (Librarian or Subscriber)</param>
        /// <param name="p_isbn">ISBN of the searched book</param>
        /// <returns>An book with ISBN p_isbn</returns>
        [HttpGet]
        public String SearchBookByISBN(int p_user_id, int p_isbn)
        {
            if (Library.IsValid(p_user_id))
                foreach (Book t_book in Library.Books)
                    if (t_book.ISBN == p_isbn)
                        return t_book.ToString();

            return null;
        }

        /// <summary>
        /// Return an array of objects Book writted by an certain author
        /// </summary>
        /// <param name="p_User">User for check if he is connected (Librarian or Subscriber)</param>
        /// <param name="p_author">Author of the searched books</param>
        /// <returns>An array of book writted by p_author</returns>
        [HttpGet]
        public String SearchBooksByAuthor(int p_user_id, String p_author)
        {
            if (Library.IsValid(p_user_id))
            {
                List<Book> t_books = new List<Book>();

                foreach (Book t_book in Library.Books)
                    if (t_book.Author.Equals(p_author))
                        t_books.Add(t_book);

                StringBuilder r_books = new StringBuilder();

                foreach (Book t_book in t_books)
                    r_books.Append(t_book.ToString());

                return r_books.ToString();
            }
            else
                return null;
        }

        /// <summary>
        /// Return book description (ToString method)
        /// </summary>
        /// <param name="p_user">User to authentificate</param>
        /// <param name="p_isbn">ISBN of the book</param>
        /// <returns>An String who describe the book designated by p_isbn</returns>
        [HttpGet]
        public String GetBookDescription(int p_user_id, int p_isbn)
        {
            if (Library.IsValid(p_user_id))
                foreach (Book t_book in Library.Books)
                    if (t_book.ISBN == p_isbn)
                        return t_book.ToString();

            return null;
        }

        /// <summary>
        /// Add an book designed by all of his attributs into the Library (Necessary to be authentificate as a Librarian)
        /// </summary>
        /// <param name="p_librarian">Librarian who add the book, check if he is connected</param>
        /// <param name="p_title">Title of the book who are added</param>
        /// <param name="p_author">Author of the book who are added</param>
        /// <param name="p_isbn">ISBN of the book who are added</param>
        /// <param name="p_stock">Stock of the book who are added</param>
        /// <param name="p_editor">Editor of the book who are added</param>
        /// <returns>True if the book was added, else return false</returns>
        [HttpPost]
        public bool AddBook(int p_librarian_id, String p_title, String p_author, int p_isbn, int p_stock, String p_editor)
        {
            if (Library.IsValidLibrarian(p_librarian_id))
            {
                Library.Books.Add(new Book(p_title, p_author, p_isbn, p_stock, p_editor));
                return true;
            }
            else
             return false;
        }

        /// <summary>
        /// Add an commented on the designated Book (Only Subscriber can comment a Book, necessary to be connected)
        /// </summary>
        /// 
        /// <param name="p_subscriber">The subscriber who comment the Book</param>
        /// <param name="p_isbn">The isbn of the book to comment</param>
        /// <param name="p_description">The description of the comment</param>
        /// <returns>True if the book was commented, else return false (unauthorised, book not found)</returns>
        [HttpPost]
        public bool CommentBook(int p_subscriber_id, int p_isbn, String p_description)
        {
            if (!Library.IsValidSubscriber(p_subscriber_id) || (p_description == null))
                return false;

            for (int t_index = 0; t_index < Library.Books.Count; t_index++)
                if (Library.Books[t_index].ISBN == p_isbn)
                {
                    Library.Books[t_index].Comment(p_subscriber_id, p_description);
                    return true;
                }
            return false;
        }
    }
}

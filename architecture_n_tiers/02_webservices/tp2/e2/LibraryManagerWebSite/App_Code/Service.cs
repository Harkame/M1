﻿namespace LibraryManager
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
         public Service()
         {
         }

         /// <summary>
         /// Authentificate a Librarian (Return an object and add it into the list of connected users)
         /// </summary>
         /// <param name="p_id">The ID of the Librarian</param> 
         /// <param name="p_password">The password of the Librarian</param>
         /// <returns>A object Librarian designed by p_id and p_password, null if the authentification has failed</returns>
         [WebMethod]
         public Librarian AuthentificateAsLibrarian(int p_id, String p_password)
         {
             foreach (Librarian t_librarian in Library.a_librarians)
                 if (t_librarian.ID == p_id && t_librarian.Password.Equals(p_password))
                 {
                     Library.a_connections.Add(t_librarian);
                     return t_librarian;
                 }
             return null;
         }

         /// <summary>
         /// Authentificate a Subscriber (Return an object and add it into the list of connected users)
         /// </summary>
         /// <param name="p_id">The ID of the Subscriber</param> 
         /// <param name="p_password">The password of the Subscriber</param>
         /// <returns>A object Subscriber designed by p_id and p_password, null if the authentification has failed</returns>
         [WebMethod]
         public Subscriber AuthentificateAsSubscriber(int p_id, String p_password)
         {
             foreach (Subscriber t_subscriber in Library.a_subscribers)
                 if (t_subscriber.ID == p_id && t_subscriber.Password.Equals(p_password))
                 {
                     Library.a_connections.Add(t_subscriber);
                     return t_subscriber;
                 }

             return null;
         }

         /// <summary>
         /// Remove an user from the list of connected users
         /// </summary>
         /// <param name="p_User">User to disconnect</param>
         [WebMethod]
         public void Disconnect(User p_user)
         {
             Library.a_connections.Remove(p_user);
         }

         /// <summary>
         /// Return an object Book designated by his ISBN
         /// </summary>
         /// <param name="p_User">User for check if he is connected (Librarian or Subscriber)</param>
         /// <param name="p_isbn">ISBN of the searched book</param>
         /// <returns>An book with ISBN p_isbn</returns>
         [WebMethod]
         public Book SearchBookByISBN(User p_User, int p_isbn)
         {
             if (!Library.IsConnected(p_User))
                 return null;

             foreach (Book t_book in Library.a_books)
                 if (t_book.ISBN == p_isbn)
                     return t_book;

             return null;
         }

         /// <summary>
         /// Return an array of objects Book writted by an certain author
         /// </summary>
         /// <param name="p_User">User for check if he is connected (Librarian or Subscriber)</param>
         /// <param name="p_author">Author of the searched books</param>
         /// <returns>An array of book writted by p_author</returns>
         [WebMethod]
         public Book[] SearchBooksByAuthor(User p_User, String p_author)
         {
             if (!Library.IsConnected(p_User))
                 return null;

             List<Book> t_books = new List<Book>();

             foreach (Book t_book in Library.a_books)
                 if (t_book.Author.Equals(p_author))
                     t_books.Add(t_book);

             return t_books.ToArray();
         }

         /// <summary>
         /// Return all books in the Library
         /// </summary>
         /// <returns>Return an array of Book, all of the List of books in the Library</returns>
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

         /// <summary>
         /// Return all of the possible commands for each kind of User
         /// </summary>
         /// <param name="p_user">User for check if he is connected and get his type (Librarian or Subscriber)</param>
         /// <returns>Return an String who represent possible commands for each kind of User</returns>
         [WebMethod]
         public String GetCommands(User p_user)
         {
             if (p_user == null)
                 return null;

             StringBuilder t_commands = new StringBuilder();

             switch (p_user.GetType().Name)
             {
                 case "Librarian":
                     t_commands.Append("Action :");
                     t_commands.Append(Environment.NewLine);
                     t_commands.Append("[1] : Show books");
                     t_commands.Append(Environment.NewLine);
                     t_commands.Append("[2] : Search book by ISBN");
                     t_commands.Append(Environment.NewLine);
                     t_commands.Append("[3] : Search book by Author");
                     t_commands.Append(Environment.NewLine);
                     t_commands.Append("[4] : Add book");
                     t_commands.Append(Environment.NewLine);
                     break;

                 case "Subscriber":
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
                     break;
             }

             t_commands.Append("[5] : Disconnect");
             t_commands.Append(Environment.NewLine);

             return t_commands.ToString();
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
         [WebMethod]
         public bool AddBook(Librarian p_librarian, String p_title, String p_author, int p_isbn, int p_stock, String p_editor)
         {
             if (Library.IsConnected(p_librarian))
             {
                 Library.a_books.Add(new Book(p_title, p_author, p_isbn, p_stock, p_editor));
                 return true;
             }
             else
                 return false;
         }

         [WebMethod]
         public String GetBookDescription(User p_user, int p_isbn)
         {
             if (!Library.IsConnected(p_user))
                 return null;

             foreach (Book t_book in Library.a_books)
                 if (t_book.ISBN == p_isbn)
                     return t_book.ToString();

             return null;
         }

         /// <summary>
         /// Add an commented on the designated Book (Only Subscriber can commant a Book, necessary to be connected)
         /// </summary>
         /// 
         /// <param name="p_subscriber">The subscriber who comment the Book</param>
         /// <param name="p_isbn">The isbn of the book to comment</param>
         /// <param name="p_description">The description of the comment</param>
         [WebMethod]
         public void CommentBook(Subscriber p_subscriber, int p_isbn, String p_description)
         {
             for (int t_index = 0; t_index < Library.a_books.Count; t_index++)
                 if (Library.a_books[t_index].ISBN == p_isbn)
                 {
                     Library.a_books[t_index].Comment(p_subscriber, p_description);
                 }
         }
     }
 }
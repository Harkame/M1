﻿namespace LibraryManager
 {
     using System;
     using System.Collections.Generic;
     using System.Web.Services;
     using System.Text;
    using System.ServiceModel;

    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]

    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    public class Service : WebService
     {
         public Service()
         {
         }

         /// <summary>
         /// Authentificate a User (Return an object and add it into the list of connected users)
         /// </summary>
         /// <param name="p_id">The ID of the Librarian</param> 
         /// <param name="p_password">The password of the Librarian</param>
         /// <returns>A object User designed by p_id and p_password, null if the authentification has failed</returns>
         [WebMethod]
         public User Authentificate(int p_id, String p_password)
         {
             if (p_password == null)
                 return null;

             foreach (Librarian t_librarian in Library.Librarians)
                 if (t_librarian.ID == p_id && t_librarian.Password.Equals(p_password))
                 {
                     Library.Connections.Add(t_librarian);
                     return t_librarian;
                 }

             foreach (Subscriber t_subscriber in Library.Subscribers)
                 if (t_subscriber.ID == p_id && t_subscriber.Password.Equals(p_password))
                 {
                     Library.Connections.Add(t_subscriber);
                     return t_subscriber;
                 }

             return null;
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
             if (p_password == null)
                 return null;

             foreach (Librarian t_librarian in Library.Librarians)
                 if (t_librarian.ID == p_id && t_librarian.Password.Equals(p_password))
                 {
                     Library.Connections.Add(t_librarian);
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
             if (p_password == null)
                 return null;

             foreach (Subscriber t_subscriber in Library.Subscribers)
                 if (t_subscriber.ID == p_id && t_subscriber.Password.Equals(p_password))
                 {
                     Library.Connections.Add(t_subscriber);
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
             if(Library.IsValid(p_user))
                 Library.Connections.Remove(p_user);
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
             if (Library.IsValid(p_User))
                 foreach (Book t_book in Library.Books)
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
             if (Library.IsValid(p_User))
             {
                 List<Book> t_books = new List<Book>();

                 foreach (Book t_book in Library.Books)
                     if (t_book.Author.Equals(p_author))
                         t_books.Add(t_book);

                 return t_books.ToArray();
             }
             else
                 return null;
         }

         /// <summary>
         /// Return all books in the Library
         /// </summary>
         /// <returns>Return an array of Book, all of the List of books in the Library</returns>
         [WebMethod]
         public String GetBooks(User p_user)
         {
             if (Library.IsValid(p_user))
             {
                 StringBuilder r_books = new StringBuilder();

                 foreach (Book t_book in Library.Books)
                 {
                     r_books.Append(t_book.ToString());
                     r_books.Append(Environment.NewLine);
                 }

                 return r_books.ToString();
             }
             else
                 return null;
         }

         /// <summary>
         /// Return all of the possible commands for each kind of User
         /// </summary>
         /// <param name="p_user">User for check if he is connected and get his type (Librarian or Subscriber)</param>
         /// <returns>Return an String who represent possible commands for each kind of User</returns>
         [WebMethod]
         public String GetCommands(User p_user)
         {
             if (!Library.IsValid(p_user))
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
         /// Return book description (ToString method)
         /// </summary>
         /// <param name="p_user">User to authentificate</param>
         /// <param name="p_isbn">ISBN of the book</param>
         /// <returns>An String who describe the book designated by p_isbn</returns>
         [WebMethod]
         public String GetBookDescription(User p_user, int p_isbn)
         {
             if (Library.IsValid(p_user))
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
         [WebMethod]
         public bool AddBook(User p_librarian, String p_title, String p_author, int p_isbn, int p_stock, String p_editor)
         {
             if (Library.IsValid(p_librarian) && (p_librarian.GetType().Name.Equals("Librarian")))
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
         [WebMethod]
         public bool CommentBook(User p_subscriber, int p_isbn, String p_description)
         {
             if (!Library.IsValid(p_subscriber) || (p_description == null) || (!p_subscriber.GetType().Name.Equals("Subscriber")))
                 return false;

             for (int t_index = 0; t_index < Library.Books.Count; t_index++)
                 if (Library.Books[t_index].ISBN == p_isbn)
                 {
                     Library.Books[t_index].Comment(p_subscriber, p_description);
                     return true;
                 }

             return false;
         }
     }
 }
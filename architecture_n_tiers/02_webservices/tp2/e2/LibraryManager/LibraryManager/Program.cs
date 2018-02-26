namespace LibraryManager
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    class Program
    {
        private static LibraryManagerServiceReference.ServiceSoapClient a_proxy;

        public static void Main(string[] args)
        {
            a_proxy = new LibraryManagerServiceReference.ServiceSoapClient();

            LibraryManagerServiceReference.Person t_user = null;

            while(t_user == null)
            {
                Console.Write("ID : ");

                int t_id = Convert.ToInt32(Console.ReadLine());

                Console.Write("Password : ");

                String t_password = Console.ReadLine();

                t_user = a_proxy.Authentificate(t_id, t_password);
            }

            Console.WriteLine("");

            Console.WriteLine("Authentification successful (" + t_user.ID + " as " + t_user.GetType().Name + ")");

            Console.WriteLine("");

            String t_commands = a_proxy.GetCommands(t_user);

            while (true)
            {
                Console.WriteLine(t_commands);

                Console.Write("Action : ");

                int t_action = Convert.ToInt32(Console.ReadLine());

                int t_isbn;
                String t_title;
                String t_author;
                int t_stock;
                String t_editor;
                String t_comment;
                LibraryManagerServiceReference.Book[] t_books;

                LibraryManagerServiceReference.Book t_book;

                switch (t_action)
                {
                    case 1:
                        Console.WriteLine(a_proxy.GetBooks());
                    break;

                    case 2:
                        Console.Write("ISDN : ");

                        t_isbn = Convert.ToInt32(Console.ReadLine());

                        t_book = a_proxy.SearchBookByISBN(t_isbn);

                        Console.WriteLine(a_proxy.GetBookDescription(t_book));

                    break;

                    case 3:
                        Console.Write("Author : ");

                        t_author = Console.ReadLine();

                        t_books = a_proxy.SearchBooksByAuthor(t_author);

                        Console.WriteLine(t_books.Length);

                        foreach (LibraryManagerServiceReference.Book t_book_iterator in t_books)
                            Console.WriteLine(a_proxy.GetBookDescription(t_book_iterator));

                    break;

                    case 4:
                        Console.Write("ISBN : ");

                        t_isbn = Convert.ToInt32(Console.ReadLine());

                        t_book = a_proxy.SearchBookByISBN(t_isbn);

                        Console.Write("Comment : ");

                        t_comment = Console.ReadLine();

                        a_proxy.CommentBook(t_book, t_user, t_comment);

                    break;
           

                    case 5:
                        Console.Write("Title : ");

                        t_title = Console.ReadLine();

                        Console.Write("Author : ");

                        t_author = Console.ReadLine();

                        Console.Write("ISBN : ");

                        t_isbn = Convert.ToInt32(Console.ReadLine());

                        Console.Write("Stock : ");

                        t_stock = Convert.ToInt32(Console.ReadLine());

                        Console.Write("Editor : ");

                        t_editor = Console.ReadLine();

                        if (a_proxy.AddBook(t_user, t_title, t_author, t_isbn, t_stock, t_editor))
                            Console.WriteLine("Book added");
                        else
                            Console.WriteLine("Fail to add book");
                    break;

                    case 6:
                        goto end_of_loop;
                }
            }

            end_of_loop: { }

            a_proxy.Disconnect(t_user);

            a_proxy.Close();
        }
    }
}

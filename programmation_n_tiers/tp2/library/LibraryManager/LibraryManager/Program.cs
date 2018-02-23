using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibraryManager
{
    class Program
    {
        private static LibraryManagerServiceReference.ServiceSoapClient a_proxy;

        static void Main(string[] args)
        {
            a_proxy = new LibraryManagerServiceReference.ServiceSoapClient();

            LibraryManagerServiceReference.Subscriber t_subcriber = null;

            while (t_subcriber == null)
            {
                Console.Write("ID : ");

                int t_id = Convert.ToInt32(Console.ReadLine());

                Console.Write("Password : ");

                String t_password = Console.ReadLine();

                t_subcriber = a_proxy.Authentificate(t_id, t_password);
            }

            Console.WriteLine("");

            Console.WriteLine("Authentification successful (" + t_subcriber.ID + ")");

            Console.WriteLine("");

            w:while (true)
            {
                Console.WriteLine();

                Console.WriteLine("Action :");
                Console.WriteLine("[0] : Search book by ISDN");
                Console.WriteLine("[1] : Search book by Author");
                Console.WriteLine("[2] : Comment book");
                Console.WriteLine("[3] : Exit");

                Console.Write("Action : ");

                int t_action = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine();

                int t_isdn;
                String t_author;
                LibraryManagerServiceReference.Book t_book;
                LibraryManagerServiceReference.Book[] t_books;
                String t_comment;

                switch (t_action)
                {
                    case 0:
                        Console.Write("ISDN : ");

                        t_isdn = Convert.ToInt32(Console.ReadLine());

                        t_book = a_proxy.SearchBookByISDN(t_isdn);

                        Console.WriteLine(a_proxy.GetBookDescription(t_book));

                        break;

                    case 1:
                        Console.Write("Author : ");

                        t_author = Console.ReadLine();

                        t_books = a_proxy.SearchBooksByAuthor(t_author);

                        Console.WriteLine(t_books.Length);

                        foreach (LibraryManagerServiceReference.Book t_book_iterator in t_books)
                            Console.WriteLine(a_proxy.GetBookDescription(t_book_iterator));

                        break;

                    case 2:
                        Console.Write("ISDN : ");

                        t_isdn = Convert.ToInt32(Console.ReadLine());

                        t_book = a_proxy.SearchBookByISDN(t_isdn);

                        Console.Write("Comment : ");

                        t_comment = Console.ReadLine();

                        a_proxy.CommentBook(t_book, t_subcriber, t_comment);

                        break;

                    case 3:
                        goto end_of_loop;
                }
            }

            end_of_loop: {}

            a_proxy.Close();
        }
    }
}

namespace SubscriberClient
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using LibraryManager.LibraryManagerServiceReference;

    class Program
    {
        private static ServiceSoapClient a_proxy;

        public static void Main(string[] args)
        {
            a_proxy = new ServiceSoapClient();

            Console.WriteLine("[Subscriber client]");

            Subscriber t_subscriber = null;

            while(t_subscriber == null)
            {
                Console.Write("ID : ");

                int t_id = Convert.ToInt32(Console.ReadLine());

                Console.Write("Password : ");

                String t_password = Console.ReadLine();

                t_subscriber = a_proxy.AuthentificateAsSubscriber(t_id, t_password);
            }

            Console.WriteLine("");

            Console.WriteLine("Authentification successfull");

            Console.WriteLine("");

            String t_commands = a_proxy.GetCommands(t_subscriber);

            while (true)
            {
                Console.WriteLine(t_commands);

                Console.Write("Action : ");

                int t_action = Convert.ToInt32(Console.ReadLine());

                /*
                 * All the tempory variables who can be necessary
                 */
                int t_isbn;

                String t_author;
                String t_comment;

                Book[] t_books;

                switch (t_action)
                {
                    case 1:
                        Console.WriteLine(a_proxy.GetBooks(t_subscriber));
                    break;

                    case 2:
                        Console.Write("ISBN : ");

                        t_isbn = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine(a_proxy.GetBookDescription(t_subscriber, t_isbn));

                    break;

                    case 3:
                        Console.Write("Author : ");

                        t_author = Console.ReadLine();

                        t_books = a_proxy.SearchBooksByAuthor(t_subscriber, t_author);

                        Console.WriteLine(t_books.Length);

                        foreach (Book t_book_iterator in t_books)
                            Console.WriteLine(a_proxy.GetBookDescription(t_subscriber, t_book_iterator.ISBN));

                    break;

                    case 4:
                        Console.Write("ISBN : ");

                        t_isbn = Convert.ToInt32(Console.ReadLine());

                        Console.Write("Comment : ");

                        t_comment = Console.ReadLine();

                        a_proxy.CommentBook(t_subscriber, t_isbn, t_comment);

                    break;

                    case 5:
                        goto end_of_loop;
                }
            }

            end_of_loop: { } //To quit the loop

            a_proxy.Disconnect(t_subscriber);

            a_proxy.Close();
        }
    }
}

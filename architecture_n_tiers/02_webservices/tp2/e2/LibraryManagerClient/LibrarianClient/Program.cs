namespace LibrarianClient
{
    using System;
    using LibraryManagerServiceReference;

    class Program
    {
        private static ServiceSoapClient a_proxy;

        public static void Main(string[] args)
        {
            a_proxy = new ServiceSoapClient();

            Console.WriteLine("[Librarian client]");

            User t_librarian = null;

            while (t_librarian == null)
            {
                Console.Write("ID : ");

                int t_id = Convert.ToInt32(Console.ReadLine());

                Console.Write("Password : ");

                String t_password = Console.ReadLine();

                t_librarian = a_proxy.Authentificate(t_id, t_password);
            }

            Console.WriteLine("");

            Console.WriteLine("Authentification successfull");

            Console.WriteLine("");

            String t_commands = a_proxy.GetCommands(t_librarian);

            /*
             * All the tempory variables who can be necessary
             */
            int t_isbn;
            int t_stock;

            String t_editor;
            String t_author;
            String t_title;

            Book[] t_books;

            while (true)
            {
                Console.WriteLine(t_commands);

                Console.Write("Action : ");

                int t_action = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("");

                switch (t_action)
                {
                    case 1:
                        Console.WriteLine(a_proxy.GetBooks(t_librarian));
                        break;

                    case 2:
                        Console.Write("ISBN : ");

                        t_isbn = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine(a_proxy.GetBookDescription(t_librarian, t_isbn));

                        break;

                    case 3:
                        Console.Write("Author : ");

                        t_author = Console.ReadLine();

                        Console.WriteLine("");

                        t_books = a_proxy.SearchBooksByAuthor(t_librarian, t_author);

                        Console.WriteLine("[" + t_books.Length + "]");

                        foreach (Book t_book_iterator in t_books)
                            Console.WriteLine(a_proxy.GetBookDescription(t_librarian, t_book_iterator.ISBN));

                        break;

                    case 4:
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

                        Console.WriteLine("");

                        if (a_proxy.AddBook(t_librarian, t_title, t_author, t_isbn, t_stock, t_editor))
                            Console.WriteLine("Book added");
                        else
                            Console.WriteLine("Fail to add book");
                        break;

                    case 5:
                        goto end_of_loop;
                }
            }

            end_of_loop: { } //To quit the loop

            a_proxy.Disconnect(t_librarian);

            a_proxy.Close();
        }
    }
}

namespace TestClient
{
    using System;
    using LibraryTest.LibraryManagerServiceReference;

    class Program
    {
        private static ServiceSoapClient a_proxy;

        static void Main(string[] args)
        {
            a_proxy = new ServiceSoapClient();

            Librarian t_librarian = new Librarian();

            Subscriber t_subscriber = new Subscriber();

            Console.WriteLine("Add book, unauthentificated");

            Console.WriteLine(a_proxy.AddBook(t_librarian, "title_test", "author_test", 42, 42, "editor_test"));

            Console.WriteLine("Comment book, unauthentificated");

            Console.WriteLine(a_proxy.CommentBook(t_subscriber, 0, "comment"));

            Console.WriteLine("Add book, subscriber");

            Console.WriteLine(a_proxy.AddBook(t_subscriber, "title_test", "author_test", 42, 42, "editor_test"));

            Console.WriteLine("Comment book, librarian");

            Console.WriteLine(a_proxy.CommentBook(t_librarian, 0, "comment"));

            Console.WriteLine("Please, press enter to continue");

            Console.ReadLine();

            a_proxy.Close();
        }
    }
}

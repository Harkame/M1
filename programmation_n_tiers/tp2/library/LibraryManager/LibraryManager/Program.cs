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

            Console.WriteLine("Authentification successful");

            Console.WriteLine("Welcome " + t_subcriber.a_id);

            LibraryManagerServiceReference.Book t_book = a_proxy.SearchBookByISDN(0);

            Console.WriteLine(a_proxy.GetBookDescription(t_book));

            a_proxy.CommentBook(t_book, t_subcriber, "ok");

            t_book = a_proxy.SearchBookByISDN(0);

            Console.WriteLine(a_proxy.GetBookDescription(t_book));

            Console.WriteLine("Please, press enter to continue");

            Console.ReadLine();

            a_proxy.Close();
        }
    }
}

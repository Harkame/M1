using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Share;

namespace ConsoleApplication3
{
    class Program
    {
        private static LibraryWebServiceReference.LibraryWebServiceSoapClient a_proxy;

        static void Main(string[] args)
        {

            Activator.GetObject(typeof(ILibrary), "");

            a_proxy = new LibraryWebServiceReference.LibraryWebServiceSoapClient();

            Console.Out.WriteLine("Id : ");

            //int t_id = Convert.ToInt32(Console.ReadLine());

            Console.Out.WriteLine("Password : ");

            //String t_password = Console.ReadLine();

            //bool b = a_proxy.Authentification(t_id, t_password);

            try
            {
                String s = a_proxy.test();
                Console.WriteLine(s);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.ToString());
                Console.WriteLine("totrotoo");
            }

            //Console.Out.WriteLine(b);

            Console.ReadLine();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    class Program
    {
        private static TP2.ServiceReference1.DateWebServiceSoapClient proxy;

        static void Main(string[] args)
        {
            proxy = new TP2.ServiceReference1.DateWebServiceSoapClient();

            Console.WriteLine(proxy.getDate());

            Console.ReadLine();
        }
    }
}
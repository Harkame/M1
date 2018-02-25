using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DateTimeManager
{
    class Program
    {
        private static DateTimeServiceReference.ServiceSoapClient a_proxy;

        static void Main(string[] args)
        {
            a_proxy = new DateTimeServiceReference.ServiceSoapClient();

            Console.WriteLine("Date : " + a_proxy.DateTimeNow());

            Console.WriteLine("Please, press enter to continue");

            Console.ReadLine();

            a_proxy.Close();
        }
    }
}

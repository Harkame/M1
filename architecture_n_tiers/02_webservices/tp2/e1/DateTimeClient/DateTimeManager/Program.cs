namespace DateTimeClient
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using DateTimeManager.DateTimeServiceReference;

    class Program
    {
        private static ServiceSoapClient a_proxy;

        static void Main(string[] args)
        {
            a_proxy = new ServiceSoapClient();

            Console.WriteLine("Date : " + a_proxy.DateTimeNow());

            Console.WriteLine("Please, press enter to continue");

            Console.ReadLine();

            a_proxy.Close();
        }
    }
}

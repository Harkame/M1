using System;
using System.ServiceModel;

namespace Host
{
    class Program
    {
        static void Main(string[] args)
        {
            using (ServiceHost host = new ServiceHost(typeof(Foobar_service.Foo)))
            {
                host.Open();
                Console.WriteLine("The service is ready.");
                Console.WriteLine("Please, press enter to continue");
                Console.ReadLine();

                host.Close();
            }
        }
    }
}

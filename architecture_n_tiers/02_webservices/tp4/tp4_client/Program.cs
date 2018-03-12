using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.ServiceModel.Description;
using server;

namespace host
{
    class Program
    {

        static void Main(string[] args)
        {
            try
            {
                ServiceHost service_host = new ServiceHost(typeof(CompositeType));

                service_host.Open();

                Console.WriteLine("[Service openened]");

                Console.WriteLine("Please, press enter to continue");

                Console.ReadLine();

                service_host.Close();
            }
            catch ( TimeoutException timeProblem )
            {
                Console.WriteLine(timeProblem.Message);
                Console.ReadLine();
            }
            catch ( CommunicationException commProblem )
            {
                Console.WriteLine(commProblem.Message);
                Console.ReadLine();
            }
        }
    }
}

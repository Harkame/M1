using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;

namespace client
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceReference1.IService1 serviceProxy = new ChannelFactory<ServiceReference1.IService1>("WSHttpBinding_IService1").CreateChannel();
            Console.WriteLine(serviceProxy.GetData(1));
            Console.ReadLine();
        }
    }
}
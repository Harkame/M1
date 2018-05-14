using Foobar_service;
using System;
using System.ServiceModel;

namespace Client1
{
    class Program
    {
        static void Main(string[] args)
        {
            ExempleClean();

            //ExempleProf();
        }

        public static void ExempleClean()
        {
            ChannelFactory<IFoo> myChannelFactory = new ChannelFactory<IFoo>("Foo");
            IFoo proxy = myChannelFactory.CreateChannel();
            IFoo proxybis = myChannelFactory.CreateChannel();

            Bar bar = proxy.GetBar();
            Console.WriteLine("bar.bar" + bar.bar);//a

            bar.bar = 12;
            Console.WriteLine("bar.bar" + bar.bar);//b

            Bar barbis = proxy.GetBar();
            Console.WriteLine(barbis.bar);//c

            barbis = proxybis.GetBar();

            proxy.SetBar(new Bar(3));
            proxybis.SetBar(new Bar(3));
            bar = proxy.GetBar();
            Console.WriteLine("bar.bar:" + bar.bar);//d
            Console.WriteLine("barbis.bar:" + barbis.bar);//e

            Console.ReadLine();
        }

        public static void ExempleProf()
        {
            ChannelFactory<IFoo> myChannelFactory = new ChannelFactory<IFoo>("Foo");
            IFoo proxy = myChannelFactory.CreateChannel();

            Bar bar = proxy.GetBar();
            Console.WriteLine("bar.bar" + bar.bar);//a

            bar.bar = 12;
            Console.WriteLine("bar.bar" + bar.bar);//b

            IFoo proxybis = myChannelFactory.CreateChannel();
            Bar barbis = proxy.GetBar();
            Console.WriteLine(barbis.bar);//c

            proxy.SetBar(new Bar(3));
            barbis = proxybis.GetBar();
            bar = proxy.GetBar();
            Console.WriteLine("bar.bar:" + bar.bar);//d
            Console.WriteLine("barbis.bar:" + barbis.bar);//e

            Console.ReadLine();
        }
    }
}

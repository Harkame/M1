using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Foobarservice;
using System.ServiceModel;

namespace ClientFooBarServiceConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            //ChannelFactory<IFoo> myChannelFactory = newChannelFactory<IFoo>(”configClient”);
            //IFoo proxy  =myChannelFactory.CreateChannel();
            //Barba r =proxy.GetBar();
            Bar 
            Console.WriteLine(”bar.bar”+bar.bar);//a
            bar.bar=12;
            Console.WriteLine(”bar.bar”+bar.bar);//b
            IFooproxybis=myChannelFactory.CreateChannel();
            Barbarbis=proxy.GetBar();
            Console.WriteLine(barbis.bar);//c
            proxy.SetBar(new Bar(3));
            barbis = proxybis.GetBar();
            bar = proxy.GetBar();
            Console.WriteLine(”bar.bar:”+bar.bar);//d
            Console.WriteLine(”barbis.bar:”+barbis.bar);//e
            Console.ReadLine();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using ConsoleApplication1.GlobalWeather;

namespace ConsoleApplication1
{
    class Program
    {
        private static GlobalWeatherSoapClient proxy;

        static void Main(string[] args)
        {
            Console.WriteLine("start");
            proxy = new GlobalWeatherSoapClient();
            Console.WriteLine(proxy.GetCitiesByCountry("france"));
            Console.WriteLine(proxy.GetWeather("Montpellier", "france"));

            Console.ReadLine();
        }
    }
}

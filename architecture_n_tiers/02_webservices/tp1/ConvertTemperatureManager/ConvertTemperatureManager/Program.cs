namespace ConvertTemperatureManager
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    class Program
    {
        private static ConvertTemperatureServiceReference.ConvertTemperatureSoapClient a_proxy;

        static void Main(string[] args)
        {
            a_proxy = new ConvertTemperatureServiceReference.ConvertTemperatureSoapClient();

            Console.WriteLine("Convertor Celsius -> Kelvin");

            Console.Write("Temperature (Celsius) (Example : 25,9) : ");

            double t_temperature_to_convert = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine();

            Console.WriteLine(a_proxy.ConvertTemp(t_temperature_to_convert, ConvertTemperatureServiceReference.TemperatureUnit.degreeCelsius, ConvertTemperatureServiceReference.TemperatureUnit.kelvin) + " kelvin");

            Console.WriteLine(Environment.NewLine + "Please, press enter to continue");

            Console.ReadLine();

            a_proxy.Close();
        }
    }
}

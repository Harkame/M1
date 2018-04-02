using System;
using System.ServiceModel;

namespace RecipeHost
{
    class Program
    {
        static void Main(string[] args)
        {
            using (ServiceHost t_host = new ServiceHost(typeof(RecipeService.RecipeService)))
            {
                t_host.Open();

                Console.WriteLine("Press enter to stop hosting");
                Console.ReadLine();

                t_host.Close();
            }
        }
    }
}

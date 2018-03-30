namespace RecipeHost
{
    using System;
    using System.ServiceModel;
    using System.ServiceModel.Description;
    using RecipeShare;

    public class Program
    {
        public static void Main(string[] args)
        {
            Uri baseAddress = new Uri("http://localhost:9898/RecipeService");

            using (ServiceHost host = new ServiceHost(typeof(Recipe), baseAddress))
            {
                host.Open();

                Console.WriteLine("The service is ready at {0}", baseAddress);
                Console.WriteLine("Press <Enter> to stop the service.");
                Console.ReadLine();

                // Close the ServiceHost.
                host.Close();
            }
        }
    }
}

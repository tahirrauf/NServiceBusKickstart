using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NsbMessagesLibrary;
using NServiceBus;

namespace NsbSubscriber
{
    class Program
    {
        static void Main(string[] args)
        {
            BusConfiguration busConfigurationObject = new BusConfiguration();
            busConfigurationObject.EndpointName("Nsb.NsbSubscriber");
            busConfigurationObject.UseSerialization<JsonSerializer>();
            busConfigurationObject.EnableInstallers();
            busConfigurationObject.UsePersistence<InMemoryPersistence>();

            using (IBus bus = Bus.Create(busConfigurationObject).Start())
            {
                Console.WriteLine("Press Any Key to Exit");
                Console.ReadKey();
            }
        }

       
    }


}

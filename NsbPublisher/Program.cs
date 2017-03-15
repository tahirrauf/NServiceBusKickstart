using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NServiceBus;
using NsbMessagesLibrary;

namespace NsbPublisher
{
    class Program
    {
        static void Main(string[] args)
        {
            BusConfiguration busConfigurationObject = new BusConfiguration();
            busConfigurationObject.EndpointName("Nsb.NsbPublisher");
            busConfigurationObject.UseSerialization<JsonSerializer>();
            busConfigurationObject.UsePersistence<InMemoryPersistence>();
            busConfigurationObject.EnableInstallers();

            using (IBus bus = Bus.Create(busConfigurationObject).Start())
            {
                Console.WriteLine("Press Enter key to send message");
                Console.WriteLine("Press Any Key to send message");

                while(true)
                {
                    ConsoleKeyInfo key = Console.ReadKey();
                    Console.WriteLine();

                    if(key.Key != ConsoleKey.Enter)
                    {break;}

                    OrderMessage placeOrder = new OrderMessage { OrderDescription = "Test", ID = Guid.NewGuid() };
                    bus.Publish(placeOrder);

                    Console.WriteLine("Sent with Id = " + placeOrder.ID.ToString());
                }
            }
        }
    }
}

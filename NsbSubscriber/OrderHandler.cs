using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NsbMessagesLibrary;
using NServiceBus;

namespace NsbSubscriber
{
    public class OrderHandler : IHandleMessages<OrderMessage>
    {
        void IHandleMessages<OrderMessage>.Handle(OrderMessage om)
        {
            Console.WriteLine("Handling: OrderPlaced for OrderID = " + om.ID);
        }

    }
}

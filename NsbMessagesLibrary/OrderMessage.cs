using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NServiceBus.Config;
using NServiceBus.Config.ConfigurationSource;
using NServiceBus;
using System.Configuration;

namespace NsbMessagesLibrary
{
    public class OrderMessage: IEvent
    {
        public Guid ID { get; set; }
        public string OrderDescription { get; set; }
    }

    class ConfigErrorQueue : IProvideConfiguration<MessageForwardingInCaseOfFaultConfig>
    {
        public MessageForwardingInCaseOfFaultConfig GetConfiguration()
        {
            return new MessageForwardingInCaseOfFaultConfig
            {
                ErrorQueue = "error"
            };
        }
    }
}

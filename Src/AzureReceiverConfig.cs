using System;
using System.Runtime.Serialization;
using Prosa.Log4View.Configuration;
using Prosa.Log4View.Extensibility;

namespace RedBear.Log4View.AzureServiceBus
{
    [DataContract, Serializable]
    internal class AzureReceiverConfig : ReceiverConfig, ICustomHasFileName
    {
        public AzureReceiverConfig() : base("Azure Service Bus Receiver") {}

        [DataMember]
        public string Topic { get; set; }

        [DataMember]
        public string Prefix { get; set; }

        [DataMember]
        public string ConnectionString { get; set; }

        public override string ReceiverTypeId => AzureReceiverFactory.TypeId;

        public override string Description => "Azure Service Bus Receiver: " + Topic;

        public string FileName { get; set; }
    }
}
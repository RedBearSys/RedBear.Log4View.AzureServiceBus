using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Drawing;
using Prosa.Log4View.Configuration;
using Prosa.Log4View.Frameworks;
using Prosa.Log4View.Receiver;
using RedBear.Log4View.AzureServiceBus.Properties;

namespace RedBear.Log4View.AzureServiceBus
{
    [Export(typeof (IReceiverFactory))]
    public class AzureReceiverFactory : IReceiverFactory
    {
        internal const string TypeId = "RedBear.Log4View.AzureServiceBus";

        #region IReceiverFactory Members
        public string ReceiverTypeId => TypeId;

        public string Name => "Azure Service Bus Receiver";

        public Bitmap SmallBitmap => Resources.ServiceBus16;

        public Bitmap LargeBitmap => Resources.ServiceBus128;

        public IEnumerable<Type> ConfigType => new[] { typeof(AzureReceiverConfig) };

        public string HelpKeyword => "";

        public ILogReceiver CreateReceiver(ReceiverConfig config) {
            return new AzureReceiver(this, (AzureReceiverConfig)config);
        }

        public ReceiverConfig CreateReceiverDefinition() {
            return new AzureReceiverConfig();
        }

        public IReceiverControl CreateReceiverControl(ReceiverConfig receiver, IReceiverForm receiverForm) {
            return new AzureConfigControl((AzureReceiverConfig)receiver, receiverForm);
        }

        public ReceiverConfig CreateReceiverConfig(SourceConfig source, Log4ViewAppenderNode appender) {
            return null;
        }
        #endregion
    }
}
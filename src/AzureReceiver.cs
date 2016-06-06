using System;
using System.Timers;
using Microsoft.ServiceBus;
using Microsoft.ServiceBus.Messaging;
using Newtonsoft.Json;
using Prosa.Log4View.Level;
using Prosa.Log4View.Message;
using Prosa.Log4View.Receiver;
using Prosa.Log4View.Utils.Logging;

namespace RedBear.Log4View.AzureServiceBus
{
    internal class AzureReceiver : LogReceiver
    {
        private readonly AzureReceiverConfig _config;
        private SubscriptionClient _client;
        private readonly Timer _timer = new Timer();

        public AzureReceiver(IReceiverFactory factory, AzureReceiverConfig config) : base(factory, config)
        {
            _config = config;

            _timer.AutoReset = true;
            _timer.Interval = 65000;
            _timer.Elapsed += _timer_Elapsed;
            _timer.Start();

            // Important: This tells Log4View, that this receiver is ready to run.
            IsInitiated = true;
        }

        private void _timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (_client == null || _client.IsClosed)
            {
                Receive();
            }
        }

        public override void Start() {
            ReceiveMessages = true;
            Receive();
        }

        public void Receive()
        {
            try
            {
                var namespaceManager = NamespaceManager.CreateFromConnectionString(_config.ConnectionString);

                if (
                    !namespaceManager.SubscriptionExists(_config.Topic,
                        $"{Environment.UserDomainName}-{Environment.MachineName}-{Environment.UserName}"))
                {
                    var description = new SubscriptionDescription(_config.Topic,
                        $"{Environment.UserDomainName}-{Environment.MachineName}-{Environment.UserName}")
                    {
                        AutoDeleteOnIdle = TimeSpan.FromMinutes(15)
                    };
                    namespaceManager.CreateSubscription(description);
                }

                _client = SubscriptionClient.CreateFromConnectionString(_config.ConnectionString, _config.Topic,
                    $"{Environment.UserDomainName}-{Environment.MachineName}-{Environment.UserName}");

                var options = new OnMessageOptions();
                options.ExceptionReceived += Options_ExceptionReceived;

                _client.OnMessage(message =>
                {
                    var json = message.GetBody<string>();
                    var logEvent = JsonConvert.DeserializeObject<AzureLogEvent>(json);

                    if (ReceiveMessages)
                    {
                        var msg = new LogMessage(this)
                        {
                            Message = logEvent.Message,
                            Level = Levels.Get(logEvent.Level),
                            Logger = !string.IsNullOrEmpty(_config.Prefix)
                                ? _config.Prefix + logEvent.Logger
                                : logEvent.Logger,
                            Exception = logEvent.Exception,
                            StackTrace = logEvent.StackTrace,
                            LogSource = logEvent.LogSource,
                            OriginalTime = logEvent.OriginalTime,
                            Key = logEvent.Key,
                            Host = logEvent.Host
                        };
                        var messages = new MessageBlock { msg };

                        AddNewMessages(messages);
                    }
                }, options);
            }
            catch (TimeoutException ex)
            {
                var message =
                    $@"
There's a problem communicating with Azure Service Bus.

Check your connection string, internet access, firewalls and any anti-virus or anti-malware applications that might be blocking access.

Exception:

{ex
                        .Message}
";
                LogManager.GetLogger("AzureReceiver").Warn(message.Trim());
            }
            catch (Exception ex)
            {
                LogManager.GetLogger("AzureReceiver").Error(ex);
            }
        }

        private void Options_ExceptionReceived(object sender, ExceptionReceivedEventArgs e)
        {
            if (_client != null && !_client.IsClosed)
            {
                LogManager.GetLogger("AzureReceiver").Error(e.Exception);
            }
        }

        public override void Dispose() {
            base.Dispose();

            _timer.Stop();
            _client?.Close();
        }
    }
}
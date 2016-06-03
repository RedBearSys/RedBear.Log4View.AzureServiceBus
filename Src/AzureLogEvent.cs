using System;

namespace RedBear.Log4View.AzureServiceBus
{
    public class AzureLogEvent
    {
        public string Message { get; set; }
        public string Level { get; set; }
        public string Logger { get; set; }
        public string Exception { get; set; }
        public string StackTrace { get; set; }
        public string LogSource { get; set; }
        public DateTime OriginalTime { get; set; }
        public int Key { get; set; }
        public string Host { get; set; }
    }
}

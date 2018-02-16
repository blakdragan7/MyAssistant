using System;
using Microsoft.WindowsAzure.MobileServices;
using Newtonsoft.Json;

namespace MyAssistant
{
    class ListTable
    {
        [JsonProperty(PropertyName = "id")]
        public string ID { get; set; }
        public string UserID { get; set; }
        public string EntryText { get; set; }
        public string EventType { get; set; }

        [Version]
        public string Version { get; set; }
    }
}

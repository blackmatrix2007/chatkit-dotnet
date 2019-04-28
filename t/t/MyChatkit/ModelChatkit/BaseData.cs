using System;
using Newtonsoft.Json;

namespace t.MyChatkit.ModelChatkit
{
    public class BaseData
    {
        [JsonProperty("event_name")]
        public string event_name { get; set; }
    }
}

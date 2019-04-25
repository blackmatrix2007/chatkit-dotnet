using System;
using Newtonsoft.Json;

namespace t.MyChatkit.ModelChatkit
{
    public class BaseContent<T>
    {
        [JsonProperty("event_name")]
        public string event_name { get; set; }

        [JsonProperty("data")]
        public T data { get; set; }
    }
}

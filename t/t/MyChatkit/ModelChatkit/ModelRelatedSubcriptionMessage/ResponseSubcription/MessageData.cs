using System;
using Newtonsoft.Json;

namespace t.MyChatkit.ModelChatkit.ModelRelatedSubcriptionMessage
{
    public class MessageData
    {
        [JsonProperty("created_at")]
        public string created_at { get; set; }

        [JsonProperty("id")]
        public int id { get; set; }

        [JsonProperty("room_id")]
        public int room_id { get; set; }

        [JsonProperty("text")]
        public string text { get; set; }

        [JsonProperty("updated_at")]
        public string updated_at { get; set; }

        [JsonProperty("user_id")]
        public string user_id { get; set; }
    }
}

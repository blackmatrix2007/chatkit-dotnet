using System;
using Newtonsoft.Json;

namespace t.MyChatkit.ModelChatkit.ModelRelatedSubcriptionStateOnlineOffline
{
    public class PresenceData
    {
        //[1,"",{},{"event_name":"presence_state","timestamp":"2019-04-25T22:51:42Z","data":{"state":"online"}}]
        [JsonIgnore]
        public string user_id { get; set; }

        [JsonProperty("state")]
        public string state { get; set; }
    }
}

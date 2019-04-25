using System;
using Newtonsoft.Json;

namespace t.MyChatkit.ModelChatkit.ModelRelatedSubcriptionRoom
{
    public class RoomData
    {
        [JsonProperty("current_user")]
        public User current_user { get; set; }

        [JsonProperty("rooms")]
        public Room[] rooms { get; set; }
          
    }
}


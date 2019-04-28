using System;
using Newtonsoft.Json;

namespace t.MyChatkit.ModelChatkit.ModelRelatedSubcriptionRoom
{
    public class RoomDetail
    {
        [JsonProperty("room")]
        public Room room { get; set; }
    }
}

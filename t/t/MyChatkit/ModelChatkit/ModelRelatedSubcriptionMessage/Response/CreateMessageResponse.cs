using System;
using Newtonsoft.Json;

namespace t.MyChatkit.ModelChatkit.ModelRelatedSubcriptionMessage.Request
{
    public class CreateMessageResponse : BaseResponse
    {
        [JsonProperty("message_id")]
        public long message_id { get; set; }
    }
}

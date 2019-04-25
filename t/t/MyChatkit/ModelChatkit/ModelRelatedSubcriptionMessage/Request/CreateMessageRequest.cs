using System;
using Newtonsoft.Json;

namespace t.MyChatkit.ModelChatkit.ModelRelatedSubcriptionMessage.Request
{
    public class CreateMessageRequest : BaseRequest
    {
        [JsonIgnore]
        public string roomId { get; set; }
    }
}

using System;
using Newtonsoft.Json;

namespace t.MyChatkit.ModelChatkit.ModelRelatedRooms.Request
{
    public class DeleteRoomRequest : BaseRequest
    {
        public string room_id { get; set; }
    }
}

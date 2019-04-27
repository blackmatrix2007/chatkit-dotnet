using System;
using Newtonsoft.Json;

namespace t.MyChatkit.ModelChatkit.ModelRelatedRooms.Request
{
    public class CreateRoomRequest : BaseRequest
    {
        //        A JSON object with the following keys:

        //    name(string|optional) : Represents the name with which the room is identified.A room name must not be longer than 40 characters and can only contain lowercase letters, numbers, underscores and hyphens.
        //    private (boolean|optional): Indicates if a room should be private or public. By default, it is public.
        //    custom_data(object|optional) : Custom data that will be associated with the Room.
        //    user_ids(array|optional): If you wish to add users to the room at the point of creation, you may provide their user IDs.

        //Note that leaving the request body empty means that a room will be created with an automatically assigned name and no users.

        [JsonProperty("name")]
        public string name { get; set; }

        [JsonProperty("private")]
        public string isPrivate { get; set; }

        [JsonProperty("member_user_ids")]
        public string[] member_user_ids { get; set; }

        [JsonProperty("custom_data")]
        public CustomRoomData custom_data { get; set; }

        [JsonProperty("user_ids")]
        public string[] user_ids { get; set; }

    }
}

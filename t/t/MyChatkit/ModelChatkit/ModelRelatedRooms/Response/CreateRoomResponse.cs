using System;
using Newtonsoft.Json;

namespace t.MyChatkit.ModelChatkit.ModelRelatedRooms.Response
{
    public class CreateRoomResponse : BaseResponse
    {
        //     A JSON object containing the following keys:

        // id(string) : A unique id for the room that was created.
        // created_by_id(string): User id that created the room.
        //name(string): Room name.
        // private (boolean): Indicates if the room is private or public.
        // custom_data(object|optional) : Custom data that was associated with the Room.
        // created_at(string): Timestamp of when the room was created.
        //updated_at(string): Timestamp of when the room was updated.
        [JsonProperty("id")]
        public string id { get; set; }

        [JsonProperty("created_by_id")]
        public string created_by_id { get; set; }

        [JsonProperty("name")]
        public string name { get; set; }

        [JsonProperty("custom_data")]
        public CustomRoomData custom_data { get; set; }

        [JsonProperty("created_at")]
        public string created_at { get; set; }

        [JsonProperty("updated_at")]
        public string updated_at { get; set; }
    }
}

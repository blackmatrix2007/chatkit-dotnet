using System;
using Newtonsoft.Json;

namespace t.MyChatkit.ModelChatkit.ModelRelatedSubcriptionRoom
{
    public class Room
    {
        /*
            {
        "created_at":"2019-03-29T03:33:46Z",
        "created_by_id":"sondh",
        "id":"19564764",
        "member_user_ids":null,
        "name":"b5a1206f1a6df9f60dd852e268ba9cbf",
        "private":true,
        "updated_at":"2019-03-29T03:33:46Z"
         }*/

        [JsonProperty("created_by_id")]
        public string created_by_id { get; set; }

        [JsonProperty("id")]
        public string id { get; set; }

        [JsonProperty("member_user_ids")]
        public string[] member_user_ids { get; set; }

        [JsonProperty("name")]
        public string name { get; set; }

        [JsonProperty("private")]
        public bool isPrivate { get; set; }

        [JsonProperty("created_at")]
        public string created_at { get; set; }

        [JsonProperty("updated_at")]
        public string updated_at { get; set; }
    }
}

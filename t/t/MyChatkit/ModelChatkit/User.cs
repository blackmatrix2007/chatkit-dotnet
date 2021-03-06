﻿using System;
using System.ComponentModel;
using Newtonsoft.Json;

namespace t.MyChatkit.ModelChatkit
{
    public class User
    {

        [JsonProperty("id")]
        public string id { get; set; }

        [JsonProperty("name")]
        public string name { get; set; }

        [JsonProperty("created_at")]
        public string created_at { get; set; }

        [JsonProperty("updated_at")]
        public string updated_at { get; set; }

        [JsonIgnore]
        public string state { get; set; }
    }
}

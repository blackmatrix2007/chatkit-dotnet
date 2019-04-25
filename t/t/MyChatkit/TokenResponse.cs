using System;
using Newtonsoft.Json;

namespace t
{
    public class TokenResponse : BaseResponse
    {
        [JsonProperty("access_token")]
        public string access_token { get; set; }

        [JsonProperty("refresh_token")]
        public string refresh_token { get; set; }

        [JsonProperty("user_id")]
        public string user_id { get; set; }

        [JsonProperty("token_type")]
        public string token_type { get; set; }

        [JsonProperty("expires_in")]
        public int expires_in { get; set; }

    }
}


//{
//    "access_token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJleHAiOjE1NTQ0MTg2MjQsImlhdCI6MTU1NDMzMjIyNCwiaW5zdGFuY2UiOiJkNjEwMDkwNi01NzNlLTRiNDAtYjhjYS1jNTk5NWI1NzNjMWIiLCJpc3MiOiJhcGlfa2V5cy9kNzY0NWE5NC1hYmY2LTRmNDYtODliYS1kZTllYjM4NmY1NmYiLCJzdWIiOiJuZW9fYXRfaG90ZWxzbmcifQ.3UJokOS8Tvon2TXKoj_wbF5cv0CoqNqZ7G586p8Il1U",
//    "refresh_token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJleHAiOjE1NTQ1MDUwMjQsImlhdCI6MTU1NDMzMjIyNCwiaW5zdGFuY2UiOiJkNjEwMDkwNi01NzNlLTRiNDAtYjhjYS1jNTk5NWI1NzNjMWIiLCJpc3MiOiJhcGlfa2V5cy9kNzY0NWE5NC1hYmY2LTRmNDYtODliYS1kZTllYjM4NmY1NmYiLCJyZWZyZXNoIjp0cnVlLCJzdWIiOiJuZW9fYXRfaG90ZWxzbmcifQ.9Wiz0HUSwMH_k6aZ8UixNd0VLyLq7euS2UZ3KScMx48",
//    "user_id": "neo_at_hotelsng",
//    "token_type": "access_token",
//    "expires_in": 86400
//}
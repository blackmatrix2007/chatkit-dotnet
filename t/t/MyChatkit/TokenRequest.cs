using System;
namespace t
{
    public class TokenRequest : BaseRequest
    {//client_credentials
        public string grant_type
        {
            set
            {
                if (FormData.ContainsKey("grant_type"))
                {
                    FormData["FormData"] = value;
                }
                else
                {
                    FormData.Add("grant_type", value);
                }
            }
        }

        public string user_id
        {
            set
            {
                if (FormData.ContainsKey("user_id"))
                {
                    FormData["FormData"] = value;
                }
                else
                {
                    FormData.Add("user_id", value);
                }
            }
        }
    }
}

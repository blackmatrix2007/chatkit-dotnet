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
                    FormData["grant_type"] = value;
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
                    FormData["user_id"] = value;
                }
                else
                {
                    FormData.Add("user_id", value);
                }
            }
        }
    }
}

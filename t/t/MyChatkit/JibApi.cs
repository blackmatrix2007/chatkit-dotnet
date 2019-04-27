using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using t;
using t.MyChatkit.ModelChatkit;
using t.MyChatkit.ModelChatkit.ModelRelatedSubcriptionMessage.Request;
using t.MyChatkit.ModelChatkit.ModelRelatedUsers.Request;

[assembly: Xamarin.Forms.Dependency(typeof(JibApi))]
namespace t
{
    public class JibApi : IJibApi
    {

        string POSTTOKEN = string.Empty;

        public JibApi() {
            POSTTOKEN = string.Format("/services/chatkit_token_provider/v1/{0}/token", SubcriptionJib.instance_id);
        }

        public Task<TokenResponse> PostToken(TokenRequest request)
        {
            return PostExecute<TokenRequest, TokenResponse>(POSTTOKEN, request);
        }

        private string BuildQueryString(Dictionary<string, object> queryParameters)
        {
            if (!queryParameters.Any())
                return "";

            var builder = new StringBuilder("?");

            var separator = "";
            foreach (var kvp in queryParameters.Where(kvp => kvp.Value != null))
            {
                if (kvp.Value is string || kvp.Value is int)
                {
                    builder.AppendFormat("{0}{1}={2}", separator, WebUtility.UrlEncode(kvp.Key), WebUtility.UrlEncode(kvp.Value.ToString()));
                }
                else
                {
                    var properties = kvp.Value.GetType().GetTypeInfo().DeclaredProperties;
                    foreach (var item in properties)
                    {
                        var value = item.GetValue(kvp.Value, null);
                        if (value != null)
                        {
                            builder.AppendFormat("{0}{1}[{2}]={3}", separator, WebUtility.UrlEncode(kvp.Key), item.Name, WebUtility.UrlEncode(value.ToString()));
                        }
                    }
                }
                separator = "&";
            }

            return builder.ToString();
        }

        private void BuildAddtionalHeadersString(HttpRequestHeaders headers, Dictionary<string, object> additionalHeaders)
        {
            foreach (var item in additionalHeaders)
            {
                headers.Add(item.Key, item.Value.ToString());
            }
        }

        protected async Task<TResponse> PostExecute<TRequest, TResponse>(string uri, TRequest data, CancellationToken ct = default(CancellationToken)) where TRequest : BaseRequest where TResponse : BaseResponse
        {
            using (HttpClient client = new HttpClient())
            {
           
                var content = new StringContent(JsonConvert.SerializeObject(data.FormData), Encoding.UTF8, "application/json");

                BuildAddtionalHeadersString(client.DefaultRequestHeaders, data.Headers);


                HttpResponseMessage resposne = await client.PostAsync(new Uri(string.Format("https://{0}{1}", SubcriptionJib.DOMAIN, uri)), content);

                var jsonResponse = await resposne.Content.ReadAsStringAsync().ConfigureAwait(false);

                var dateTimeConverter = new IsoDateTimeConverter { DateTimeFormat = "yyyyMMdd" };

                var result = JsonConvert.DeserializeObject<TResponse>(jsonResponse, dateTimeConverter);

                return result;
            }
        }

        protected async Task<TResponse> GetExecute<TRequest, TResponse>(string uri, TRequest data, CancellationToken ct = default(CancellationToken)) where TRequest : BaseRequest where TResponse : BaseResponse
        {
            using (HttpClient client = new HttpClient())
            {

                var content = new StringContent(JsonConvert.SerializeObject(data.FormData), Encoding.UTF8, "application/json");

                BuildAddtionalHeadersString(client.DefaultRequestHeaders, data.Headers);


                HttpResponseMessage resposne = await client.GetAsync(new Uri(string.Format("https://{0}{1}", SubcriptionJib.DOMAIN, uri)));

                var jsonResponse = await resposne.Content.ReadAsStringAsync().ConfigureAwait(false);

                var dateTimeConverter = new IsoDateTimeConverter { DateTimeFormat = "yyyyMMdd" };

                var result = JsonConvert.DeserializeObject<TResponse>(jsonResponse, dateTimeConverter);

                return result;
            }
        }




        public Task<CreateMessageResponse> SendMessage(CreateMessageRequest request)
        {
            string SENDMESSAGE = string.Format("/services/chatkit/v2/{0}/rooms/{1}/messages", SubcriptionJib.instance_id, request.roomId);
            return PostExecute<CreateMessageRequest, CreateMessageResponse>(SENDMESSAGE, request);
        }

        public async Task<User[]> GetUsers(GetUsersRequest request)
        {
            //  https://us1.pusherplatform.io/services/chatkit/v3/d6100906-573e-4b40-b8ca-c5995b573c1b/users
            string GETUSERS = string.Format("/services/chatkit/v2/{0}/users", SubcriptionJib.instance_id);

            using (HttpClient client = new HttpClient())
            {

                var content = new StringContent(JsonConvert.SerializeObject(request.Headers), Encoding.UTF8, "application/json");

                BuildAddtionalHeadersString(client.DefaultRequestHeaders, request.Headers);


                HttpResponseMessage resposne = await client.GetAsync(new Uri(string.Format("https://{0}{1}", SubcriptionJib.DOMAIN, GETUSERS)));

                var jsonResponse = await resposne.Content.ReadAsStringAsync().ConfigureAwait(false);

                var dateTimeConverter = new IsoDateTimeConverter { DateTimeFormat = "yyyyMMdd" };

                var result = JsonConvert.DeserializeObject<User[]>(jsonResponse, dateTimeConverter);

                return result;
            }
        }

        public Task<User[]> CreateRoom(GetUsersRequest request)
        {
            throw new NotImplementedException();
        }
    }
}

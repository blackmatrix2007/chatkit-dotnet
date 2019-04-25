using System;
using System.IO;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using t;
using t.MyChatkit.ModelChatkit.ModelRelatedSubcriptionRoom;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

[assembly: Xamarin.Forms.Dependency(typeof(SubcriptionJib))]
namespace t
{
    public partial class SubcriptionJib : ISubcriptionJib , IDisposable
    {
        string instance = "xxx";
        public static string DOMAIN = string.Empty;
        public static string instance_id = string.Empty;
        string region = string.Empty;
        string sdkversion = "1.2.0";
        string heatbeat_interval = "60";
        string sdk_platform = Device.RuntimePlatform;
        public static string user_id = "sondh";
        string token = string.Empty;

        //message_limit(integer|optional) : Specifies the number of messages that should be retrieved from 
        //the persistent store and populated after the subscription is established.By default it is 20. 
        //The maximum value is 100.
        int message_limit = 1;

        public SubcriptionJib()
        {
            string[] array = instance.Split(':');
            region = array[1];
            instance_id  = array[2];

            DOMAIN = string.Format("{0}.pusherplatform.io", region);
            subcribe_rooms_url = string.Format("https://{0}/services/chatkit/v2/{1}/users", DOMAIN, instance_id);
            //subcribe_userstateonoff_url = string.Format("https://us1.pusherplatform.io/services/chatkit_presence/v2/{0}/users/{1}", instance_id);
        }

        public async Task<TokenResponse> RequestToken()
        {
            TokenRequest tokenRequest = new TokenRequest()
            {
                grant_type = "client_credentials",
                user_id = user_id
            };
            TokenResponse jib = await DependencyService.Get<IJibApi>().PostToken(tokenRequest);

            return jib;
        }

        public async void Connect()
        {
            TokenResponse tokenResponse = await RequestToken();
            if (tokenResponse != null)
            {
                token = tokenResponse.access_token;
                SubcribeRooms();
            }
        }

        public void Dispose()
        {
            if (backgroundRoomsThread != null)
            {
                backgroundRoomsThread.Abort();
            }
        }

        public string GetToken()
        {
            return string.Format("Bearer {0}",token);
        }

        public string GetChatkitId()
        {
            return user_id;
        }
    }
}

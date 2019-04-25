using System;
using System.IO;
using System.Net;
using System.Threading;
using t.MyChatkit.ModelChatkit.ModelRelatedSubcriptionRoom;

namespace t
{
    public partial class SubcriptionJib
    {
        public void JoinRoom(Room room)
        {
            SubcribeMemberShip(room.id);
        }

        public void LeaveRoom() {
            if (backgroundThread != null)
            {
                backgroundThread.Abort();
                backgroundThread = null;
            }

            if (SubcribeMessageRequest != null)
            {
                SubcribeMessageRequest.Abort();
                SubcribeMessageRequest = null; 
            }


            MessageReceived = null;

        }

        Thread backgroundThread;
        string subcribe_message_of_room_url = string.Empty;
        public event EventHandler<string> MessageReceived;

        HttpWebRequest SubcribeMessageRequest;

        //Sent as soon as a client subscribes to the user subscription endpoint.
        //The event data contains a list of rooms the user is a member of.
        private void ActionJoinRoomMemberShip(string roomid)
        {
            subcribe_message_of_room_url = string.Format("https://{0}/services/chatkit/v2/{1}/rooms/{2}?message_limit={3}", DOMAIN, instance_id, roomid, message_limit);

            try
            {
                // Create a new HttpWebRequest object.Make sure that 
                // a default proxy is set if you are behind a firewall.
                SubcribeMessageRequest =
                  (HttpWebRequest)WebRequest.Create(subcribe_message_of_room_url);
                SubcribeMessageRequest.Method = "SUBSCRIBE";
                SubcribeMessageRequest.KeepAlive = true;
                SubcribeMessageRequest.Headers.Add("Authorization", GetToken());
                SubcribeMessageRequest.Accept = "*/*";
                SubcribeMessageRequest.ContentType = "application/vnd.pusher.elements.subscription";
                SubcribeMessageRequest.Headers.Add("x-heartbeat-interval", heatbeat_interval);
                SubcribeMessageRequest.Headers.Add("x-sdk-platform", sdk_platform);
                SubcribeMessageRequest.Headers.Add("x-sdk-language", "swift");
                SubcribeMessageRequest.Headers.Add("x-initial-heartbeat-size", "0");
                SubcribeMessageRequest.Headers.Add("x-sdk-version", sdkversion);
                SubcribeMessageRequest.Headers.Add("x-sdk-product", "chatkit");


                // Assign the response object of HttpWebRequest to a HttpWebResponse variable.

                using (HttpWebResponse myHttpWebResponse1 =
                  (HttpWebResponse)SubcribeMessageRequest.GetResponse())
                using (Stream stream = myHttpWebResponse1.GetResponseStream())
                using (StreamReader reader = new StreamReader(stream))
                {
                    string line = string.Empty;
                    while (!reader.EndOfStream)
                    {
                        line = reader.ReadLine();
                        // process the line
                        MessageReceived?.Invoke(null, line);
                    }
                }
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("\nThe second HttpWebRequest object has raised an Argument Exception as 'Connection' Property is set to 'Close'");
                Console.WriteLine("\n{0}", ex.Message);
            }
            catch (WebException eq)
            {
                Console.WriteLine("WebException raised!");
                Console.WriteLine("\n{0}", eq.Message);
                Console.WriteLine("\n{0}", eq.Status);
            }
            catch (Exception ea)
            {
                Console.WriteLine("Exception raised!");
                Console.WriteLine("Source :{0} ", ea.Source);
                Console.WriteLine("Message :{0} ", ea.Message);
            }
        }



        private void SubcribeMemberShip(string roomid)
        {
            if (string.IsNullOrEmpty(token))
            {
                return;
            }
            if (backgroundThread == null || !backgroundThread.IsAlive)
            {
                backgroundThread = new Thread(() =>
                {
                    ActionJoinRoomMemberShip(roomid);
                })
                { IsBackground = true };
                backgroundThread.Start();
            }
        }
    }
}

using System;
using System.IO;
using System.Net;
using System.Threading;
using Newtonsoft.Json.Linq;

namespace t
{
    //switch eventName {
    //case .initial_state:
    //    parseInitialStatePayload(eventName, data: apiEventData, userStore: self.userStore)
    //case .added_to_room:
    //    parseAddedToRoomPayload(eventName, data: apiEventData)
    //case .removed_from_room:
    //    parseRemovedFromRoomPayload(eventName, data: apiEventData)
    //case .room_updated:
    //    parseRoomUpdatedPayload(eventName, data: apiEventData)
    //case .room_deleted:
    //    parseRoomDeletedPayload(eventName, data: apiEventData)
    //}

    public enum RoomEvent {
        initial_state,
        added_to_room,
        removed_from_room,
        room_updated,
        room_deleted,
    }

    public partial class SubcriptionJib 
    {
        Thread backgroundRoomsThread;
        string subcribe_rooms_url = string.Empty;
        public event EventHandler<string> RoomsReceived;
        //Sent as soon as a client subscribes to the user subscription endpoint.
        //The event data contains a list of rooms the user is a member of.
        private void ActionSubcribeRooms()
        {
            try
            {
                // Create a new HttpWebRequest object.Make sure that 
                // a default proxy is set if you are behind a firewall.
                HttpWebRequest myHttpWebRequest1 =
                  (HttpWebRequest)WebRequest.Create(subcribe_rooms_url);
                myHttpWebRequest1.Method = "SUBSCRIBE";
                myHttpWebRequest1.KeepAlive = true;
                myHttpWebRequest1.Headers.Add("Authorization", GetToken());
                myHttpWebRequest1.Accept = "*/*";
                myHttpWebRequest1.ContentType = "application/vnd.pusher.elements.subscription";
                myHttpWebRequest1.Headers.Add("x-heartbeat-interval", heatbeat_interval);
                myHttpWebRequest1.Headers.Add("x-sdk-platform", sdk_platform);
                myHttpWebRequest1.Headers.Add("x-sdk-language", "swift");
                myHttpWebRequest1.Headers.Add("x-initial-heartbeat-size", "0");
                myHttpWebRequest1.Headers.Add("x-sdk-version", sdkversion);
                myHttpWebRequest1.Headers.Add("x-sdk-product", "chatkit");


                // Assign the response object of HttpWebRequest to a HttpWebResponse variable.
                HttpWebResponse myHttpWebResponse1 =
                  (HttpWebResponse)myHttpWebRequest1.GetResponse();


                using (Stream stream = myHttpWebResponse1.GetResponseStream())
                using (StreamReader reader = new StreamReader(stream))
                {
                    while (!reader.EndOfStream)
                    {
                        string line = reader.ReadLine();
                        // process the line
                        RoomsReceived?.Invoke(null, line);
                        //break;
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

        private void SubcribeRooms()
        {
            if (string.IsNullOrEmpty(token))
            {
                return;
            }
            if (backgroundRoomsThread == null)
            {
                backgroundRoomsThread = new Thread(ActionSubcribeRoomsThreadStart)
                { IsBackground = true };
                backgroundRoomsThread.Start();
            }
        }

        void ActionSubcribeRoomsThreadStart()
        {
            ActionSubcribeRooms();
        }
    }
}

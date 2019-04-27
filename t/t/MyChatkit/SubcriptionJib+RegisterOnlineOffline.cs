using System;
using System.IO;
using System.Net;
using System.Threading;

namespace t
{
    public partial class SubcriptionJib
    {
        Thread backgroundRegisterOnline;
        string subcribe_register_online_url = string.Empty;


        //A user with at least one active subscrition to this endpoint is considered online. 
        //When an offline user subscribes, anyone listening to their presence state will be informed that they have come online. Likewise, any listening user will be told when a user no longer has any active subscriptions, and has gone offline.
        private void ActionKeepUserOnline()
        {

            subcribe_register_online_url = string.Format("https://{0}/services/chatkit_presence/v2/{1}/users/{2}/register", DOMAIN, instance_id, user_id);
            try
            {
                // Create a new HttpWebRequest object.Make sure that 
                // a default proxy is set if you are behind a firewall.
                HttpWebRequest myHttpWebRequest1 =
                  (HttpWebRequest)WebRequest.Create(subcribe_register_online_url);
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
                        //JoinLeaveHandle?.Invoke(null, line);
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

        private void DisconnectKeepUserOnline()
        {
            if (backgroundRegisterOnline != null)
            {
                backgroundRegisterOnline.Abort();
            }
        }

        private void SubcribeKeepUserOnline()
        {
            if (string.IsNullOrEmpty(token)) return;

            if (backgroundRegisterOnline == null)
            {
                backgroundRegisterOnline = new Thread(HandleSubcribeKeepUserOnline)
                { IsBackground = true };
                backgroundRegisterOnline.Start();
            }
        }

        void HandleSubcribeKeepUserOnline()
        {
            ActionKeepUserOnline();
        }
    }
}

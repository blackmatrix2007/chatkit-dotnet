using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading;
using t.MyChatkit;

namespace t
{

    //There is no inherent limit.The maximum number of threads is determined by the amount of physical resources available.See this article by Raymond Chen for specifics.

    //If you need to ask what the maximum number of threads is, you are probably doing something wrong.


    //[Update: Just out of interest: .NET Thread Pool default numbers of threads:

    //    1023 in Framework 4.0 (32-bit environment)
    //    32767 in Framework 4.0 (64-bit environment)
    //    250 per core in Framework 3.5
    //    25 per core in Framework 2.0

    public partial class SubcriptionJib
    {
        private readonly int MAX_THREADS = 25;
        private IList<Thread> _threads = null;
        string subcribe_userstateonoff_url = string.Empty;
        public event EventHandler<string> OnOffHandle;

        private void InitThreadPoolForListenManyUser() {
            _threads = new List<Thread>();
        }

        private void FetchUserFromApi() {
            SubcribeUserStateOnOff("neo2_at_gmailcom");
            SubcribeUserStateOnOff("one_at_hotelsng");
            SubcribeUserStateOnOff("neo_at_hotelsng");
            SubcribeUserStateOnOff("sondh");
        }

        private void ActionUserStateOnOff(string partnerid)
        {
            try
            {
                string url = subcribe_userstateonoff_url.Replace("partnerid", partnerid);
                // Create a new HttpWebRequest object.Make sure that 
                // a default proxy is set if you are behind a firewall.
                HttpWebRequest myHttpWebRequest1 =
                  (HttpWebRequest)WebRequest.Create(url);
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
                        OnOffHandle?.Invoke(partnerid, line);
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


        public void KillAll()
        {

            foreach (Thread thread in _threads)
            {
                thread.Abort();
            }
        }

        public void KillThread(int index)
        {
            string id = string.Format("MyThread{0}", index);
            int count = _threads.Count;
            int i = 0;
            for (; i < count; i++)
            {
                if (_threads[i].Name == id) {
                    _threads[i].Abort();
                    break;
                }
            }
            _threads.RemoveAt(i);

        }

        private void DisconnectHandleUserStateOnOff()
        {
            KillAll();
        }


        public void SubcribeUserStateOnOff(string partnerid)
        {
            if (string.IsNullOrEmpty(token))
            {
                return;
            }

            if (_threads.Count >  MAX_THREADS)
            {
                Console.WriteLine("current number threads {0} maximum", _threads.Count);
                return;
            }

            Thread thread = new Thread(ActionUserStateOnOffThreadStart);
            thread.IsBackground = true;
            thread.Name = string.Format("MyThread{0}", partnerid);

            _threads.Add(thread);
            thread.Start(partnerid);
        }

        void ActionUserStateOnOffThreadStart(object obj)
        {
            string partnerid = obj as string;
            ActionUserStateOnOff(partnerid);
        }
    }
}
